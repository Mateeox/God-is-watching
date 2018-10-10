using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGodMove : MonoBehaviour{

    public float moveSpeed;
    private bool isSelected;
    private float lastMousePositionX;
    private float lastMousePositionY;
    private Vector3 startPosition;
    private Rigidbody rigidbody;


    // Use this for initialization
    void Start()
    {
        moveSpeed = 0.03f;
        isSelected = false;
        lastMousePositionX = 0;
        lastMousePositionY = 0;
        startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        rigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isSelected)
        {
            float currentMousePositionY = Input.mousePosition.y;
            float currentMousePositionX = Input.mousePosition.x;
            transform.position = new Vector3(transform.position.x + moveSpeed * (currentMousePositionX - lastMousePositionX),
                transform.position.y + moveSpeed * (currentMousePositionY - lastMousePositionY), transform.position.z);

            lastMousePositionX = currentMousePositionX;
            lastMousePositionY = currentMousePositionY;
        }
    }

    void OnMouseDown()
    {
        //highlight object on mouse button down
        GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.white);

        rigidbody.isKinematic = true;

        this.isSelected = true;
        lastMousePositionY = Input.mousePosition.y;
        lastMousePositionX = Input.mousePosition.x;
    }

    void OnMouseUp()
    {
        //disable object highligth on mouse button up
        GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
        
        rigidbody.isKinematic = false;
        this.isSelected = false;
    }
}
