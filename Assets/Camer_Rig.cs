using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camer_Rig : MonoBehaviour
{
    [SerializeField] Transform m_playerPosition; 
    
    void Update()
    {
        transform.position = m_playerPosition.position;
    }
}
