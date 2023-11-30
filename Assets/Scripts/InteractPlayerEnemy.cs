using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractPlayerEnemy : MonoBehaviour
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
            Vector2 p = collision.gameObject.transform.position;
            Vector2 e = transform.position;
            Vector2 d = p - e;

            Vector2 s = Vector2.right * gameObject.GetComponent<CyclicalMovement>().Speed;

            float angle = Vector2.Angle(d.normalized, s.normalized);
            //float angle = collision.gameObject.GetComponent<PlayerController>().GetAngle();
            Debug.Log("Vector dir = " + d + " Vector impulse = " + collision.GetContact(0).tangentImpulse);
            Debug.Log("Angle = " + angle);
            if (angle < 40)
                Destroy(collision.gameObject);
            else
            {
                //”ничтожаем врага
                Instantiate(DestroyEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
