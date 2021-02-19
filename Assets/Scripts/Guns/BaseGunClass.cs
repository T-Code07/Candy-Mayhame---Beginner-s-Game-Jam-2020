using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Candy.Guns
{
    public class BaseGunClass : MonoBehaviour
    {
        private int m_bulletDamage = 1;
        private string m_gunName = "Basic Gun";
        private int m_ammo_number = 100;

        protected const int BASE_AMMO_NUMBER = 100;

        BaseGunClass(int damage, string gun_name, int ammo_number = BASE_AMMO_NUMBER)
        {
            m_bulletDamage = damage;
            m_gunName = gun_name;
        }

        protected virtual void Shoot()
        {
            if (m_ammo_number <= 0) return;
            m_ammo_number--;

            //pew pew
        }

        protected virtual void Reload()
        {
            //Cover me!
        }
    }
}
