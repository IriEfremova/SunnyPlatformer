using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int MaxHealth = 1;
    public string CollisionTag = "Player";
    public float DestroyAngle = 40;
    public GameObject DestroyEffect;

    private int health;
    // Start is called before the first frame update
    void Start()
    {
        health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(CollisionTag))
        {
            Vector2 characterDir = collision.gameObject.transform.position - transform.position;
            Vector2 enemyDir = collision.GetContact(0).rigidbody.velocity;
            float angle = Vector2.Angle(characterDir.normalized, enemyDir.normalized);

            if (angle > DestroyAngle)
            {
                //”ничтожаем врага
                Instantiate(DestroyEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
