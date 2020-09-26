using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LoadInEffect : MonoBehaviour
{
    [SerializeField] float m_fadeInTime = 2.5f;
    [SerializeField] float m_waitTime = 2f;
    [SerializeField] TextMeshProUGUI m_gameModeText;
    [SerializeField] TextMeshProUGUI m_loadingText;

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
        StartCoroutine(FadeIn(FindObjectOfType<GameManager>().LevelTypeString));

    }

    public IEnumerator FadeIn(string levelTypeString)
    {
        m_gameModeText.text = levelTypeString;
        m_loadingText.enabled = true;

        yield return new WaitForSeconds(m_waitTime);
        m_loadingText.enabled = false;

        while (m_canvasGroup.alpha > 0)
        {
            m_canvasGroup.alpha -= Time.deltaTime / m_fadeInTime;
            if(m_canvasGroup.alpha <= .2)
            {
                m_isFaded = true;

            }
            yield return null;// runs next frame.
            
        }
    }


}
