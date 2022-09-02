using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour
{
    public bool isLavaOpen;
    //public float hurtTime;
    //private float temp;
    private void Awake()
    {
        //temp = hurtTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player") && isLavaOpen)
        {

            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().playerHealth =0f;
            print("ölmem lazým");
        }
    }
   

}
