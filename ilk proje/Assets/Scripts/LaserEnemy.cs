using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float laser_multipler = 2f;
    public LayerMask mask;
    public LayerMask player;
    RaycastHit hit;
    public GameObject death_effect;
    private GameObject Player;
    private bool laserHit;
    public float laserDistance;
    private void Awake()
    {
          Player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        
        if (Physics.Raycast(transform.position, transform.forward, out hit, laserDistance, mask))
        {

            GetComponent<LineRenderer>().enabled = true;
            laserHit= true; 
            GetComponent<LineRenderer>().SetPosition(0, transform.position);
            GetComponent<LineRenderer>().SetPosition(1, hit.point);
            GetComponent<LineRenderer>().startWidth = 0.025f * laser_multipler + Mathf.Sin(Time.time) / 50;
        }
        else
        {
            GetComponent<LineRenderer>().enabled = false;
            laserHit = false;
        }
        if (Physics.Raycast(transform.position, transform.forward, out hit, laserDistance, player))
        {
            if (laserHit)
            {
                if (hit.transform.CompareTag("Player")) { 
        Player.GetComponent<PlayerMovement>().playerHealth-=20f;
            }
           
            }

        }


    }
}
