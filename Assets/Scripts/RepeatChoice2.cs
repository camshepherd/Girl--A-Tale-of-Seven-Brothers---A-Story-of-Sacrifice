using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RepeatChoice2 : MonoBehaviour
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
            //collision.GetComponent<PlayerMovement>().sleep();
            if (GameStores.Choice1 == 2)
            {
                GameStores.Choice1 = 1;
                SceneManager.LoadSceneAsync("CutScene_2c");
            }
            else
            {
                GameStores.Choice1 = 2;
                SceneManager.LoadSceneAsync("CutScene_2d");
            }
            //StartCoroutine(repeat());
        }
    }

    IEnumerator repeat()
    {
        yield return new WaitForSecondsRealtime(1);
        if(GameStores.Choice1 == 2){
            GameStores.Choice1 = 1;
            SceneManager.LoadSceneAsync("CutScene_2c");
        }
        else
        {
            GameStores.Choice1 = 2;
            SceneManager.LoadSceneAsync("CutScene_2d");
        }
    }
}
