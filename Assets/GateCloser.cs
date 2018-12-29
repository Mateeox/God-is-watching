using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateCloser : MonoBehaviour {

    public GameObject gate;
    private bool lowered = false;
    private Vector3 targetPosition = new Vector3(-7.64f, 1.1f, -0.35f);
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision!");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision!");
        Debug.Log(Vector3.Distance(transform.position, targetPosition) < 0.05);
        if (other.tag == "Player" && lowered == false)
        {
            Debug.Log("Collision!");
            float step = Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
            if (Vector3.Distance(transform.position, targetPosition) < 0.05 )
            {
                lowered = true;
                enabled = false;
            }
        }
    }
}
