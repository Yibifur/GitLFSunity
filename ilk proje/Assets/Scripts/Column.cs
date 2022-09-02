using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    //public Transform ColumnTransform;
    //columnchecker variables
    public GameObject ColumnChecker;
    public LayerMask Player_Layer;
    public float radius;
    //jumping on the column
    private Vector3 velocity;
    private bool broke=false;
    
    private void Update()
    {
        if (Physics.CheckBox(ColumnChecker.transform.position,new Vector3(radius,2,radius), Quaternion.identity,Player_Layer)){
            broke = true;
        }
        if (broke)
        {
            velocity.z-=Time.deltaTime/400;
            transform.Translate(velocity);
        }
    }
}
