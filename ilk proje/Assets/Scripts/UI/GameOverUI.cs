using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    
    public void restartButton()
    {
        SceneManager.LoadScene(1);
    }
    public void MainMenu_btn()
    {
        SceneManager.LoadScene("UImenu");
    }
  public void exitButton()
    {
        Application.Quit();
    }
    
}
