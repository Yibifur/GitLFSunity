using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class DroneManager : MonoBehaviour
{
    //public GameObject Drone;
    //public GameObject cloneDrone;
    //public Transform[] spawnPoints;
    //public float spawnTime;
    //private bool isEnemyAliveSpawn=true;
    //private void Start()
    //{


    //}
    //private void CreateEnemy()
    //{
    //    print("CreateEnemy çalýþtý");
    //    Instantiate(cloneDrone, spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
    //    //Quaternion.Euler(new Vector3(0, -90, 0))
    //    cloneDrone.GetComponent<Drone_Control>().enemyHP = cloneDrone.GetComponent<Drone_Control>().enemySlider.maxValue;


    //}
    //public void Update()
    //{
    //    if (isEnemyAliveSpawn == false)
    //    {
    //        Invoke(nameof(CreateEnemy), spawnTime);
    //        isEnemyAliveSpawn = true;
    //    }


    //}
    public float spawnTime;
    public Transform[] spawnPoints;
    public GameObject enemyPrefab;
    public Slider enemySlider;
    public TextMeshProUGUI enemyText;
    public TextMeshProUGUI enemyHPInfo;
    private void Start()
    {
        if (enemyHPInfo != null)
        {
            enemyHPInfo.SetText("Enemy");
        }
        //if (GetComponent<Drone_Control>().enemyHealthNumber != null)
        //{
        //    GetComponent<Drone_Control>().enemyHealthNumber.SetText(GetComponent<Drone_Control>().enemyHP.ToString());
        //}


    }
    private void OnEnable()
    {


        Drone_Control.OnEnemyKilled += SpawnNewEnemy;


    }
    private void CloneDrone()
    {
        Instantiate(enemyPrefab, spawnPoints[UnityEngine.Random.Range(0, (spawnPoints.Length - 1))].position, Quaternion.identity);
        
    }
    void SpawnNewEnemy()
    {
        Invoke(nameof(CloneDrone), spawnTime);
    }


}