using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    public GameObject DestroyEffect;

    private Rigidbody2D AttackRigidbody;

    private void Start()
    {
        try
        {
            AttackRigidbody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        }
        catch (NullReferenceException e)
        {
            Debug.LogError("DestroyEnemy.sc: no GameObject with tag Player." + e.Message);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 direction = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            if (direction != null)
            {
                float angle = Vector2.Angle(AttackRigidbody.velocity, Vector2.up);
                if (angle < 120)
                    Destroy(collision.gameObject);
                else
                {
                    Instantiate(DestroyEffect, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }
            }
        }
    }
}
