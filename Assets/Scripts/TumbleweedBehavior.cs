using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumbleweedBehavior : MonoBehaviour {

    public float YSpeed;
    public float ZSpeed;
    float t1 = 0.0f;
    float t2 = 0.0f;
    float minimum1 = 2f;
    float maximum1 = 3;
    float minimum2 = -1000;
    float maximum2 = 9000;

    // Use this for initialization
    void Start() {
    }

    public void SetMinZ(float minZ)
    {
        minimum2 = minZ;
    }

    // Update is called once per frame
    void Update () {
        // The step size is equal to speed times frame time.
        float step = ZSpeed * Time.deltaTime;

        // Move our position a step closer to the target.
        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, 10, 9000), step);
        transform.Rotate(Vector3.right * 20 * Time.deltaTime);
        // animate the position of the game object...
        
        transform.position = new Vector3(transform.position.x, Mathf.Lerp(minimum1, maximum1, t1), transform.position.z);
        transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Lerp(minimum2, maximum2, t2));

        // .. and increase the t interpolater
        t1 += YSpeed * Time.deltaTime;
        t2 += ZSpeed * Time.deltaTime;

        // now check if the interpolator has reached 1.0
        // and swap maximum and minimum so game object moves
        // in the opposite direction.
        if (t1 > 1.0f)
        {
            float temp = maximum1;
            maximum1 = minimum1;
            minimum1 = temp;
            t1 = 0.0f;
        }
        if (t2 > 1.0f)
        {
            float temp = maximum2;
            maximum2 = minimum2;
            minimum2 = temp;
            t2 = 0.0f;
        }
    }
}
