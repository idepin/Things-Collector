using UnityEngine;

public class Thing : MonoBehaviour
{
    private Rigidbody2D rb;
    private ObjectPool pool;

    private bool isLocked;
    private Transform follow;

    public void Initialize(ObjectPool objectPool)
    {
        pool = objectPool;
        rb = GetComponent<Rigidbody2D>();
    }

    public void LockPosition(Transform pos)
    {
        follow = pos;
        isLocked = true;
    }

    private void Update()
    {
        if (isLocked)
        {
            transform.position = follow.position;
            // Vector3 worldPosition;
            // if (RectTransformUtility.ScreenPointToWorldPointInRectangle(follow, follow.position, Camera.main, out worldPosition))
            // {
            //     // Update the world object's position
            //     transform.position = worldPosition;
            // }
        }
    }

    public void Spawn(float minForce, float maxForce, float minTorque, float maxTorque)
    {
        Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        rb.AddForce(randomDirection * Random.Range(minForce, maxForce));
        rb.AddTorque(Random.Range(minTorque, maxTorque));
    }

    private void OnBecameInvisible()
    {
        if (pool != null)
        {
            pool.ReturnToPool(gameObject);
        }
    }
}
