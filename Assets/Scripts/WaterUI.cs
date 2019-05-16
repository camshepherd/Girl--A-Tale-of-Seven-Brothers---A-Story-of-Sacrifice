using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterUI : MonoBehaviour
{
    private Inventory inventory;
    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
        slider = gameObject.GetComponent<Slider>();
        slider.value = inventory.waterQuantity;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = inventory.waterQuantity;
    }
}
