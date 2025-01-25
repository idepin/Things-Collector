using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class BubbleDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IDropHandler, IEndDragHandler
{
    private BubbleHit bubbleHit;

    private void Start()
    {
        bubbleHit = GetComponent<BubbleHit>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Drag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        Vector2 mousePos = Input.mousePosition;
        transform.position = mousePos;

    }



    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (bubbleHit != null && bubbleHit.isActiveAndEnabled)
            bubbleHit.TryHit();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        bubbleHit.ResetPosition();
    }
}
