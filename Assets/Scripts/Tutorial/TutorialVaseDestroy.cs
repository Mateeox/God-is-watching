using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialVaseDestroy : MonoBehaviour {
       
    public bool isDestroyed;

	// Use this for initialization
	void Start () {
        isDestroyed = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnDestroy()
    {
        if (!isDestroyed)
        {
            isDestroyed = true;
        }
        
    }
}
