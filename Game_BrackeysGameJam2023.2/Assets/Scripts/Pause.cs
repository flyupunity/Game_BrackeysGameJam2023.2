using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField]
    private KeyCode Tab;
    public GameObject pausePanel;
    void Update()
    {
        if(Input.GetKeyDown(Tab))
        {
            if (pausePanel.activeSelf)
            {
                pausePanel.SetActive(false);
                Time.timeScale = 1f;
                
            }
            else if (!pausePanel.activeSelf) 
            {
                pausePanel.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }
}
