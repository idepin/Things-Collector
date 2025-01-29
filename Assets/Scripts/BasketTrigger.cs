using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

public class BasketTrigger : MonoBehaviour
{
    [Tag][SerializeField] private string thingTag;
    [Layer][SerializeField] private int afterHitLayer;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(thingTag) && other.gameObject.layer == afterHitLayer)
        {
            Debug.Log("Catched!");
            transform.DOComplete();
            transform.DOShakeScale(0.4f, 0.2f);
            Thing thing = other.GetComponent<Thing>();
            PointManager.instance.AddPoint(thing.price);
        }
    }
}
