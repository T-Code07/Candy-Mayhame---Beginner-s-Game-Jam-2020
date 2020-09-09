using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camer_Rig : MonoBehaviour
{
    [SerializeField] Transform m_playerPosition; 
    
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
    }
}
