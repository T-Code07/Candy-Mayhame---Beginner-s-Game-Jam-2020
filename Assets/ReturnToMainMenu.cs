using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToMainMenu : MonoBehaviour
{
    [SerializeField] GameObject m_mainCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void ShowMainCanvas()
    {
        m_mainCanvas.active = true;
        gameObject.active = false;
    }
}
