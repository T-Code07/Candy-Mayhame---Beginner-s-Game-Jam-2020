using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Candy.Guns
{
    /// <summary>
    /// To make common item for controllers to use. 
    /// </summary>
    public abstract class BasicGun : MonoBehaviour
    {
        public Transform B_target;
        private void Awake()
        {
            B_target = gameObject.transform;
            print("This is from Base Gun: " + B_target.position);
        }
        //placeholder
        public abstract void ShootGun();


    }
}
