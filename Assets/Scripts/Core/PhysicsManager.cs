using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsManager : MonoBehaviour
{
    [Tooltip("9.81 is the value of Earth's Gravity and is the default value for this game.")] [SerializeField] float m_gravity = 9.81f;

    private void FixedUpdate()
    {
        Physics.gravity = new Vector3(0, -m_gravity, 0);

    }
}
