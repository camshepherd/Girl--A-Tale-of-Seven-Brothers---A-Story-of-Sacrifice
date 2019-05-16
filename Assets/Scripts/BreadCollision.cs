using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadCollision : MonoBehaviour
{
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
            //collision.GetComponent<Inventory>().changeBread(1);
            GameStores.BreadQuantity += 1;
            GameStores.levelBread += 1;
            Destroy(this.gameObject);
        }
    }
}
