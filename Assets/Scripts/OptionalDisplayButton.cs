using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionalDisplayButton : MonoBehaviour
{
    public Button button;
    public int paymentQuantity;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        if(GameStores.BreadQuantity < paymentQuantity)
        {
            button.interactable = false;
            //gameObject.GetComponent<Text>().color = Color.black;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStores.BreadQuantity < paymentQuantity)
        {
            button.interactable = false;
            text.color = Color.black;
        }
        else if(GameStores.BreadQuantity >= paymentQuantity)
        {
            button.interactable = true;
            text.color = Color.white;
        }
    }
}
