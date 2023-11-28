using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float Speed = 5, JumpForce = 400;
    
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private Vector2 move;
    private float upForce;
    private bool isGround = true;
    private bool isCrouch = false;
    private bool isFlipLeft = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Crouch();
    }

    private void Crouch()
    {
        if (Input.GetKey(KeyCode.C) && isGround)
        {
            animator.SetBool("Crouch", true);
            isCrouch = true;
        }
        else
        {
            animator.SetBool("Crouch", false);
            isCrouch = false;
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            upForce = JumpForce;
            animator.SetTrigger("Jump");
        }
    }

    private void Move()
    {
        float deltaX = Input.GetAxis("Horizontal");
        move.Set(Speed * deltaX , rb.velocity.y);

        animator.SetFloat("Move", Mathf.Abs(move.x));

        if (move.x > 0 && isFlipLeft || move.x < 0 && !isFlipLeft)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            isFlipLeft = !isFlipLeft;
        }         
    }

    private void FixedUpdate()
    {
        if (upForce > 0)
        {
            rb.AddForce(Vector2.up * upForce);
            upForce = 0;
            isGround = false;
        }
        rb.velocity = move;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }
}
