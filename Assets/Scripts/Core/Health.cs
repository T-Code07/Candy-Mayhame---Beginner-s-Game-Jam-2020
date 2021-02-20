using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using UnityEngine.UI;
using Candy.Guns.Projectiles;
[RequireComponent(typeof(AudioSource))]
public class Health : MonoBehaviour
{
    public bool m_pLayerIsDead = false;

    [SerializeField] float m_healthPoints = 100f;
    [SerializeField] GameObject m_deathFX;
    [SerializeField] bool m_isEnemy = true;
    [SerializeField] AudioClip m_deathSX;
    [SerializeField] UIManager m_UIManager;

    private AudioSource m_audioSource;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
            Missile projectileScript = collision.gameObject.GetComponent<Missile>();

            DecreaseHealth(projectileScript.m_ExplosionDamage);
           
        }
    }

    private void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
       

    }


    private void Update()
    {

        if (!m_isEnemy)
        {
            m_UIManager.updateHealthText(m_healthPoints.ToString());
        }
        if (m_healthPoints <= 0)
        {

            GameObject newDeathFX = Instantiate(m_deathFX, gameObject.transform.position, Quaternion.identity);
           
            Destroy(newDeathFX, 2f);

         
            if (m_isEnemy)
            {
                m_audioSource.clip = m_deathSX;
                m_audioSource.Play();
                Destroy(gameObject.GetComponentInParent<Enemy_AI>().gameObject);
            }
            else
            {
                m_audioSource.PlayOneShot(m_deathSX);
                FindObjectOfType<GameManager>().GamePlayed = true;

             
                m_audioSource.Stop();
                m_pLayerIsDead = true;
               // Destroy(gameObject);
            }
        }
    }


    
    private void DecreaseHealth(int damage)
    {
        
        m_healthPoints -= damage;

    }
}
