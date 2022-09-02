using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//
// fkdsjhjf
//

public class playermanager : MonoBehaviour
{
    private bool player_Alive = true;
    public GameObject Death_effect;


    
    public void Death()
    {
        if (player_Alive)
        {
            player_Alive = false;
            Instantiate(Death_effect, transform.position, Quaternion.identity);
        }

    }


    
}