using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gumball : MonoBehaviour
{
    [SerializeField] public float m_speed = 20f;
    [SerializeField] float m_focusDistance = 5f;
    private Transform m_targetTransform;
    private bool isLookingAtObject;
    private Rigidbody m_rigidBody;
    private bool m_hasErrored = false;
    private List<GameObject> m_groundObjects = new List<GameObject>();
    public Transform TargetTransform
    {
        get { return m_targetTransform; }
        set { m_targetTransform = value; }
    }

    public float Speed
    {
        get { return m_speed; }
        set { m_speed = value; }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        print("BOOM! " + gameObject.name + " is down.");
        Destroy(gameObject, 1f);
    }

    private void Start()
    {
        gameObject.tag = "Projectile";
        gameObject.AddComponent<Rigidbody>();

        m_rigidBody = GetComponent<Rigidbody>();
        m_rigidBody.useGravity = false;
        m_rigidBody.AddForce(transform.forward * m_speed);

    }


    private void FixedUpdate()
    {
        if (m_targetTransform == null)
        {
            m_rigidBody.AddForce(transform.forward * m_speed);
            Debug.Log("No transform exists on target.");
            return;
        }

        float distanceToTarget = Vector3.Distance(transform.position, m_targetTransform.position);



        if(distanceToTarget > m_focusDistance)
        {
            transform.LookAt(m_targetTransform);

            m_rigidBody.AddForce(transform.forward * m_speed);
        }
        
    }

}
