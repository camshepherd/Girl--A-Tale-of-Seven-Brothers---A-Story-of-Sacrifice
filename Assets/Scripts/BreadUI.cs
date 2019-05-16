﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreadUI : MonoBehaviour
{
    public Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        // gameObject.GetComponent<Text>().text = "X " + inventory.breadQuantity;
        gameObject.GetComponent<Text>().text = "X " + GameStores.BreadQuantity;
    }
}
