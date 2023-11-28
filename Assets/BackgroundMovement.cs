using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public GameObject Player;

    public Transform[] layers;
    public float[] speeds;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < layers.Length; i++)
        {
            float deltaX = Input.GetAxis("Horizontal");
            layers[i].Translate(Vector2.left * deltaX * speeds[i] * Time.deltaTime);
        }
    }

}
