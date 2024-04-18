using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseBtn;
    public GameObject gameOverPanel;
    public GameObject endText;

    public static GameController Instance;
    // Start is called before the first frame update

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        Time.timeScale = 1;
        // pauseMenu.SetActive(false);
        // pauseBtn.SetActive(true);
        
        gameOverPanel.SetActive(false);
        endText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PauseGame()
    {
        //pauseMenu.SetActive(true);
        ScreensManager.Instance.ShowScreen(ScreenType.GAME_PAUSE);
        Time.timeScale = 0;
        pauseBtn.SetActive(false);
    }
    public void ResumeButton()
    {
        //pauseMenu.SetActive(false);
        ScreensManager.Instance.ShowScreen(ScreenType.HOME);
        Time.timeScale = 1;
        pauseBtn.SetActive(true);
    }
    public void QuitButton()
    {
        Application.Quit(); 
    }
    public void GameOver()
    {
        //gameOverPanel.SetActive(true);
        ScreensManager.Instance.ShowScreen(ScreenType.GAME_OVER);
        pauseBtn.SetActive(false);
    }
    public IEnumerator LevelComplete()
    {
        yield return new WaitForSeconds(2f);
        endText.SetActive(true);
       
        yield return new WaitForSeconds(4f);
        ScreensManager.Instance.ShowScreen(ScreenType.GAME_COMPLETE);
        Time.timeScale = 0;

    }
}
