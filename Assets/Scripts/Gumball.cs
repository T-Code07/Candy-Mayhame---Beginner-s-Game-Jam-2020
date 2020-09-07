using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gumball : MonoBehaviour
{
    [SerializeField] public float m_speed = 8000f;
    [SerializeField] float m_focusDistance = 5f;
    private Transform m_targetTransform;
    private bool isLookingAtObject;
    private Rigidbody m_rigidBody;

    public Transform TargetTransform
    {
        get { return m_targetTransform; }
        set { value = m_targetTransform; }
    }

    public float Speed
    {
        get { return m_speed; }
        set { value = m_speed; }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject, 1f);
    }

    private void Start()
    {
        m_rigidBody = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        if (m_targetTransform == null)
        {
            print("Gun isn't shooting at anything.");
            return;
        }

        float distanceToTarget = Vector3.Distance(transform.position, m_targetTransform.position);
        transform.LookAt(m_targetTransform);

       // if(distanceToTarget >= m_focusDistance || distanceToTarget <= m_focusDistance)
        //{
            m_rigidBody.AddForce(transform.forward * m_speed);
        //}
    }
    private void Update()
    {
        
        
    }
}
