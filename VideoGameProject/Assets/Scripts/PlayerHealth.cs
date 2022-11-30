using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    [Space]
    [Header("Player Health properties")]
    [Space]
    [SerializeField] bool immune;

    protected override void Start()
    {
        base.Start();

        immune = false;
    }

    public override void TakeDamage(float damage)
    {
        if (!alive) return;

        if (immune) return;

        //currentHealth -= damage;
        //if (currentHealth < 0) currentHealth = 0;

        currentHealth = Mathf.Max(currentHealth - damage, 0f);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected override void Die()
    {
        base.Die();

        Debug.Log("Game Over");
    }
}
