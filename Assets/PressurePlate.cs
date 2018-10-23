using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour {

    public string tagName = "rockSmall";
    private Vector3 startPosition;
    private bool colided = false;

    // Use this for initialization
    void Start () {
        startPosition = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == tagName)
        {
            Vector3 target = new Vector3(startPosition.x, 0, startPosition.z);
            transform.position = Vector3.MoveTowards(transform.position, target, 4);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == tagName)
        {
            transform.position = startPosition;
        }
    }
}
