using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Coin : MonoBehaviour
{
    private Transform target = null;
    [SerializeField] private float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.Slerp(transform.position, target.position + Vector3.up, Time.deltaTime * speed);
            if (Vector3.Distance(transform.position, target.position)  < 0.2f)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (target != null) return;

        if (other.CompareTag("Player"))
        {
            target = other.transform;
            GetComponentInChildren<MeshCollider>().enabled = false;
            ScoreManager.scorevalue += 10;
        }
    }

}
