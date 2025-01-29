using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Thing : MonoBehaviour
{
    public Rigidbody2D rb;
    private ObjectPool pool;

    private bool isLocked;
    private Transform follow;
    [SerializeField] private SpriteRenderer thingImage;
    [SerializeField][Layer] private int layerThing;
    public int price;


    public void Initialize(ObjectPool objectPool, Sprite thingSprite, int _price)
    {
        pool = objectPool;
        rb = GetComponent<Rigidbody2D>();
        thingImage.sprite = thingSprite;
        price = _price;
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
            if (follow == null) return;
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
            gameObject.layer = layerThing;
            pool.ReturnToPool(gameObject);
        }
    }
}
