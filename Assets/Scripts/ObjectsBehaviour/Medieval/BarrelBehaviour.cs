using Assets.Scripts.GOD.SlowZone;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelBehaviour : MonoBehaviour, ISlowable
{

    public float maxUpForce = 200.0f;
    public float maxSideSpeed = 5.0f;
    public float upForce;
    public float sideSpeed;
    public float slowDivisor = 10.0f;
    public bool isInWater = false;
    private Rigidbody rgb;
    private bool isDuplicated;
    // Use this for initialization
    void Start()
    {
        rgb = gameObject.GetComponent<Rigidbody>();
        isDuplicated = false;
        upForce = maxUpForce;
        sideSpeed = maxSideSpeed;

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void GoUp()
    {
        rgb.AddForce(Vector3.up * upForce);
        
    }
   
    public void OnGetIntoWater()
    {
        isInWater = true;       
        rgb.velocity = new Vector3(rgb.velocity.x, rgb.velocity.y, -1 * sideSpeed);
        rgb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }

    private void OnMouseDown()
    {
        if (!isDuplicated && GameVariables.GameMode == GameVariables.GameModes.God && GameVariables.Ability == GameVariables.Abilities.Move)
        {
            Instantiate(gameObject);
            isDuplicated = true;
        }


    }   

    public void SetMaxSpeed()
    {
        //upForce = maxUpForce;
        sideSpeed = maxSideSpeed;
    }

    public void SlowDown()
    {
        //upForce = maxUpForce / slowDivisor;
        sideSpeed = maxSideSpeed / slowDivisor;
    }

    /*private void OnMouseUp()
    {
        rgb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY |
               RigidbodyConstraints.FreezeRotationZ;
    }*/

}
