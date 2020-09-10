using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Music_Player : MonoBehaviour
{
    [SerializeField] AudioClip m_mainTrack;
    [SerializeField] AudioClip m_menuTrack;
    private AudioSource m_audioSource;
    
    private void Start()
    {
        Object.DontDestroyOnLoad(gameObject);
        m_audioSource = GetComponent<AudioSource>();
        m_audioSource.loop = true;
        playMainTrack();
    }

    public void playMainTrack()
    {

        m_audioSource.clip = m_mainTrack;
        m_audioSource.Play();

    }

    public void playMenuTrack()
    {

        m_audioSource.clip = m_menuTrack;
        m_audioSource.Play();
    }
}
