using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScene5Controller : MonoBehaviour
{
    public Canvas[] canvas;
    public int n;
    private float sceneTransition = 0.3f;
    public float stop_n = -1;


    public string nextScene;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        GameStores.changeScene();
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
            else if(GameStores.Choice3 == 2)
            {
                // Has key
                SceneManager.LoadSceneAsync(nextScene[1]);
            }
            else
            {
                // Does not have key
                SceneManager.LoadSceneAsync(nextScene[0]);
            }
        }
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
    }
}
