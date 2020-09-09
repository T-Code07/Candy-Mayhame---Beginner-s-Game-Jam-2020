using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField] public GameObject m_shootPoint;
    [SerializeField] GameObject m_missile; 
    [SerializeField] float m_destroyBulletTime = 10f;
    [SerializeField] int m_maxCurrentBullets = 100;

    private bool m_isShooting = false;
    private Transform m_target;
    private List<GameObject> m_currentBullets = new List<GameObject>();
   
    private void Start()
    {
        StopShooting();
       
    }
    public void ShootGun(Transform target)
    {
        m_target = target;

        CreateBullet();
        m_isShooting = true;
    }
    
    public void StopShooting()
    {
        m_isShooting = false;
    }

    
    private void CreateBullet()
    {
        if (m_currentBullets.Count <= m_maxCurrentBullets)
        {
            GameObject newGumball = Instantiate(m_missile, m_shootPoint.transform.position, Quaternion.identity);
            newGumball.GetComponent<Gumball>().TargetTransform = m_target;
            m_currentBullets.Add(newGumball);

            //todo: edit to make delete from list when destroyed.
            StartCoroutine(newGumball.GetComponent<Gumball>().Explode(m_destroyBulletTime));
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
