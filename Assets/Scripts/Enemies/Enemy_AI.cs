using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy_AI : MonoBehaviour
{

    [SerializeField] float m_attackDistance = 10f;
    [SerializeField] float m_GunRecoil = 10f;
    [SerializeField] float m_rotationSpeed = 3f;
    [SerializeField] GunScript m_gun;
  //  [SerializeField] GameObject

    private GameObject m_playerObject;
    private Rigidbody m_rigidBody;
    private NavMeshAgent m_navMeshAgent;
    private Animator m_Animator;

    private void Start()
    { 
        m_playerObject = FindObjectOfType<PlayerController>().gameObject;
        m_rigidBody = GetComponent<Rigidbody>();
        m_navMeshAgent = GetComponent<NavMeshAgent>();
        m_Animator = GetComponent<Animator>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, m_playerObject.transform.position);
        if(distanceToPlayer <= m_attackDistance)
        {
         transform.LookAt(m_playerObject.transform.position);
           // transform.rotation = Quaternion.Slerp(transform.rotation, lookAt, m_rotationSpeed);
            m_navMeshAgent.SetDestination(m_playerObject.transform.position);


            //Gun Shoots in animation.
            m_Animator.SetTrigger("Shoot");
        }
    
    }

    //Called in Animation Event
    public void CallGunShot()
    {
        m_gun.ShootGun();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, m_attackDistance);
    }

}
