using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGunClass : MonoBehaviour
{
    private int m_bulletDamage = 1;
    private string m_gunName = "Basic Gun";

    BaseGunClass(int damage, string gun_name)
    {
        m_bulletDamage = damage;
        m_gunName = gun_name;
    }

    protected virtual void Shoot()
    {

    }

    protected virtual void Reload()
    {

    }
}
