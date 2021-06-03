using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Candy.Guns.Projectiles;

namespace Candy.Guns
{
    public class MissileLauncher : BasicLauncher
    {
        //Maybe: have lists of different types of item? 
        //       then incorprate them into where they are in 
        [SerializeField] public GameObject m_shootPoint;
        [SerializeField] GameObject m_missile;
        [SerializeField] float m_destroyBulletTime = 10f;
        [SerializeField] int m_maxCurrentBullets = 100;
        [SerializeField] AudioClip m_gunSFX;
        [SerializeField] bool m_isPlayer = false;

        private bool m_isShooting = false;
        private Transform m_target;
        private List<GameObject> m_currentBullets = new List<GameObject>();

 

         public Transform Target 
         {
             get { return m_target; }
             set { m_target = value; }
         }



        override protected void ShootLauncher(Transform target)
        {

            m_target = target;
            B_target = m_target;
            CreateBullet();
            m_isShooting = true;
        }

        


        private void CreateBullet()
        {
            if (m_currentBullets.Count <= m_maxCurrentBullets)
            {
                GameObject newMissile = Instantiate(m_missile, m_shootPoint.transform.position, Quaternion.identity);
                AudioSource audioSource = gameObject.AddComponent<AudioSource>();

                audioSource.PlayOneShot(m_gunSFX, .5f);

                newMissile.GetComponent<Missile>().TargetTransform = m_target;
                m_currentBullets.Add(newMissile);

                //todo: edit to make delete from list when destroyed.
                StartCoroutine(newMissile.GetComponent<Missile>().Explode(m_destroyBulletTime));
            }
        }



        private void OnDrawGizmos()
        {
            Gizmos.DrawLine(m_shootPoint.transform.position, m_shootPoint.transform.forward);

            try
            {
                Gizmos.DrawLine(gameObject.GetComponentInParent<PlayerController>().transform.position, m_shootPoint.transform.forward);
            }
            catch (NullReferenceException) { }

        }
    }
}
