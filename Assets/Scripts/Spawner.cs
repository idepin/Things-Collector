using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float minForce = 1f;
    public float maxForce = 10f;
    public float minTorque = -30f;
    public float maxTorque = 30f;
    public float minGravityScale = 0.05f;
    public float maxGravityScale = 0.1f;
    public float spawnRate = 1f;
    [SerializeField] private ObjectPool pool;

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), 0.4f, spawnRate);
    }

    private void Spawn()
    {
        GameObject thing = pool.Get();
        thing.transform.position = transform.position;
        Thing _thing = thing.GetComponent<Thing>();
        _thing.Initialize(pool);
        _thing.Spawn(minForce, maxForce, minTorque, maxTorque);
        thing.GetComponent<Rigidbody2D>().gravityScale = Random.Range(minGravityScale, maxGravityScale);
    }
}
