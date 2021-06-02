using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Candy.Guns
{
    public abstract class BasicLauncher : BasicGun
    {
       

      
        public override void ShootGun()
        {
            print("BasicLauncher: 'Shooting missiles'");
            ShootLauncher(B_target);
        }

        
        protected abstract void ShootLauncher(Transform target = null);
    }
}
