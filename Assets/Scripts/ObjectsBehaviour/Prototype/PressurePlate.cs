using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour {

    public string tagName = "rockSmall";
    public bool isActivated;
    private Vector3 startPosition;
    private bool colided = false;
 

    // Use this for initialization
    void Start () {
        startPosition = this.gameObject.transform.position;
        isActivated = false;
    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        
        Vector3 target = new Vector3(startPosition.x, 0, startPosition.z);
        transform.position = Vector3.MoveTowards(transform.position, target, 4);

        if (other.gameObject.tag == tagName)
        {
            isActivated = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        transform.position = startPosition;
        if (other.gameObject.tag == tagName && isActivated)
        {
            isActivated = false;
        }
    }
}
