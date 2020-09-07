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
  //  private List<GameObject> 
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
    //    Destroy(gameObject, 1f);
    }

    private void Start()
    {
        m_rigidBody = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        print("Fixed Update: " + m_targetTransform.ToString());
        if (m_targetTransform == null)
        {
            print("Gun isn't shooting at anything. has errored: " + m_hasErrored.ToString());
            
            m_hasErrored = true;
            return;
        }

        float distanceToTarget = Vector3.Distance(transform.position, m_targetTransform.position);

        //   transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(m_targetTransform.position), m_speed * Time.deltaTime);

      //  GameObject ground = ReturnGround();

        if(distanceToTarget > m_focusDistance)
        {
            transform.LookAt(m_targetTransform);

            m_rigidBody.AddForce(transform.forward * m_speed);
        }
    //    if(Vector3.Distance(transform.position, )
        
    }

//    private GameObject ReturnGround()
  //  {
    //    foreach (GameObject groundItem in ) ;
    //}

    private void Update()
    {
        print("Update: " + m_targetTransform.ToString());
        
    }
}
