using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy_Ball : MonoBehaviour
{
    
    public float speed;
    public float lifetime;
    public bool enemyBullet = false;
    public float sphereRadius;
    public LayerMask playerMask;
    public float bulletDamage;
    
    public void Update()
    {
        transform.Translate(Vector3.forward * -1 * Time.deltaTime * speed);
        lifetime -= Time.deltaTime;
        
        if (lifetime <= 0)
        {
            Destroy(this.gameObject);
        }
        //enemybullet
        if (enemyBullet)
        {
            if (Physics.CheckSphere(transform.position, sphereRadius, playerMask))
            {
                //Destroy(GameObject.FindGameObjectWithTag("Player"));
                GameObject.FindGameObjectWithTag("Player").GetComponent<playermanager>().Death();
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //print("shot player");
            GameObject Player = GameObject.FindGameObjectWithTag("Player");

            Player.GetComponent<PlayerMovement>().playerHealth -= bulletDamage;
            
            Player.GetComponent<PlayerMovement>().healthSlider.value = Player.GetComponent<PlayerMovement>().playerHealth;
        }
    }

}


