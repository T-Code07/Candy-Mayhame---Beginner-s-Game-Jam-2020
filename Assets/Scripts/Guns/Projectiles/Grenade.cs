using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Candy.Guns.Projectiles
{
    public class Grenade : BaseExplosive
    {
        [SerializeField] float m_explosionWait = 3f;

        void Start()
        {
            Explode(m_explosionWait);
        }
    }
}
