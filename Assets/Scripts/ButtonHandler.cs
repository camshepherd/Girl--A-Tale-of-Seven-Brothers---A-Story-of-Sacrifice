using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    private Text text;
    private Button button;

    public void GoToScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void payBread(int quantity)
    {
        if(GameStores.BreadQuantity >= 0)
        {
            GameStores.BreadQuantity -= quantity;
        }
        else
        {
            GameStores.BreadQuantity = 0;
        }
    }


    public void Choice2Continue()
    {
        if(GameStores.Choice1 == 2)
        {
            SceneManager.LoadSceneAsync("Sun 2");
        }
        else
        {
            SceneManager.LoadSceneAsync("Moon 2");
        }
    }

    public void Choice1(int value)
    {
        GameStores.Choice1 = value;
    }
    public void Choice2(int value)
    {
        GameStores.Choice2 = value;
    }
    public void Choice3(int value)
    {
        GameStores.Choice3 = value;
    }
    public void Choice4(int value)
    {
        GameStores.Choice4 = value;
    }

    public void setChoice(int choice, int value)
    {
        //int value = 2;
        if(choice == 1)
        {
            GameStores.Choice1 = value;
        }
        else if(choice == 2)
        {
            GameStores.Choice2 = value;
        }
        else if(choice == 3)
        {
            GameStores.Choice3 = value;
        }
        else if(choice == 4)
        {
            GameStores.Choice4 = value;
        }
    }
}