using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    public float walkSpeed = 40f;
    public float runSpeed = 80f;

    float horizontalMove = 0f;
    float horizontalRun = 0f;

    private float moveModifier = 1;
    public float boostModifier = 1.7f;
    bool jump = false;
    bool run = false;
    private bool boosted = false;

    float boostEnd = 0;
    float boostTimer = 0;

    public GameObject boostEffect;
    private GameObject activeBoostEffect;

    public float minimumHeight = -10;

    // Update is called once per frame
    void Update()
    {
        if (boosted)
        {
            activeBoostEffect.transform.position = transform.position;
            activeBoostEffect.transform.rotation = transform.rotation;
        }
        boostTimer += Time.deltaTime;
        if (boostTimer >= boostEnd)
        {
            boosted = false;
            moveModifier = 1;
            Destroy(activeBoostEffect);
        }

        horizontalMove = Input.GetAxisRaw("Horizontal") * walkSpeed * moveModifier;
        horizontalRun = Input.GetAxisRaw("Horizontal") * runSpeed * moveModifier;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove * moveModifier));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Run") && !animator.GetBool("IsJumping"))
        {
            run = true;
            animator.SetFloat("Speed", Mathf.Abs(horizontalRun * moveModifier));
        }
        else if (Input.GetButtonUp("Run"))
        {
            run = false;
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove * moveModifier));
        }
        if(transform.position.y < minimumHeight || Input.GetButtonDown("Restart"))
        {
            controller.die();
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        // Move our character
        if (run == false)
        {
            controller.Move(moveModifier * horizontalMove * Time.fixedDeltaTime, false, jump);
            jump = false;
        }else if(run == true)
        {
            controller.Move(moveModifier * horizontalRun * Time.fixedDeltaTime, false, jump);
            jump = false;
        }
    }

    public void boost(float duration)
    {
        Destroy(activeBoostEffect);
        boosted = true;
        boostEnd = duration;
        boostTimer = 0;
        moveModifier = boostModifier;
        activeBoostEffect = Instantiate(boostEffect, transform.position, transform.rotation);
        activeBoostEffect.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
    }
    public void sleep()
    {
        run = false;
        jump = false;
        //controller.enabled = false;
        
        Time.timeScale = 0;
        animator.enabled = false;
        
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, gameObject.GetComponent<Rigidbody2D>().velocity.y, 0);
    }

    public void Awake()
    {
        Time.timeScale = 1;
    }
}
