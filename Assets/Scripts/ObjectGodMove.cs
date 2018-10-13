using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGodMove : MonoBehaviour{

    public float objectsDistanceFromCamera;
    private bool isSelected;
    private Rigidbody rigidbody;
    private Vector3 point;

    
    void Start()
    {
        objectsDistanceFromCamera = 15.0f;
        isSelected = false;
        rigidbody = GetComponent<Rigidbody>();
        point = new Vector3();

    }
    
    void Update()
    {
        if (GameVariables.GameMode == GameVariables.GameModes.God && isSelected)
        {
            point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, objectsDistanceFromCamera));
                       
            transform.position = new Vector3(point.x, point.y, transform.position.z);
           
        }
    }

    void OnMouseDown()
    {
        //highlight object on mouse button down
        if (GameVariables.GameMode == GameVariables.GameModes.God)
        {
            GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.white);
            rigidbody.isKinematic = true;
            this.isSelected = true;
        }
                
    }

    void OnMouseUp()
    {
        //disable object highligth on mouse button up
        if (GameVariables.GameMode == GameVariables.GameModes.God)
        {
            GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);

            rigidbody.isKinematic = false;
            this.isSelected = false;
        }
        
    }
}
