using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_healthText;
    [SerializeField] GameObject m_menu;
    [SerializeField] int m_restartScene = 0;
    [SerializeField] int m_MainMenu = 1;
    public bool m_isPlayerDead = false;

    private void Start()
    {
        Time.timeScale = 1f;

    }
    private void Update()
    {
        if (m_isPlayerDead == true)
        {
            m_menu.active = true;
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
}
