using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneController : MonoBehaviour
{
    public Canvas[] canvas;
    public int n;
    private float sceneTransition = 0.3f;
    public float stop_n = -1;


    public string nextScene;

    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        GameStores.changeScene();
        Time.timeScale = 1;
        timer = 0;

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
        timer += Time.deltaTime;
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
                SceneManager.LoadSceneAsync(nextScene);
            }
        }
    }

    private void FixedUpdate()
    {
        
    }
}
