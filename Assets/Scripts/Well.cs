using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Well : MonoBehaviour
{
    public GameObject collisionEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Inventory>().refillWater();
            Instantiate(collisionEffect, transform.position + new Vector3(-0.4f,0,0), transform.rotation);
        }
    }
}
