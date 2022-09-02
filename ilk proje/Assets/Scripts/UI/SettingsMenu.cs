using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SettingsMenu : MonoBehaviour
{
    public Slider mouseslider;
    public AudioMixer audioMix;
    private GameObject Player;
    private void Awake()
    {
         Player = GameObject.FindGameObjectWithTag("Player");
    }
    public void SetQuality(int qualityIndex)
    {
QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void setFullScreen(bool fullScreenEnable)
    {
        Screen.fullScreen = fullScreenEnable;
    }
    public void setMouseSensitivity(float value)
    {
        PlayerPrefs.SetFloat("MouseSensitivity",value);
        if (Player!=null)
        {
            print("merhaba");
            Player.GetComponent<PlayerMovement>().mousesens = mouseslider.value;

        }
    }
    public void SetMasterVolume(float Value)
    {
        audioMix.SetFloat("MasterVolume", Value);
    }
    public void SetMusicVolume(float Value)
    {
        audioMix.SetFloat("MusicVolume", Value);
    }
    public void SetResoulation(int index)
    {
        if (index == 0)
        {
            Screen.SetResolution(1920, 1080,true);
        }
        else if(index == 1)
        {
            Screen.SetResolution(1366,768,true);
        }
        else if (index == 2)
        {
            Screen.SetResolution(1280, 720, true);
        }
    }
}
