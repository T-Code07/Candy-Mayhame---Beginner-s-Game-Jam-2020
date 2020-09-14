using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    //Enemies:
    [SerializeField] TextMeshProUGUI m_EnemyNumbersText;

    //Health:
    [SerializeField] TextMeshProUGUI m_healthText;
    [SerializeField] TextMeshProUGUI m_gameStatusText;

    //Menu:
    [SerializeField] GameObject m_menu;
    [SerializeField] int m_restartScene = 0;
    [SerializeField] int m_MainMenu = 1;
    [SerializeField] TextMeshProUGUI m_mainMenuText;
    [SerializeField] GameObject m_creditsCanvas;

    //Muted:
    [SerializeField] TextMeshProUGUI m_mutedText;
    [SerializeField] float m_showMuteTextTime = 3f;

    //Audio:
    [SerializeField] Music_Player m_musicPlayer;

    //General:
    public bool m_isPlayerDead = false;
    private bool m_isPaused = false;

    private void Start()
    {
        Time.timeScale = 1f;
        m_mutedText.enabled = false;
        m_gameStatusText.enabled = false;
        m_menu.active = false;
        m_mainMenuText.enabled = false;
       m_creditsCanvas.active = false;
    }
    private void Update()
    {
        if (m_isPlayerDead == true)
        {
           
            ChangeGameStatusText("You Died");
            
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (m_isPaused)
            {
                m_isPaused = false;
                Time.timeScale = 1f;
                m_menu.active = false;
                m_mainMenuText.enabled = false;
                m_musicPlayer.playMainTrack();
            }
            else
            {
                m_isPaused = true;
                Time.timeScale = 0f;
                m_menu.active = true;
                m_mainMenuText.enabled = true;
                m_musicPlayer.playMenuTrack();
            }
        }
       
    }

    public void ShowCredits()
    {
        m_creditsCanvas.active = true;
        gameObject.active = false;
        
    }

    public void ChangeGameStatusText(string newText)
    {
        m_menu.active = true;
        m_gameStatusText.enabled = true;
        m_gameStatusText.text = newText;

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

    public void EnemyNumberTextUpdate(int newEnemyNumber)
    {
        m_EnemyNumbersText.text = "Number of Enemies: " + newEnemyNumber.ToString();
        print("Updating new numbers");
    }
}
