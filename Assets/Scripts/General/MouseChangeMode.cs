using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseChangeMode : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
        Cursor.visible = true;
        if (Input.GetButtonDown("ChangeMode"))
        {
            
            if (Cursor.lockState == CursorLockMode.Locked)
            {               
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            
        }
    }
}
