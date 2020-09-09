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
        try
        {
            float distanceToPlayer = Vector3.Distance(transform.position, m_playerObject.transform.position);
            if (distanceToPlayer <= m_attackDistance)
            {
                m_Animator.SetTrigger("isRunning");
                transform.LookAt(m_playerObject.transform.position);
                // transform.rotation = Quaternion.Slerp(transform.rotation, lookAt, m_rotationSpeed);
                m_navMeshAgent.SetDestination(m_playerObject.transform.position);


                //Stop running animator
                if (m_navMeshAgent.stoppingDistance >= distanceToPlayer)
                {
                }
                //Gun Shoots in animation.
                m_Animator.SetTrigger("Shoot");

            }
        }
        catch (MissingReferenceException)
        {
            Debug.LogWarning("Enemy AI: Player is missing in scene.");

        }

    }

    //Called in Animation Event
    public void CallGunShot()
    {
        try
        {
            m_gun.ShootGun(m_playerObject.transform);
        }
        catch (MissingReferenceException)
        {
            Debug.LogWarning("Enemy AI (Animation): Player is missing in scene.");

        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, m_attackDistance);
    }

}
