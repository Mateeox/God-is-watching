using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelBehaviour : MonoBehaviour
{

    public float maxUpForce = 200.0f;
    public float maxSideSpeed = 5.0f;
    public float upForce;
    public float sideSpeed;
    public float slowDivisor = 5.0f;
    public bool isInWater = false;
    private Rigidbody rgb;
    private bool isDuplicated;
    public SlowZone slowZone;
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
       if(slowZone == null && sideSpeed != maxSideSpeed && upForce != maxUpForce)
        {
            sideSpeed = maxSideSpeed;
            upForce = maxUpForce;
        }
    }

    public void GoUp()
    {
        rgb.AddForce(Vector3.up * upForce);
        
    }
   
    public void OnGetIntoWater()
    {
        isInWater = true;       
        rgb.velocity = new Vector3(rgb.velocity.x, rgb.velocity.y, -1 * sideSpeed);
        rgb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
    }

    private void OnMouseDown()
    {
        if (!isDuplicated && GameVariables.GameMode == GameVariables.GameModes.God && GameVariables.Ability == GameVariables.Abilities.Move)
        {
            Instantiate(gameObject);
            isDuplicated = true;
        }


    }

    private void OnTriggerEnter(Collider other)
    {       
        
        if (other.gameObject.tag == "SlowZone")
        {
           slowZone = other.gameObject.GetComponent<SlowZone>();
            upForce /= slowDivisor;
            sideSpeed /= slowDivisor;
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "SlowZone")
        {
            slowZone = null;
            upForce = maxUpForce;
            sideSpeed = maxSideSpeed;
        }
    }

    /*private void OnMouseUp()
    {
        rgb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY |
               RigidbodyConstraints.FreezeRotationZ;
    }*/

}
