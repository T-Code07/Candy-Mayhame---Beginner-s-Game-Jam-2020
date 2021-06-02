﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Candy.Guns;
using Candy.Inventory;


public class PlayerController : MonoBehaviour 
{
    [SerializeField] float m_Speed = 7f;
    [SerializeField] float m_rotationSpeed = 5f;
    [SerializeField] float m_jumpForce = 10f;
    [SerializeField] float m_sprintBoost = .2f;
    [SerializeField] BasicGun m_gun;  
    
    private bool m_isIdle = true;
    private bool m_isRunning = false;
    private Animator m_animator;
    private Rigidbody m_rigidBody;
    private bool m_isTouchingGround = true;
    private bool m_isSprinting = false;
    private bool m_isJumping = false;
    private bool m_raycastHasHit = false;
    private Transform m_targetTransform;
    private PlayerInventory m_playerInvetory;
    
    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_rigidBody = GetComponent<Rigidbody>();
        m_playerInvetory = GetComponent<PlayerInventory>();

    }

    private void FixedUpdate()
    {
        float speed = m_Speed;

        //Sprint
        if (Input.GetButton("Sprint"))
        {

            speed = m_Speed + (m_Speed * m_sprintBoost);
        }

        //Do movement
        Vector3 movemment = new Vector3(Input.GetAxis("Horizontal") * speed, m_rigidBody.velocity.y, Input.GetAxis("Vertical") * speed);

        
        //Rotate to direction
        if (!(movemment.x == 0f && movemment.z == 0f))
        {
            m_isIdle = true;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movemment), Time.deltaTime * m_rotationSpeed);
        }
        else
        {
            m_isIdle = false;
        }

        //Actually move character
        m_rigidBody.velocity = movemment;

        //Jump
        if (Input.GetButtonDown("Jump") && !m_isJumping)
        {

            m_rigidBody.AddForce(new Vector3(0, m_jumpForce, 0), ForceMode.Impulse);
            m_isTouchingGround = false;
            m_isJumping = true;
        }

        //Shoot
        if (Input.GetButtonDown("Fire1"))
        {
            m_playerInvetory.UseCurrentlySelected();
                m_animator.SetTrigger("Shoot");

            //Animation triggers shooting.
        }
     
   
        //Handle Jumping Animation:
        if (!m_isTouchingGround || transform.position.y > 1.5f)
        {
            m_animator.SetBool("isJumping", true);
        }
        else
        {
            m_animator.SetBool("isJumping", false);
            m_isJumping = false;
        }

    }

   

    private void OnCollisionEnter(Collision collision)
    {
        //8 is the ground
        if(collision.gameObject.layer == 8)
        {
            //Turn off jumping animation
            m_isTouchingGround = true;
        }
       
    }

    

    void Update()
    {
        //Update Animation depending on if the player is idle.
        m_animator.SetBool("isRunning", m_isIdle);

    }

  

    //Called in Animation event.
    public void CallGunShootingMethod()
    {
       
        m_gun.ShootGun();
    }
}
