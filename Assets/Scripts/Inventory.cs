using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public float waterQuantity = 100;
    public float waterMax = 100;
    public float waterLoss = 1;
    public int bread;
    public int levelBread;

    private PlayerMovement mover;
    private CharacterController2D controller;

    public float boostDuration = 4.5f;

    // Start is called before the first frame update
    void Start()
    {
        mover = gameObject.GetComponent<PlayerMovement>();
        controller = gameObject.GetComponent<CharacterController2D>();
        waterQuantity = waterMax;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameStores.BreadQuantity < 0)
        {
            GameStores.BreadQuantity = 0;
        }
        if (Input.GetButtonDown("Boost") && GameStores.BreadQuantity > 0)
        {
            mover.boost(boostDuration);
            controller.boost(boostDuration);
            GameStores.BreadQuantity -= 1;
            GameStores.levelBread -= 1;
        }
        if(waterQuantity < 0)
        {
            controller.die();
        }
    }

    public void refillWater()
    {
        waterQuantity = waterMax;
    }

    public void changeWater(float change)
    {
        waterQuantity += change;
    }

    public void changeBread(int change)
    {
        GameStores.BreadQuantity += change;
    }

    public void FixedUpdate()
    {
        waterQuantity -= waterLoss * Time.deltaTime;
    }
}
