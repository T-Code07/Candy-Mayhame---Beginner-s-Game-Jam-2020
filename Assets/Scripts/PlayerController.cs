using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool m_isIdle = true;
    private bool m_isRunning = false;
    private Animator m_animator;
    [SerializeField] float m_Speed = 7f;
    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isIdle)
        {
            m_animator.SetBool("isRunning", !m_isIdle);
        }
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
         //   gameObject.transform.position = new Vector3();
        }
    }
}
