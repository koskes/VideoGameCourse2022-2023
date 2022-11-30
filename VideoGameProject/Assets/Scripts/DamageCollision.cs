using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollision : MonoBehaviour
{
    public float damage = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Col: " + collision.gameObject.name);
        if (collision.collider.CompareTag("Player"))
        {
            Health health = collision.gameObject.GetComponentInParent<Health>();
            health?.TakeDamage(damage);
        }
    }
    */

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Col: " + other.gameObject.name);
        if (other.CompareTag("Player"))
        {
            Health health = other.gameObject.GetComponentInParent<Health>();
            health?.TakeDamage(damage);
        }
    }
}
