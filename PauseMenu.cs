using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    //get scene for hiding UI
    string sceneName;


    public bool canPause=true;
    
    public  bool gamePaused = false;
    public bool isChosing = false;
    public GameObject pauseMenuUI;
    public int currentSceneIndex;

    //buttons and texts
    public GameObject resumeButton;
    public GameObject optionsButton;
    public GameObject menuButton;
    public GameObject quitButton;


    private void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)&&(canPause))
        {
            if(gamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        
        Time.timeScale = 1f;
        gamePaused = false;
    }

    public void Pause()
    {
        
        pauseMenuUI.SetActive(true);
     
        Time.timeScale = 0f;
        gamePaused = true;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
        SceneManager.LoadScene("Menu");
    }
    public void NextLevel()
    {
        Time.timeScale = 1f;
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", currentSceneIndex+1);
        SceneManager.LoadScene(PlayerPrefs.GetInt("SavedScene"));
    }
    public void RestartLevel()
    {
        Time.timeScale = 1f;
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
        SceneManager.LoadScene(PlayerPrefs.GetInt("SavedScene"));
    }




    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void Chosing()
    {
        isChosing = true;
    }
    public void Chosing2()
    {
        isChosing = false;
    }
}
