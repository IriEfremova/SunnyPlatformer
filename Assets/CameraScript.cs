using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private Transform LeftBorder, RightBorder;

    private float orthoSize;
    private float horBound;
    private float vertBound;
    private void Start()
    {
        orthoSize = GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize;
        Debug.Log("orthoSize = " + orthoSize);
        horBound = orthoSize / Screen.width;
        Debug.Log("Screen.width = " + Screen.width);
    }

    // Update is called once per frame
    void Update()
    {
        float leftBound, rightBound, upBound, downBound;

        leftBound = transform.position.x - horBound;
        rightBound = transform.position.x + horBound;
        upBound = transform.position.y + vertBound;
        downBound = transform.position.y - vertBound;

        Debug.Log("Left Bound = " + leftBound);
        if(leftBound <= 0)
        {
            transform.position = transform.position;
        }
    }
}
