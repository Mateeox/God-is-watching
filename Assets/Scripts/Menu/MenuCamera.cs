using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamera : MonoBehaviour
{
    Vector3 origin;
    Vector3 target;
    public float ratio = 0.1f;
    private float testVar = 0.0f;
    private Vector3 velocity = Vector3.zero;

    // Use this for initialization
    void Start()
    {
        origin = transform.position;
        InvokeRepeating("ChangeTarget", 10f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, 10);
    }

    void ChangeTarget()
    {
        float x = Random.Range(-1000f, 1000f);
        float z = Random.Range(-1000f, 1000f);
        target = new Vector3(origin.x + x, origin.y, origin.z + z);
    }
}
