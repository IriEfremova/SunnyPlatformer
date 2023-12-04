using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractPlayer : MonoBehaviour
{
    public float DestroyAngle = 40;
    public string CollisionTag = "Player";


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(CollisionTag))
        {
            Vector2 characterDir = collision.gameObject.transform.position - transform.position;
            Vector2 enemyDir = collision.GetContact(0).rigidbody.velocity;
            float angle = Vector2.Angle(characterDir.normalized, enemyDir.normalized);

            //float characterVelocity = collision.GetContact(0).otherRigidbody.velocity.magnitude;
            //Debug.Log("rel = " + collision.relativeVelocity + " " + collision.GetContact(0).normalImpulse + " " + collision.GetContact(0).tangentImpulse);
            GameObject damageObject;
            if (angle < 40)
                damageObject = collision.gameObject;
            else
                damageObject = gameObject;

            Health healthScript = damageObject.GetComponent<Health>();
            if (healthScript)
            {
                healthScript.DecreaseHealth();
            }
        }
    }
}
