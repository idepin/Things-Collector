using System;
using NaughtyAttributes;
using UnityEngine;

public class BubblePop : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private CircleCollider2D circleCollider2D;
    [SerializeField][Tag] private string sharpObjectTag;
    [SerializeField] private AudioClip popSFX;
    [SerializeField] private AudioSource audioSource;

    public bool isPopped = false;
    private bool isAllowToPop = false;

    public Thing thing;



    private void OnMouseEnter()
    {
        isAllowToPop = true;
    }

    private void OnMouseExit()
    {
        isAllowToPop = false;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(sharpObjectTag))
        {
            GetComponent<BubbleDragPhysics>().enabled = false;
            Pop();
        }
    }
    private void Update()
    {
        if (!isAllowToPop) return;

        if (Input.GetMouseButtonDown(1))
        {
            Pop();
        }
    }

    private void Pop()
    {
        animator.SetBool("isPopped", true);
        rb.gravityScale = 2;
        rb.bodyType = RigidbodyType2D.Dynamic;
        circleCollider2D.radius *= 0.5f;
        isPopped = true;
        thing.rb.bodyType = RigidbodyType2D.Dynamic;
        thing.rb.gravityScale = 2;
        thing.GetComponent<Collider2D>().enabled = true;
        audioSource.PlayOneShot(popSFX);
        Destroy(gameObject, 0.4f);
    }
}
