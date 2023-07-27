using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpforce;

    public bool isGrounded;
    private Rigidbody2D rigidbody2d;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }
    private void FixedUpdate()
    {

        Vector3 position = transform.position;

        position.x += Input.GetAxis("Horizontal") * speed;

        transform.position = position;


        if (Input.GetAxis("Horizontal") != 0)
        {
            if (Input.GetAxis("Horizontal") < 0)
            {
                spriteRenderer.flipX = false;
            }
            else if (Input.GetAxis("Horizontal") > 0)
            {
                spriteRenderer.flipX = true;
            }

            if (isGrounded)
            {
                animator.SetInteger("State", 1);
            }
            else
            {
                animator.SetInteger("State", 2);
            }
           
        }
        else
        {
            if (isGrounded)
            {
                animator.SetInteger("State", 0);
            }
            else
            {
                animator.SetInteger("State", 2);
            }
        }
    }

    private void Jump()
    {
        rigidbody2d.AddForce(transform.up * jumpforce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

}
