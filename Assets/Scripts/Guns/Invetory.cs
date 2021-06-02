using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Candy.Guns.System //namespace for background scripts for guns.
{

    public class PlayerInvetory : MonoBehaviour
    {
        public Dictionary<int, MonoBehaviour> m_invetoryArray = new Dictionary<int, MonoBehaviour>(); //Will be organzied by number (keypad) to objects' scipts. EX: Hit key 1, flamethrower is selected
        [SerializeField] int m_invetoryMaxCap = 3; //max invetory capacity
        private int m_currentSelected; //currently selected in invetory
        [SerializeField] GameObject gunArm; 
     
        void Start()
        {
            BasicGun gun = gunArm.GetComponentInChildren<BasicGun>();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}