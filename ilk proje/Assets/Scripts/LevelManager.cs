using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class LevelManager : MonoBehaviour
{

    //public bool playerEnter, playerExit;
    //public GameObject Level01;
    //public Transform levelLocation;
    //public GameObject destroyLevel;
    //private void Update()
    //{
    //    if (playerEnter)
    //    {print(playerEnter);

    //        //spawn level
    //        SpawnLevel();
    //        playerEnter = false;
    //    }
    //    if (playerExit)
    //    {
    //        if (destroyLevel != null)
    //        {
    //          Destroy(destroyLevel);
    //        }

    //    }

    //}
    //private void SpawnLevel()
    //{
    //    Vector3 levelPos = new Vector3(transform.position.x - (float)255.1665, transform.position.y, transform.position.z);
    //    //Instantiate(Level01, levelPos, Quaternion.identity);
    //    GameObject obj = Instantiate(Level01, levelPos, Quaternion.identity);
    //    obj.GetComponent<LevelManager>().destroyLevel = this.gameObject;



    //}
    public bool player_enter, player_exit;
    private bool drone_spawned;
    public GameObject enemyPrefab;
    public Transform[] enemyLocations;
    public GameObject Level01;
    public GameObject destroyLevel;
    private void Awake()
    {
        player_enter = false;
        drone_spawned = false;
    }
    private void Update()
    {
        if (!drone_spawned)
        {
            if (player_enter)
            {
                
                SpawnLevel();
                drone_spawned = true;
            }
            
        }
        if (player_exit)
            {
                DestroyLevel();
            }
    }
    private void SpawnLevel()
    {
        Instantiate(enemyPrefab, enemyLocations[Random.Range(0, (enemyLocations.Length - 1))].position, Quaternion.identity);
        Vector3 levelPos = new Vector3(transform.position.x - (float)255.1665, transform.position.y, transform.position.z);
        GameObject obj=Instantiate(Level01, levelPos, Quaternion.identity);
        obj.GetComponent<LevelManager>().destroyLevel = this.gameObject;
    }
    private void DestroyLevel()
    {
        print("yok edildi");
        Destroy(destroyLevel);
    }
}
