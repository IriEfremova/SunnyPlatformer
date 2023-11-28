using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyclicalMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 1;
    //ѕеремещение вертикальное или горизонтальное
    public bool isVertical = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (isVertical)
            rb.MovePosition(new Vector2(rb.position.x, rb.position.y + speed));
        else
            rb.MovePosition(new Vector2(rb.position.x + speed, rb.position.y));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Barrier"))
        {
            speed = -speed;
            if (!isVertical)
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

}
