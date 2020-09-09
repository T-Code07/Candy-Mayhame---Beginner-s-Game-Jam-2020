using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float m_healthPoints = 100f;
    [SerializeField] GameObject m_deathFX;
    [SerializeField] bool m_isEnemy = true;
   

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
            Gumball projectileScript = collision.gameObject.GetComponent<Gumball>();

            DecreaseHealth(projectileScript.m_ExplosionDamage);
            print(name + ": has been hit. Health: " + m_healthPoints.ToString());
        }
    }


    private void Update()
    {
         if(m_healthPoints <= 0)
        {
            GameObject newDeathFX = Instantiate(m_deathFX, gameObject.transform.position, Quaternion.identity);
            Destroy(newDeathFX, 2f);

         
            if (m_isEnemy)
            {
                Destroy(gameObject.GetComponentInParent<Enemy_AI>().gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }


    
    private void DecreaseHealth(int damage)
    {
        
        m_healthPoints -= damage;

    }
}
