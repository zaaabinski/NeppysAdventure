using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagment : MonoBehaviour
{
    [SerializeField] GameObject optionsMenu;
    [SerializeField] GameObject normalUI;
    [SerializeField] GrowFrog GF;
    [SerializeField] GameObject startUI;
    [SerializeField] GameObject cam;
    [SerializeField] GameObject playerUI;
    public bool Paused = false;
    private void Start()
    {
        Paused = true;
       // cam.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Level");
        Time.timeScale = 1f;
        
    }
    public void GoMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }
    private void Update()
    {
        if(Input.GetKeyDown("escape"))
        {
            PauseGame();
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void PauseGame()
    {
        if (!normalUI.activeInHierarchy&&!GF.gameWon)
        {
            normalUI.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0f;
            Paused = true;
        }
        else
        {
            normalUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
            Paused = false;
        }
    }
    public void Begin()
    {
        Paused = false;
        startUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        cam.SetActive(true);
        playerUI.SetActive(true);
        
    }
}
