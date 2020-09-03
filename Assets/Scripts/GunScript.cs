using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField] GameObject m_shootPoint;
    [SerializeField] float m_bulletSpeed = 1000f;
    [SerializeField] List<GameObject> m_gumballList = new List<GameObject>();
    [SerializeField] float destroyBulletTime = 10f;

    public void ShootGun()
    {
        CreateBullet();
    }

 

    private void CreateBullet()
    {
        var random = new System.Random();
        GameObject newGumball = Instantiate(m_gumballList[random.Next(m_gumballList.Count)], m_shootPoint.transform.position, Quaternion.identity);
        newGumball.AddComponent<Rigidbody>();
        newGumball.GetComponent<Rigidbody>().AddForce(m_shootPoint.transform.forward * m_bulletSpeed);
        newGumball.GetComponent<Rigidbody>().useGravity = false;
        Destroy(newGumball, destroyBulletTime);
    }

   

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(m_shootPoint.transform.position, m_shootPoint.transform.forward );
    }
}
