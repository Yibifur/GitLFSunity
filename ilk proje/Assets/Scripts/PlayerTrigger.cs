using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    //public LevelManager levelManager;
    //public bool enter;
    //public GameObject enemyPrefab;
    //public Transform[] enemyLocations;
    //public bool isenemySpawned;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player")){

    //        if (isenemySpawned)
    //        {
    //   Instantiate(enemyPrefab, enemyLocations[Random.Range(0,(enemyLocations.Length-1))].position, Quaternion.identity);
    //            isenemySpawned = false;
    //        }

    //        if (enter)
    //        {
    //            levelManager.playerEnter = true;

    //        }
    //        else
    //        {
    //            levelManager.playerExit = true;

    //        }
    //    }

    //}
    public LevelManager lm;
    public bool enter;
    private void OnTriggerEnter(Collider other)
    {
        if (enter)
        {
       lm.player_enter = true;
            lm.player_exit = false;
        }
        else
        {
            lm.player_exit = true;
            lm.player_enter=false;
        }
    }

}
