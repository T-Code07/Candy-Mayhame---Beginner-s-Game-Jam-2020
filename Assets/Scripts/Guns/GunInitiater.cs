using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Candy.Guns
{
    //Creating gun types in order be able to specify what type of gun class needs to be initiated.
    public enum GunType 
    {
        MISSILE_LAUNCHER,
        FLAME_THROWER,
        MACHINE_GUN
    }
    public class GunInitiater : MonoBehaviour
    {
        [SerializeField] GunType m_gunType;

        private BaseGunClass m_gunClass;

        private void Awake()
        {
            if(m_gunType == GunType.MISSILE_LAUNCHER) 
            {
                
            }
            else if(m_gunType == GunType.MACHINE_GUN) 
            {
                //create new machine gun
            }
            else if(m_gunType == GunType.FLAME_THROWER) 
            {
                //create flamethrower
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
