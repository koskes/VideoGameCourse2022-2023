using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100;
    public float health;
    bool dead;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float dmg)
    {
        if (dead) return;

        health = Mathf.Max(health - dmg, 0);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        dead = true;
    }
}
