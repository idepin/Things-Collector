using DG.Tweening;
using UnityEngine;

public class BubbleDragPhysics : MonoBehaviour
{
    private Camera mainCamera;
    private Rigidbody2D rb;
    private bool isDragging = false;
    private Vector2 offset;

    void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        transform.DOShakeScale(0.4f, 0.2f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        transform.DOComplete();
        transform.DOShakeScale(0.4f, 0.2f);
    }

    void OnMouseDown()
    {
        isDragging = true;

        // Calculate offset between object position and mouse position
        Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        offset = (Vector2)transform.position - mousePosition;
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            // Update the Rigidbody's position to follow the mouse
            Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            rb.MovePosition(mousePosition + offset);
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
    }
}
