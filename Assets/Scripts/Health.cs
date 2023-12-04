using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField]
    private float PeriodUnDamage = 1.0f;
    private bool isUnDamage;
    private float unDamageTimer;

    [SerializeField]
    private int MaxHealth = 1;
    [SerializeField]
    private int UnitHealth = 1;
    protected int health;

    
    protected virtual void Start()
    {
        health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (isUnDamage)
        {
            unDamageTimer -= Time.deltaTime;
            if (unDamageTimer < 0)
                isUnDamage = false;
        }
    }

    public void DecreaseHealth()
    {
        if (isUnDamage)
            return;

        isUnDamage = true;
        unDamageTimer = PeriodUnDamage;

        health -= UnitHealth;
        if (health <= 0)
        {
            EmptyHealth();
        }
    }

    public void AddHealth()
    {
        health = Mathf.Clamp(health + UnitHealth, 0, MaxHealth);
    }

    protected void UpdateHealth()
    {
        health = MaxHealth;
    }

    protected abstract void EmptyHealth();
}
