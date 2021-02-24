using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Candy.Guns.Projectiles
{
    public class BaseExplosive : MonoBehaviour
    {
        [SerializeField] GameObject m_ExplosionFX;
        [SerializeField] AudioClip m_explosionSFX;

        public int m_ExplosionDamage = 5;

        protected void Setup() 
        {
            gameObject.tag = "Projectile";
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

        private void OnCollisionEnter(Collision collision)
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = m_explosionSFX;
            audioSource.Play();
            StartCoroutine(Explode());
        }
    }
}
