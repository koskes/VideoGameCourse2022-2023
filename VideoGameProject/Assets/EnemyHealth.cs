using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : Health
{
    private Spawner myParentSpawner;
    public Slider healthBar;
    public Animator animator;

    protected override void Start()
    {
        base.Start();

        UpdateUI();
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);

        UpdateUI();

        //hit animation
        animator.SetTrigger("Hit");
    }

    void UpdateUI()
    {
        healthBar.value = currentHealth / totalHealth;
    }

    public void RegisterSpawner(Spawner myParentSpawner)
    {
        this.myParentSpawner = myParentSpawner;
    }

    protected override void Die()
    {
        base.Die();

        myParentSpawner.NotifyDeath(this);

        Destroy(gameObject);
    }
}
