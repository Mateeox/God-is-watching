using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialOpenWicket : MonoBehaviour {

    public GameObject[] vases;
    public GameObject leftWicket;
    public GameObject rightWicket;
    public float openAngle = 0.0f;
    public float openSpeed = 10.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        bool isActivated = true;

        foreach (var vase in vases)
        {
            isActivated &= vase.GetComponent<TutorialVaseDestroy>().isDestroyed;
        }
                
        if (isActivated && leftWicket.transform.eulerAngles.y > openAngle && leftWicket.transform.eulerAngles.y < 180.0f)
        {
            leftWicket.transform.Rotate(new Vector3(0, -1 * openSpeed * Time.deltaTime, 0));
            rightWicket.transform.Rotate(new Vector3(0, openSpeed * Time.deltaTime, 0));
        }
        
    }
}
