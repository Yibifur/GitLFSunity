using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    // sound
    public AudioClip AK_sound;
    //bullet 
    public GameObject bullet;
     
    
    //bullet force
    public float shootForce, upwardForce;

    //Gun stats
    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;

    private int bulletsLeft, bulletsShot;

    //Recoil
    //public Rigidbody playerRb;
    public float recoilForce;



    //bools
    bool shooting, readyToShoot, reloading;

    //Reference
    public Camera fpsCam;
    public Transform attackPoint;

    //Graphics
    public ParticleSystem muzzleFlash;
    public TextMeshProUGUI ammunitionDisplay;

    //bug fixing :D
    public bool allowInvoke = true;
    //Armory
    public GameObject CubeBullet;
    public GameObject SphereBullet;
    public GameObject CyclinderBullet;
    public LayerMask Armory;
    public GameObject player;
    public RaycastHit hit;
    private bool? cubeAmmo=null;
    private bool? SphereAmmo=null;
    private bool? CyclinderAmmo=null;
    public Collider CubeCollider;
    //private Vector3 velocity;
    private void Awake()
    {
        //make sure magazine is full
        bulletsLeft = magazineSize;
        readyToShoot = true;
        

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Armory_Cube")
        {
            
            //velocity=CubeBullet.GetComponent<Transform>().position;
            //velocity.y+=Time.deltaTime;
            //CubeBullet.transform.Translate(velocity);
            
            print("küpteyim");

           bulletsLeft = magazineSize;

            cubeAmmo = true;
            SphereAmmo = false;
            CyclinderAmmo = false;
            if (Input.GetKeyDown(KeyCode.O))
            {
                bulletsLeft = magazineSize;

                cubeAmmo = false;

            } 
        }
        else if(collision.gameObject.tag == "Armory_Sphere")
        {
            
            bulletsLeft = magazineSize;

            SphereAmmo = true;
            cubeAmmo=false;
            CyclinderAmmo=false;
            if (Input.GetKeyDown(KeyCode.O))
            {
                bulletsLeft = magazineSize;

                SphereAmmo = false;

            }
        }
        else if(collision.gameObject.tag == "Armory_Cyclinder")
        {
            
            bulletsLeft = magazineSize;

            CyclinderAmmo = true;
            cubeAmmo = false;
            SphereAmmo=false;
            if (Input.GetKeyDown(KeyCode.O))
            {
                bulletsLeft = magazineSize;

                CyclinderAmmo = false;

            }
        }
    }
    //private void CubeAmmo_Func()
    //{
    //    if (cubeAmmo == true)
    //    {
    //        MyInput(CubeBullet);

    //    }
    //    else if(cubeAmmo == false)  
    //    {
    //        MyInput(bullet);
    //    }
    //    else
    //    {
            
    //    }
    //}
    //private void SphereAmmo_Func()
    //{
    //   if (SphereAmmo == true)
    //    {
    //        MyInput(SphereBullet);
    //    }
    //    else if(SphereAmmo == false)    
    //    {
    //        MyInput(bullet);
    //    }
    //    else
    //    {

    //    }
    //}
    //private void CyclinderAmmo_Func()
    //{

    //    if (CyclinderAmmo == true)
    //    {
    //        MyInput(CyclinderBullet);
    //    }
    //    else if(CyclinderAmmo == false)
    //    {
    //        MyInput(bullet);
    //    }
    //    else
    //    {

    //    }
    //}

    private void ChangeAmmo()
    {
        if (cubeAmmo == null && CyclinderAmmo == null && SphereAmmo == null)
        {
            MyInput(bullet);
        }
        if(cubeAmmo == true)
        {
            MyInput(CubeBullet);
        }else if (CyclinderAmmo == true)
        {
            MyInput(CyclinderBullet);
        }
        else if(SphereAmmo == true)
        {
         MyInput(SphereBullet);
        }
            
    }
    private void Update()
    {
        

        ChangeAmmo();
        

        //Set ammo display, if it exists :D
        if (ammunitionDisplay != null)
            ammunitionDisplay.SetText(bulletsLeft / bulletsPerTap + " / " + magazineSize / bulletsPerTap);


       
        
            if (Input.GetKeyDown(KeyCode.O))
            { 
                bulletsLeft = magazineSize;
               
                cubeAmmo = false;
               
            }
        
    }
    private void MyInput(GameObject AmmoType2)
    {
        //Check if allowed to hold down button and take corresponding input
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        //Reloading 
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();
        //Reload automatically when trying to shoot without ammo
        if (readyToShoot && shooting && !reloading && bulletsLeft <= 0) Reload();

        //Shooting
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            //Set bullets shot to 0
            bulletsShot = 0;

            Shoot(AmmoType2);
        }
    }



    //private void muzzle_off()
    //{
    //    GameObject.FindGameObjectWithTag("Point light").GetComponent<Light>().enabled = false;
    //    GameObject.FindGameObjectWithTag("Top").GetComponent<SpriteRenderer>().enabled = false;
    //    GameObject.FindGameObjectWithTag("Side").GetComponent<SpriteRenderer>().enabled = false;
    //    GameObject.FindGameObjectWithTag("Front").GetComponent<SpriteRenderer>().enabled = false;
    //} 
    //private void muzzle_on()                                                                         // benim denediðim muzzle flash yöntemi
    //{
    //    GameObject.FindGameObjectWithTag("Point light").GetComponent<Light>().enabled = true;
    //    GameObject.FindGameObjectWithTag("Top").GetComponent<SpriteRenderer>().enabled = true;
    //    GameObject.FindGameObjectWithTag("Side").GetComponent<SpriteRenderer>().enabled = true;
    //    GameObject.FindGameObjectWithTag("Front").GetComponent<SpriteRenderer>().enabled = true;
    //}
    private void Shoot(GameObject AmmoType)
    {
        //Playing Sound
        GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(AK_sound);
        //muzzle flash
        muzzleFlash.Play();
        //animations
        //GetComponent<Animator>().SetTrigger("oneshot");
        readyToShoot = false;

        //Find the exact hit position using a raycast
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); //Just a ray through the middle of your current view
        RaycastHit hit;

        //check if ray hits something
        Vector3 targetPoint;
        if (Physics.Raycast(ray,out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75); //Just a point far away from the player

        //Calculate direction from attackPoint to targetPoint
        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        //Calculate spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calculate new direction with spread
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0); //Just add spread to last direction

        //Instantiate bullet/projectile
        GameObject currentBullet = Instantiate(AmmoType, attackPoint.position, Quaternion.identity); //store instantiated bullet in currentBullet
        //Rotate bullet to shoot direction
        currentBullet.transform.forward = directionWithSpread.normalized;

        //Add forces to bullet
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);

        //Instantiate muzzle flash, if you have one
        //if (muzzleFlash != null)
        //    Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        bulletsLeft--;
        bulletsShot++;

        //Invoke resetShot function (if not already invoked), with your timeBetweenShooting
        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;

            //Add recoil to player (should only be called once)
            //playerRb.AddForce(-directionWithSpread.normalized * recoilForce, ForceMode.Impulse);
        }

        //if more than one bulletsPerTap make sure to repeat shoot function
        if (bulletsShot < bulletsPerTap && bulletsLeft > 0)
        {
            Invoke("Shoot", timeBetweenShots);


        }



    }
    private void ResetShot()
    {
        //Allow shooting and invoking again
        readyToShoot = true;
        allowInvoke = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime); //Invoke ReloadFinished function with your reloadTime as delay
    }
    private void ReloadFinished()
    {
        //Fill magazine
        bulletsLeft = magazineSize;
        reloading = false;
    }







}

