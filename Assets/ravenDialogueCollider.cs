using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ravenDialogueCollider : MonoBehaviour
{
    public CutScene7Controller canvasController;
    // Start is called before the first frame update
    void Start()
    {
        canvasController.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().sleep();
            //collision.gameObject.GetComponent<PlayerMovement>().enabled = false;
            //collision.gameObject.GetComponent<CharacterController2D>().enabled = false;
            canvasController.enabled = true;
        }
    }
}
