using UnityEngine;
using NaughtyAttributes;
using DG.Tweening;

public class BubbleHit : MonoBehaviour
{
    public float radius = 0.5f; // The radius of the sphere
    public LayerMask layerMask;
    [Layer][SerializeField] private int layerAfterHit;
    [SerializeField] private GameObject bubblePhysic; // Filter the objects the raycast should detect

    private Vector2 originalPos;
    private RectTransform rectTransform;

    public void ResetPosition()
    {
        //transform.position = originalPos;
        rectTransform.DOAnchorPos(originalPos, 0.4f);
    }

    private void Start()
    {
        originalPos = rectTransform.anchoredPosition;
    }

    public void TryHit()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D hit = Physics2D.CircleCast(mousePosition, radius, Vector2.zero, 0, layerMask);
        if (hit.collider != null)
        {
            Debug.Log($"Hit {hit.collider.gameObject.name} at {hit.point}");
            GameObject go = Instantiate(bubblePhysic);
            go.transform.position = mousePosition;
            //go.GetComponent<BubbleHit>().enabled = false;
            // Do something with the hit object, e.g., highlight or interact
            hit.collider.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            hit.collider.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            hit.collider.GetComponent<Thing>().LockPosition(go.transform);
            hit.collider.gameObject.layer = layerAfterHit;
            rectTransform.anchoredPosition = originalPos;
        }
        else
        {
            Debug.Log("No object hit within the radius.");
        }
    }

    private void OnDrawGizmos()
    {
        // Visualize the spherecast in the Scene view (optional)
        if (Camera.main != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(ray.origin, ray.origin + ray.direction * 10); // Draw the ray
            Gizmos.DrawWireSphere(ray.origin, radius); // Draw the starting sphere
        }
    }
}
