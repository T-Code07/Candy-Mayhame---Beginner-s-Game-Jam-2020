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
    private WaitForSeconds m_waitObject;
    CanvasGroup m_canvasGroup;

    public bool IsFaded
    {
        get { return m_isFaded; }
    }

    private void Start()
    {
        m_waitObject = new WaitForSeconds(m_waitTime);
        m_canvasGroup = GetComponent<CanvasGroup>();
        m_canvasGroup.alpha = 1;
        StartCoroutine(FadeIn(FindObjectOfType<GameManager>().LevelTypeString));

    }

    public IEnumerator FadeIn(string levelTypeString)
    {
        float time = Time.deltaTime;
        m_gameModeText.text = levelTypeString;
        m_loadingText.enabled = true;

        yield return m_waitObject;
      //  while (!(Time.deltaTime - time >= m_waitTime))
       // {

            print("Waiting for player to read screen.");
            print(m_waitTime);
            print("Has it ended yet?");
            m_loadingText.enabled = false;
        //}

        m_canvasGroup.alpha = 1f;
        while (m_canvasGroup.alpha > 0)
        {
            print("Fading...");

            m_canvasGroup.alpha -= Time.deltaTime / m_fadeInTime;
            if(m_canvasGroup.alpha <= .2)
            {
                m_isFaded = true;

            }
            yield return null;// runs next frame.
            
        }
    }


}
