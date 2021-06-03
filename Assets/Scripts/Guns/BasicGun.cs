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
        }
        //placeholder
        public abstract void ShootLauncher();


    }
}
