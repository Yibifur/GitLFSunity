using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Drone_Control : MonoBehaviour
{


    //looking
    private GameObject Player;
    public float droneSpeed;
    public float sphereRadius;
    //Shooting
    private float cooldown = 2f;
    //private float tempCooldown;
    public GameObject mesh;
    public GameObject energyball;
    //Enemy Health
    public float enemyHP;
    
    public TextMeshProUGUI enemyHPInfo;
    public Slider enemySlider;
    public GameObject deathParticles;
    public TextMeshProUGUI enemyHealthNumber;
    //laser sound
    public AudioClip laserSound;
    //explosion sound
    public AudioClip explosionSound;
    //spawn enemy
    public delegate void EnemyKilled();
    public static event EnemyKilled OnEnemyKilled;
    public bool isEnemyAlive = true;
    
    //public GameObject enemyCore;



    private void Awake()
    {
        
        Player = GameObject.FindGameObjectWithTag("Player");
        enemySlider.GetComponent<Slider>().maxValue = enemyHP;
        //tempCooldown = cooldown;
        if (enemyHPInfo != null)
        {
            enemyHPInfo.SetText("Enemy");
        }
        if(enemyHealthNumber != null)
        {
            enemyHealthNumber.SetText(enemyHP.ToString());
        }

    }
    private void FollowPlayer()
    {
        //Drone looking to us



        transform.LookAt(Player.transform);
        transform.rotation *= Quaternion.Euler(new Vector3(0, -90, 0));


        //Drone Moving
        if (Vector3.Distance(Player.transform.position, transform.position) >= sphereRadius)
        {
            transform.Translate(mesh.transform.forward * Time.deltaTime * droneSpeed);

        }
        else
        {

            transform.RotateAround(Player.transform.position, Vector3.up, droneSpeed * Time.deltaTime * UnityEngine.Random.Range(0.2f, 4f));
            //transform.Translate(new Vector3(0,0,Mathf.Sin(3f)));

        }
    }
    private void Shooting()
    {

        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;

        }
        else
        {
            cooldown = 2f;
            //shoot animation
            mesh.GetComponent<Animator>().SetTrigger("Shot");
            //laser sound
            GetComponent<AudioSource>().PlayOneShot(laserSound);
            //laser copy
            Instantiate(energyball, transform.position, transform.rotation * Quaternion.Euler(new Vector3(0, -90, 0)));
        }
    }



    



    private void Update()
    {

        //enemyHP

        //GetAttacked();
        
        enemySlider.value = enemyHP;
        if (enemySlider.value <= 0)
        {

            isEnemyAlive = false;

            //deathparticle copy
            Instantiate(deathParticles, transform.position, Quaternion.identity);
            //explosion sound
            Player.GetComponent<AudioSource>().PlayOneShot(explosionSound);
           
           
            // destroy gameobject
            Destroy(gameObject);
            enemyHP = enemySlider.maxValue;
            //drone cloning
            if (OnEnemyKilled != null)
            {
                OnEnemyKilled();
            }

        }
        
            enemySlider.value = enemySlider.maxValue;
            

        
        

        FollowPlayer();
        Shooting();




        
        



    }

    public void GetAttacked(float damage)
    {
        enemyHP -= damage;
        enemyHealthNumber.SetText(enemyHP.ToString());
    }

}



























