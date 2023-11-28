using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleHealth : MonoBehaviour
{
    public GameObject CollectEffect;
    public string textName;

    private TMP_Text textCount;
    static private int count;
    
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            textCount = GameObject.Find("Canvas/" + textName).GetComponent<TMP_Text>();
         }
        catch(NullReferenceException e)
        {
           Debug.LogError("CollectibleHealth.sc: no binding to the UI element for display count." + e.Message);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            count++;

            if(textCount)
                textCount.text = count.ToString();
            else
                Debug.LogError("CollectibleHealth.sc: no find UI element for display count");

            GetComponent<SpriteRenderer>().enabled = false;
            Instantiate(CollectEffect, transform.position, Quaternion.identity);
            Destroy(gameObject, 1);
        }
    }
}
