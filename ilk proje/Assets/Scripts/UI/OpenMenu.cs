using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OpenMenu : MonoBehaviour
{
    public GameObject openMenu, closeMenu;
    
    public void Open_Menu()
    {
        openMenu.SetActive(true);
        closeMenu.SetActive(false);
    }
    
}
