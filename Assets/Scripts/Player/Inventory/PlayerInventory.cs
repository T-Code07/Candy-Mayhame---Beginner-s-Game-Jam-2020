﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Candy.Guns;

//Player Calls items
    //Invetory: What item being used?
    //Invetory: Use item

//Player selects different item
    //Invetory: What item being used?
    //Invetory: What item is next?
    //Invetory: Switch to this item

//Bumped_into_item_script: "Hey! New item has been picked up!"
    //Invetory: Do we have room?
        //Invetory: Does this item stack?
            //Invetory: Stack item
        //Invetory: Not enough room
            //reject item
        //Invetory: 
            //add item
            //Invetory: Assign number

namespace Candy.Inventory //namespace for background scripts for guns.
{
    public enum PlayerInventoryTypes 
    {
        WEAPON,
        HEALTH,

    }
    public class PlayerInventory : MonoBehaviour
    {
        public Dictionary<int, GameObject> m_inventoryMapWithObjects = new Dictionary<int, GameObject>(); //Will be organzied by number (keypad) to objects' scipts. EX: Hit key 1, flamethrower is selected
        private Dictionary<int, PlayerInventoryTypes> m_inventoryMapWithTypes = new Dictionary<int, PlayerInventoryTypes>(); //Will be used to tell type of object.
        [SerializeField] int m_inventoryMaxCap = 3; //max invetory capacity
        private int m_currentSelectedNumber; //currently selected in invetory
        private PlayerInventoryTypes m_currentSelectedItemTypes;
        [SerializeField] GameObject m_gunModel; //Under the gun model, all of the types of launching will be stored.
        BasicGun m_currentlySelectedGun;
        private Animator m_animator;


        void Start()
        {
           // addFirstWeapon();
            m_currentSelectedNumber = 1;
            
            foreach (BasicGun basicGun in m_gunModel.GetComponentsInChildren<BasicGun>()) 
            {
             
                print(basicGun.name);
                addNewItem(basicGun.gameObject, PlayerInventoryTypes.WEAPON);
          //      m_currentSelectedNumber = 1;
            }
          
            m_animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (Input.GetKeyDown("1")) 
            {
                
                m_currentSelectedNumber = 1;
                
            }
            else if (Input.GetKeyDown("2")) 
            {
                m_currentSelectedNumber = 2;
            }
            else if (Input.GetKeyDown("3"))
            {
                m_currentSelectedNumber = 3;
            }
            print("Current Number Selected: " + m_currentSelectedNumber);
            try { m_currentSelectedItemTypes = m_inventoryMapWithTypes[m_currentSelectedNumber]; }
            catch 
            {
                print("No item available");
            }

           for(int i = 1; i <= 4; i++) 
            {
                print(i);
                //return if this number is selected
                if (i == m_currentSelectedNumber)
                {
                    //Make sure currently in use item is active. 
                    m_inventoryMapWithObjects[i].SetActive(true);
                }
                else
                {
                    //Disable all items that aren't selected. 
                    m_inventoryMapWithObjects[i].SetActive(false);
                }

            }

          
        }

        private void addFirstWeapon() 
        {
            addNewItem(m_currentlySelectedGun.gameObject, PlayerInventoryTypes.WEAPON);
           // m_inventoryMapWithObjects.Add(1, m_gun);
            //m_inventoryMapWithTypes.Add(1, PlayerInventoryTypes.WEAPON);
          
        }

        private void addNewItem(GameObject item, PlayerInventoryTypes itemType) 
        {
            if (m_inventoryMapWithObjects.Count >= 3) return;

            int nextOpenSlot;
            if (m_inventoryMapWithObjects.Count == 0)
            {
                nextOpenSlot = 1;
            }
            else
            {
                nextOpenSlot = m_inventoryMapWithObjects.Count + 1;
            }
            
            m_inventoryMapWithObjects.Add(nextOpenSlot, item);


            m_inventoryMapWithTypes.Add(nextOpenSlot, itemType);

        }

        public void UseCurrentlySelected() 
        {
            
            m_currentSelectedItemTypes = m_inventoryMapWithTypes[m_currentSelectedNumber];
           if(m_currentSelectedItemTypes == PlayerInventoryTypes.WEAPON) 
            {
                Debug.Log("Using Gun");

                //Animation triggers shooting.
                m_animator.SetTrigger("Shoot");
                RaycastToTarget();
               
                
            }
        }


        //Called in Animation event.
        public void CallGunShootingMethod()
        {
          
            m_currentlySelectedGun.ShootLauncher();
        }

        private void RaycastToTarget() 
        {
            Transform targetTransform;
            bool raycastHasHit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            bool hasHit = Physics.Raycast(ray, out hit);
            print(hit.transform.name);
            try { transform.LookAt(hit.transform.position); } catch { }

            if (hasHit)
            {
                targetTransform = hit.transform;
                print(targetTransform.position);
                m_currentlySelectedGun.B_target = targetTransform;
                print("Gun target position: " + m_currentlySelectedGun.B_target.position);
                //player clicked himself.
                if (hit.transform.tag == "Player") return;

                if (hit.transform.tag == "Enemy")
                {
                    raycastHasHit = true;
                    Enemy_AI enemy = hit.transform.GetComponent<Enemy_AI>();
                    targetTransform = enemy.transform;
                }
                else { raycastHasHit = false; }
            }
        }

    }
}