using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float m_healthPoints = 100f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            Gumball projectileScript = other.gameObject.GetComponent<Gumball>();

            DecreaseHealth(projectileScript.m_ExplosionDamage);
            print(name + ": has been hit. Health: " + m_healthPoints.ToString());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
            Gumball projectileScript = collision.gameObject.GetComponent<Gumball>();

            DecreaseHealth(projectileScript.m_ExplosionDamage);
            print(name + ": has been hit. Health: " + m_healthPoints.ToString());
        }
    }

    

    public void DecreaseHealth(int damage)
    {
        m_healthPoints -= damage;
    }
}
