using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField] public GameObject m_shootPoint;
    [SerializeField] float m_bulletSpeed = 1000f;
    [SerializeField] GameObject m_missile; 
    [SerializeField] float m_destroyBulletTime = 10f;
    [SerializeField] bool m_isPlayer = false;
    [SerializeField] GameObject m_bulletFX;
    private bool m_isShooting = false;
    private Transform m_target;
   
    private void Start()
    {
        StopShooting();
       
    }
    public void ShootGun(Transform target = null)
    { 
        CreateBullet();
        m_target = target;
        m_isShooting = true;
    }
    
    public void StopShooting()
    {
        m_isShooting = false;
    }

    private void Update()
    {
//        m_bulletFX.active = m_isShooting;
    }

    private void CreateBullet()
    {
        GameObject newGumball = Instantiate(m_missile, m_shootPoint.transform.position, Quaternion.identity);
        newGumball.GetComponent<Gumball>().TargetTransform = m_target;


        newGumball.tag = "Projectile";
        newGumball.AddComponent<Rigidbody>();

        newGumball.GetComponent<Rigidbody>().AddForce(m_shootPoint.transform.forward * m_bulletSpeed);
      //  newGumball.GetComponent<Rigidbody>().useGravity = false;
        Destroy(newGumball, m_destroyBulletTime);
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
