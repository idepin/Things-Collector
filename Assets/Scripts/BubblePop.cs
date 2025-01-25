using UnityEngine;

public class BubblePop : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Right Click");
            animator.SetBool("isPopped", true);
        }
    }
}
