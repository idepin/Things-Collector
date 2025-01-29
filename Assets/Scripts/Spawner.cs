using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float minForce = 1f;
    public float maxForce = 10f;
    public float minTorque = -30f;
    public float maxTorque = 30f;
    public float minGravityScale = 0.05f;
    public float maxGravityScale = 0.1f;
    public float minSpawnRate = 0.4f;
    public float maxSpawnRate = 1.5f;
    [SerializeField] private ObjectPool pool;
    [SerializeField] private List<ThingDataSO> things = new();

    private void Start()
    {
        //InvokeRepeating(nameof(Spawn), 0.4f, spawnRate);
        StartCoroutine(Spawning());
    }

    IEnumerator Spawning()
    {
        while (true)
        {
            float waitingFor = Random.Range(minSpawnRate, maxSpawnRate);
            yield return new WaitForSeconds(waitingFor);
            Debug.Log("Waiting For " + waitingFor);
            Spawn();
        }

    }

    private void Spawn()
    {
        // Select a ThingDataSO based on probability
        ThingDataSO selectedThingData = GetRandomThingByProbability();
        if (selectedThingData == null)
        {
            Debug.LogWarning("No thing data selected. Check your probabilities.");
            return;
        }
        GameObject thing = pool.Get();
        if (selectedThingData.isSharp)
            thing.tag = "Sharp";
        else
            thing.tag = "Catchable";
        thing.transform.position = transform.position;
        Thing _thing = thing.GetComponent<Thing>();
        _thing.Initialize(pool, selectedThingData.thingSprite, selectedThingData.price);
        _thing.Spawn(minForce, maxForce, minTorque, maxTorque);
        thing.GetComponent<Rigidbody2D>().gravityScale = Random.Range(minGravityScale, maxGravityScale);
    }

    private ThingDataSO GetRandomThingByProbability()
    {
        float totalProbability = 0f;
        foreach (var thing in things)
        {
            totalProbability += thing.probability;
        }

        // Generate a random value in the range of 0 to totalProbability
        float randomValue = Random.Range(0f, totalProbability);

        // Find the thing corresponding to the random value
        float cumulativeProbability = 0f;
        foreach (var thing in things)
        {
            cumulativeProbability += thing.probability;
            if (randomValue <= cumulativeProbability)
            {
                return thing;
            }
        }

        return null; // Should not occur if probabilities are set correctly
    }
}
