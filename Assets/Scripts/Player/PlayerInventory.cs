using System.Collections;
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
        public Dictionary<int, object> m_inventoryMapWithObjects = new Dictionary<int, object>(); //Will be organzied by number (keypad) to objects' scipts. EX: Hit key 1, flamethrower is selected
        private Dictionary<int, PlayerInventoryTypes> m_inventoryMapWithTypes = new Dictionary<int, PlayerInventoryTypes>(); //Will be used to tell type of object.
        [SerializeField] int m_inventoryMaxCap = 3; //max invetory capacity
        private int m_currentSelectedNumber; //currently selected in invetory
        private PlayerInventoryTypes m_currentSelectedItemTypes;
        [SerializeField] GameObject m_gunArm;
        BasicGun m_gun;
     
        void Start()
        {
            if(m_gun)
             m_gun = m_gunArm.GetComponentInChildren<BasicGun>();
            InventoryList();
            m_currentSelectedNumber = 1;
           
        }

        private void InventoryList() 
        {
            m_inventoryMapWithObjects.Add(1, m_gun);
            m_inventoryMapWithTypes.Add(1, PlayerInventoryTypes.WEAPON);
          
        }
        
        public void UseCurrentlySelected() 
        {
            Transform targetTransform;
            bool raycastHasHit;
          
            m_currentSelectedItemTypes = m_inventoryMapWithTypes[m_currentSelectedNumber];
           if(m_currentSelectedItemTypes == PlayerInventoryTypes.WEAPON) 
            {
                Debug.Log("Using Gun");
                //  Ray ray = Physics.Raycast()
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit hit;
                bool hasHit = Physics.Raycast(ray, out hit);
                print(hit.transform.name);
                try { transform.LookAt(hit.transform.position); } catch { }

                if (hasHit)
                {
                    targetTransform = hit.transform;

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

                m_gun.ShootGun();
            }
        }


    }
}