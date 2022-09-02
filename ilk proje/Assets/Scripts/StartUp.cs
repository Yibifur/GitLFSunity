using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 public class StartUp : MonoBehaviour
{
    public Slider mouseSlider;
    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().mousesens = PlayerPrefs.GetFloat("MouseSensitivity",100f);
        mouseSlider.value = PlayerPrefs.GetFloat("MouseSensitivity", 100f); ;
    }
}
