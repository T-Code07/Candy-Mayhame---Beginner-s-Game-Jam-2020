using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    //Health:
    [SerializeField] TextMeshProUGUI m_healthText;
    [SerializeField] TextMeshProUGUI m_deadText;

    //Menu:
    [SerializeField] GameObject m_menu;
    [SerializeField] int m_restartScene = 0;
    [SerializeField] int m_MainMenu = 1;
    [SerializeField] TextMeshProUGUI m_mainMenuText;

    //Muted:
    [SerializeField] TextMeshProUGUI m_mutedText;
    [SerializeField] float m_showMuteTextTime = 3f;

    //General:
    public bool m_isPlayerDead = false;
    private bool m_isPaused = false;

    private void Start()
    {
        Time.timeScale = 1f;
        m_mutedText.enabled = false;
        m_deadText.enabled = false;
        m_menu.active = false;
        m_mainMenuText.enabled = false;
    }
    private void Update()
    {
        if (m_isPlayerDead == true)
        {
            m_menu.active = true;
            m_deadText.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (m_isPaused)
            {
                m_isPaused = false;
                Time.timeScale = 1f;
                m_menu.active = false;
                m_mainMenuText.enabled = false;
            }
            else
            {
                m_isPaused = true;
                Time.timeScale = 0f;
                m_menu.active = true;
                m_mainMenuText.enabled = true;
            }
        }
       
    }

    public IEnumerator MuteSoundTextDisplay(bool isMuted)
    {
        m_mutedText.enabled = true;
        if (isMuted)
        {
            
            m_mutedText.text = "Muted";

        }
        else
        {
            m_mutedText.text = "Not Muted";
            yield return new WaitForSeconds(m_showMuteTextTime);
            m_mutedText.enabled = false;
        }
        print("Enumerator finished");
    }

    public void updateHealthText(string health)
    {
        m_healthText.text = health;
    }

    public void restartButton()
    {
        SceneManager.LoadScene(m_restartScene);
    
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(m_MainMenu);
    }
}
