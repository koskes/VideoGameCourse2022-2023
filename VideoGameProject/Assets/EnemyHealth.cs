using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    private Spawner myParentSpawner;

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
