using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGodMove : MonoBehaviour{

    public float objectsDistanceFromCamera;
    public GameObject bound;
    private Vector3 boundLeftUpCorner;
    private Vector3 boundRightDownCorner;
    private bool isSelected;
    private Rigidbody rigidbody;
    private Vector3 point;

    private void disableMoving()
    {
        GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);

        rigidbody.isKinematic = false;
        this.isSelected = false;
    }

    
    void Start()
    {
        objectsDistanceFromCamera = 35.0f;
        isSelected = false;
        rigidbody = GetComponent<Rigidbody>();
        point = new Vector3();
        boundLeftUpCorner = bound.transform.position + bound.transform.localScale / 2;
        boundRightDownCorner = bound.transform.position - bound.transform.localScale / 2;
        rigidbody.useGravity = true;
    }
    
    void Update()
    {
        bool positionChanged = false;
        if (GameVariables.GameMode == GameVariables.GameModes.God && GameVariables.Ability == GameVariables.Abilities.Move && isSelected)
        {
            Camera godCam = GameObject.Find("God Camera").GetComponent<Camera>();
            point = GameVariables.godCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, objectsDistanceFromCamera));
            point = new Vector3(point.x, point.y, transform.position.z);
            positionChanged = true;
        }
        else
        {
            point = transform.position;
        }
        
        //Check if object is not out of bound
        if (point.x > boundLeftUpCorner.x)
        {
            point.x = boundLeftUpCorner.x;
            positionChanged = true;
        }
        else if (point.x < boundRightDownCorner.x)
        {
            point.x = boundRightDownCorner.x;
            positionChanged = true;
        }

        if (point.y > boundLeftUpCorner.y)
        {
            point.y = boundLeftUpCorner.y;
            positionChanged = true;
        }
        else if (point.y < boundRightDownCorner.y)
        {
            point.y = boundRightDownCorner.y;
            positionChanged = true;
        }

        if (positionChanged)
        {
            transform.position = point;
        }

        //End moving object when player changed mode to heroes
        if(GameVariables.GameMode == GameVariables.GameModes.God && Input.GetButtonDown("ChangeMode"))
        {
            disableMoving();
        }

        //Enable movement when player change mode to god
        if (GameVariables.GameMode == GameVariables.GameModes.Hero && Input.GetButtonDown("ChangeMode"))
        {
            rigidbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX |
                RigidbodyConstraints.FreezeRotationY;
        }


    }

    void OnMouseDown()
    {
        //highlight object on mouse button down
        if (GameVariables.GameMode == GameVariables.GameModes.God && GameVariables.Ability == GameVariables.Abilities.Move)
        {
            GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.white);
            rigidbody.isKinematic = true;
            this.isSelected = true;
        }
                
    }

    void OnMouseUp()
    {
        //disable object highligth on mouse button up
        if (GameVariables.GameMode == GameVariables.GameModes.God && GameVariables.Ability == GameVariables.Abilities.Move)
        {
            disableMoving();
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {
          if(GameVariables.GameMode == GameVariables.GameModes.Hero && collision.gameObject == Player.pickedObject)
          {
            rigidbody.constraints = RigidbodyConstraints.FreezeAll;
          }
    }

    void OnCollisionExit(Collision collision)
    {
        if (GameVariables.GameMode == GameVariables.GameModes.Hero && collision.gameObject == Player.pickedObject)
        {
            rigidbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX |
               RigidbodyConstraints.FreezeRotationY;
        }
    }

   /* private void OnTriggerEnter(Collider other)
    {
        //rigidbody.isKinematic = false;
        //disableMoving();
    }*/
}
