using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    public GameObject DestroyEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 direction = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            if (direction != null)
            {
                float angle = Vector2.Angle(direction, Vector2.up);
                Debug.Log("angle = " + angle);

                if (angle > 120)
                {
                    Instantiate(DestroyEffect, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }
                else
                {
                    Destroy(collision.gameObject);
                }
            }
        }
    }
}
