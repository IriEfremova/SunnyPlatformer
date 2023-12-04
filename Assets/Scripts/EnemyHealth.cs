using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class EnemyHealth : Health
{
    public GameObject DestroyEffect;

    protected override void EmptyHealth()
    {
        Instantiate(DestroyEffect, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
