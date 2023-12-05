using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float Speed = 5, JumpForce = 400;
    public Vector2 CrouchColliderSize = new Vector2(0.96f, 0.86f);
    public Vector2 CrouchColliderOffset = new Vector2(0.06f, -0.56f);

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    private Vector2 defColliderSize, defColliderOffset;
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
        boxCollider = GetComponent<BoxCollider2D>();
        defColliderSize = boxCollider.size;
        defColliderOffset = boxCollider.offset;
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
            boxCollider.size = CrouchColliderSize;
            boxCollider.offset = CrouchColliderOffset;
            isCrouch = true;
        }
        else
        {
            animator.SetBool("Crouch", false);
            boxCollider.size = defColliderSize;
            boxCollider.offset = defColliderOffset;
            isCrouch = false;
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            upForce = JumpForce;
            animator.SetBool("Jump", true);
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
        if (isCrouch)
        {
            upForce = 0;
            return;
        }
            
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
            animator.SetBool("Jump", false);
        }
    }


}
