using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 10;
    }

    void Update()
    {
        transform.Translate(1, 0, 0);
    }
}
