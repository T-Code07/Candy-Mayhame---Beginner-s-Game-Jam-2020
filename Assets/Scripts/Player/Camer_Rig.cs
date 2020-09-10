using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camer_Rig : MonoBehaviour
{
    [SerializeField] Transform m_playerPosition;
    [SerializeField] UIManager m_UImanager;

    private Camera m_mainCamera;
    private bool m_isMuted = false;

    private void Start()
    {
        m_mainCamera = GetComponentInChildren<Camera>();
    }
    void Update()
    {
        try
        {
            transform.position = m_playerPosition.position;
        }
        catch (MissingReferenceException)
        {
            Debug.LogWarning("Camera Rig: Player is missing in scene.");
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            print("Muting now...");
            if (m_isMuted)
            {
                m_isMuted = false;
                
            }
            else
            {
                m_isMuted = true;
            }

           StartCoroutine(m_UImanager.MuteSoundTextDisplay(m_isMuted));
        }

        m_mainCamera.GetComponent<AudioListener>().enabled = !m_isMuted;

    }
}
