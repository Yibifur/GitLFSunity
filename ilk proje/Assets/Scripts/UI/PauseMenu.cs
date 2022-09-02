using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool isGamePaused;
    public GameObject pauseMenu;
    public AudioSource gameMusic;
    public GameObject settingsMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
           
            if (!isGamePaused)
            {
                PauseGame();
                
            }
            else
            {
                ResumeGame();
                
            }
        }
    }
    private void PauseGame()
    {
        Time.timeScale =0f;
        //disable playermovement
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = false; 
        //set cursor
        Cursor.visible=true;
        Cursor.lockState=CursorLockMode.None;
        //pause gamemusic
        gameMusic.Pause();
        //pause menu
        pauseMenu.SetActive(true);
        isGamePaused = true;
       
    }
    private void ResumeGame()
    {
        Time.timeScale = 1.0f;
        //enable playermovement
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled =true ;
        //set cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        //pause gamemusic
        gameMusic.UnPause();
        pauseMenu.SetActive(false);
        isGamePaused = false;
        
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene("UImenu");
    }
}
