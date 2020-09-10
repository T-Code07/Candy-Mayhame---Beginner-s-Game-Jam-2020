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

    //Menu:
    [SerializeField] GameObject m_menu;
    [SerializeField] int m_restartScene = 0;
    [SerializeField] int m_MainMenu = 1;

    //Muted:
    [SerializeField] TextMeshProUGUI m_mutedText;
    [SerializeField] float m_showMuteTextTime = 3f;

    //General:
    public bool m_isPlayerDead = false;

    private void Start()
    {
        Time.timeScale = 1f;
        m_mutedText.enabled = false;
    }
    private void Update()
    {
        if (m_isPlayerDead == true)
        {
            m_menu.active = true;
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
