using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LoadInEffect : MonoBehaviour
{
    [SerializeField] float m_fadeInTime = 2.5f;
    [SerializeField] TextMeshProUGUI m_gameModeText;
    private bool m_isFaded = false;
    CanvasGroup m_canvasGroup;

    public bool IsFaded
    {
        get { return m_isFaded; }
    }

    private void Start()
    {
        m_canvasGroup = GetComponent<CanvasGroup>();
        m_canvasGroup.alpha = 1;
    }
    public IEnumerator FadeIn(string gameModeText)
    {
        m_gameModeText.text = gameModeText;
        while (GetComponent<CanvasGroup>().alpha > 0)
        {
            m_canvasGroup.alpha -= Time.deltaTime / m_fadeInTime;
            yield return null;
        }
    }

   
}
