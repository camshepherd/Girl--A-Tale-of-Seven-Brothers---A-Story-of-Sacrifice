using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoorHandler : MonoBehaviour
{
    public Canvas canvas;
    public string nextScene;
    public bool CanvasOrScene; // true = scene, false= canvas
    //private Animator animator;
    private void Start()
    {
        canvas.enabled = false;
        //animator = GameObject.Find("Level Transition").GetComponent<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if (!CanvasOrScene)
            {
                other.GetComponent<PlayerMovement>().sleep();
                //other.GetComponent<PlayerMovement>().enabled = false;
                canvas.enabled = true;
            }
            else
            {
                //animator.SetTrigger("FadeOut");
                other.GetComponent<PlayerMovement>().Awake();
                SceneManager.LoadScene(nextScene);
            }
        }
    }
}
