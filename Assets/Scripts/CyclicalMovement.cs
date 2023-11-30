using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyclicalMovement : MonoBehaviour
{
    public float Speed = 1;
    public float Period = 1;
    //ѕеремещение вертикальное или горизонтальное
    public bool isVertical = false;

    private Rigidbody2D rb;
    private float timer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = Period;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Speed = -Speed;
            if (!isVertical)
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

            timer = Period;
        }
    }

    private void FixedUpdate()
    {
        if (isVertical)
            rb.MovePosition(new Vector2(rb.position.x, rb.position.y + Speed));
        else
            rb.MovePosition(new Vector2(rb.position.x + Speed, rb.position.y));
    }
}
