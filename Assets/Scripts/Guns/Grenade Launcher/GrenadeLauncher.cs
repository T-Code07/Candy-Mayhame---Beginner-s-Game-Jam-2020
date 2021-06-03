using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Candy.Guns
{
    public class GrenadeLauncher : BasicLauncher
    {
        [SerializeField] GameObject m_grenade;
        [SerializeField] float m_grenadeLaunchSpeedY = 15.0f;
        [SerializeField] float m_grenadeLaunchSpeedForward = 15.0f;
        [SerializeField] Transform m_grenadeLaunchPoint; 
        void Start()
        {
        }

        
        void Update()
        {

        }

        protected override void ShootLauncher(Transform target) 
        {
            
            GameObject grenade = Instantiate(m_grenade, m_grenadeLaunchPoint.position, Quaternion.identity);

            Rigidbody grenadeRigidbody = grenade.GetComponent<Rigidbody>();


            grenadeRigidbody.AddForce(new Vector3(m_grenadeLaunchSpeedForward, m_grenadeLaunchSpeedY, 0), ForceMode.Impulse);
        }

    }
}
