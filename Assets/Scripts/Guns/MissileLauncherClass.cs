using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Candy.Guns {
    public class MissileLauncherClass : BaseGunClass
    {
        const string B_GUN_NAME = "Missile Launcher";
        [SerializeField] const int B_GUN_DAMAGE = 5;

        int m_gunDamage = 5;
        MissileLauncherClass(int damage = B_GUN_DAMAGE, string name = B_GUN_NAME) : base (damage, name)
        { }
        
    }
}
