using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject explosionParticles;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        
        rb.angularVelocity = Random.Range(100, 200);
    }

    void Update()
    {
        if (transform.position.y < -7)
        {
            Debug.Log("ohmaygot");
            Destroy(gameObject);
        }
    }

    public void Slice()
    {
        Instantiate(explosionParticles, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
