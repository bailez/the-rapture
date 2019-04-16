using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    bool paused;
    public GameObject pausePannel, goPanel, pauseButton, backButton;
    
    void Start()
    {
        
        paused = false;
    
    }

    public void GameOver()
    {
        pauseButton.SetActive(false);
        goPanel.SetActive(true);
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("LevelGameplay");
       
    }

    public void Back()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
    public void Pause()
    {
        
        if (!paused)
        {
            pausePannel.SetActive(true);
            Time.timeScale = 0;
            paused = true;
        }
       else
        {
            pausePannel.SetActive(false);
            Time.timeScale = 1;
            paused = false; 
        } 
    }
    public bool Paused()
    {
        return paused;
    }
}
