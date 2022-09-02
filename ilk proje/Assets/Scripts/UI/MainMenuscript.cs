using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuscript : MonoBehaviour
{
    public void Play_btn()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit_btn()
    {
        Application.Quit();
    }
}
