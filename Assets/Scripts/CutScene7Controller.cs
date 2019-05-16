using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScene7Controller : MonoBehaviour
{
    public Canvas[] canvas;
    public Canvas choiceCanvas;
    public int n;
    private float sceneTransition = 0.3f;
    public float stop_n = -1;


    public int breadTarget;
    public int breadToHeal;
    public string partialSuccessScene;
    public string partialSuccessScene2;
    public string fullSuccessScene;
    public string FailureScene;
    public string otherFailure;

    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        GameStores.changeScene();
        Time.timeScale = 1;
        choiceCanvas.enabled = false;
        for (int x = 0; x < canvas.Length; x++)
        {
            if (x == n)
            {
                canvas[x].enabled = true;
            }
            else
            {
                canvas[x].enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (n != stop_n && timer >= sceneTransition && Input.anyKey)
        {
            timer = 0;
            n += 1;
            if (n < canvas.Length)
            {
                canvas[n - 1].enabled = false;
                canvas[n].enabled = true;
            }
            else
            {
                if (GameStores.Choice3 == 1)
                {
                    if (breadTarget > GameStores.BreadQuantity)
                    {
                        SceneManager.LoadScene(FailureScene);
                    }
                    else
                    {
                        choiceCanvas.enabled = true;
                    }
                }
                else if (GameStores.Choice3 == 2 && GameStores.BreadQuantity == 0)
                {
                    SceneManager.LoadScene(otherFailure);
                }
                else if(GameStores.Choice3 == 2 && GameStores.BreadQuantity < breadTarget)
                {
                    SceneManager.LoadScene(partialSuccessScene2);
                }
                else 
                //if(GameStores.Choice3 == 2 && GameStores.BreadQuantity >= breadTarget)
                {
                    SceneManager.LoadSceneAsync(fullSuccessScene);
                }
                //else
                //{
                //    print("Something has gone very badly wrong");
                //}
            }
        }
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
    }
}
