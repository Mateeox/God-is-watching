using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MillBehaviorScript : MonoBehaviour {

    public GameObject collisionZone;
    public static float speed = 250;
    private static float currentSpeed = speed;
    private static float zeroSpeed = 0;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.forward * Time.deltaTime * currentSpeed);
    }

    public static void SetSpeed(float newSpeed)
    {
        currentSpeed = newSpeed;
    }
    
    public static void SetMaxSpeed()
    {
        currentSpeed = speed;
    }

    public static void SlowDown(float divider)
    {
        currentSpeed /= divider;
    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.name == "MillStone")
    //    {
    //        currentSpeed = zeroSpeed;
    //    }
    //    if (collision.gameObject.name == "Player")
    //    {
    //        Physics.IgnoreCollision(this.gameObject.GetComponent<Collider>(), GameObject.Find("Player").GetComponent<Collider>());
    //    }
    //    if (collision.gameObject.name == "SlowZone")
    //    {
    //        currentSpeed = zeroSpeed;
    //    }
    //}

    //void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.name == "MillStone")
    //    {
    //        currentSpeed = speed;
    //    }
    //    if (collision.gameObject.name == "SlowZone")
    //    {
    //        currentSpeed = speed;
    //    }
    //}
}
