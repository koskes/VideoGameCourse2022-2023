using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthOrb : MonoBehaviour
{
    Animator animator;
    public float value = 50f;
    bool taken;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        taken = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //ask for button
            if (Input.GetKeyDown(KeyCode.E) && !taken)
            {
                Heal(other);
                taken = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    void Heal(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.Heal(value);
            animator.SetTrigger("Interact");

            Destroy(gameObject, 1f);
        }
    }
}
