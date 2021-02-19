using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] public float m_speed = 20f;
    [SerializeField] float m_focusDistance = 5f;
    [SerializeField] GameObject m_ExplosionFX;
    [SerializeField] float m_takeOffTime = 2f; //Time to get out of range of shooter so that doesn't hit them.
    [SerializeField] AudioClip m_explosionSFX;

    public  int m_ExplosionDamage = 5;
    private Transform m_targetTransform;
    private Rigidbody m_rigidBody;
    private bool m_hasTakenOff = false;

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

  
    private void Start()
    {
        gameObject.tag = "Projectile";
        gameObject.AddComponent<Rigidbody>();

        m_rigidBody = GetComponent<Rigidbody>();
        GetComponent<Collider>().enabled = false;

        m_rigidBody.useGravity = false;
        m_rigidBody.AddForce(transform.forward * m_speed);

    }

    //In Coroutine form so that can be called from gunscript 10sec after launch.
    public IEnumerator Explode(float timeToDestroy = 0f)
    {
      //Wait for time to destroy
        yield return new WaitForSeconds(timeToDestroy);

        GameObject explosionFX = null;
        //Create explosion FX

        try { explosionFX = Instantiate(m_ExplosionFX, transform.position, Quaternion.identity); } catch { }

        try { Destroy(explosionFX, 2f); } catch { }

        //Destroy
        try { Destroy(gameObject); } catch { }
    }

    private void FixedUpdate()
    {
        //If there isn't a target, error and return.
        if (m_targetTransform == null)
        {
            m_rigidBody.AddForce(transform.forward * m_speed);
            Debug.Log("No transform exists on target.");
            return;
        }

        //Calculate distance.
        float distanceToTarget = Vector3.Distance(transform.position, m_targetTransform.position);

        //If distance to target is > focus distance, rotate towards and move forward.
        if(distanceToTarget > m_focusDistance)
        {
            transform.LookAt(m_targetTransform);

            m_rigidBody.AddForce(transform.forward * m_speed);
        }
        
    }

    private void Update()
    {
        if (!m_hasTakenOff)
        {
            StartCoroutine(TakeOff());
        }
    }

    //Counts down take off time to make sure bullets don't explode when hitting shooter immediatly. 
    private IEnumerator TakeOff()
    {
        yield return new WaitForSeconds(m_takeOffTime);
        m_hasTakenOff = true;
        GetComponent<Collider>().enabled = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Checks to make sure missile has taken off.
        //      if (!m_hasTakenOff) return;

        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = m_explosionSFX;
        audioSource.Play();
        StartCoroutine(Explode());

    }


}
