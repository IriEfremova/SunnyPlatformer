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
            Vector2 characterDir = collision.gameObject.transform.position - transform.position;
            Vector2 enemyDir = collision.GetContact(0).rigidbody.velocity;
            float angle = Vector2.Angle(characterDir.normalized, enemyDir.normalized);
            
            //float characterVelocity = collision.GetContact(0).otherRigidbody.velocity.magnitude;
            //Debug.Log("rel = " + collision.relativeVelocity + " " + collision.GetContact(0).normalImpulse + " " + collision.GetContact(0).tangentImpulse);
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
