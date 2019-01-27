using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPressurePlate : MonoBehaviour {

    public string tagName = "Bullet";
	public float endHorizontalPosition = 0.0f;
	[HideInInspector] 
    public bool isActivated;
    private Vector3 startPosition;
 

    // Use this for initialization
    void Start () {
        startPosition = this.gameObject.transform.localPosition;
        isActivated = false;
    }
	
    void OnTriggerEnter(Collider other)
    {
        
        Vector3 target = new Vector3(startPosition.x, startPosition.y, endHorizontalPosition);
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, 4);

        if (other.gameObject.tag == tagName)
        {
            isActivated = true;
        }
    }
}
