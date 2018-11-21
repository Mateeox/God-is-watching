using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasShowScript : MonoBehaviour {

    private GameObject textChild;
    public float activeDistance = 10;
    // Use this for initialization
    void Start () {
        textChild = this.gameObject.transform.Find("Text").gameObject;
        textChild.SetActive(false);
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(this.gameObject.transform.position, GameObject.Find("Player").transform.position) < activeDistance)
        {

            textChild.SetActive(true);
        } else
        {
            textChild.SetActive(false);
        }
    }
}
