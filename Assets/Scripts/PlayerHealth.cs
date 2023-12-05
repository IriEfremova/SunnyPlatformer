using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    public Transform RespawnPosition;
    public Image[] LifeImages;

    private int lifesCount;

    void Start()
    {
        base.Start();
        UpdateLife();
    }

    protected override void EmptyHealth()
    {
        try
        {
            GetComponent<Animator>().SetBool("Hurt", true);
            DecreaseLife();
        }
        catch (MissingComponentException e)
        {
            Debug.LogError("PlayerHealth.sc: " + e.Message);
        }
    }

    private void UpdateLife()
    {
        lifesCount = LifeImages.Length;
        foreach (Image element in LifeImages)
            element.GetComponent<Image>().enabled = true;
    }

    private void DecreaseLife()
    {
        Debug.Log("DecreaseLife " + health + "  " + lifesCount);
        lifesCount--;
        UpdateHealth();
        if (lifesCount <= 0)
        {
            StartCoroutine(RespawnCoroutine());            
            UpdateLife();
        }
        else
            LifeImages[lifesCount].GetComponent<Image>().enabled = false;
    }

    IEnumerator RespawnCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            gameObject.transform.position = RespawnPosition.position;
        }
    }
}
