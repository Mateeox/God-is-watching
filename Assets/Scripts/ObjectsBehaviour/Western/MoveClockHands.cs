using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//yes, this class is nearly a copy of ObjectPlayerMove class, but I needed it without loosing info about original parent
public class MoveClockHands : MonoBehaviour {

    public static GameObject player;
    private Rigidbody rigidbody;
    private GameObject spot;
    private bool flag;
	private Transform originalParent;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        rigidbody = GetComponent<Rigidbody>();
        flag = false;
		originalParent = transform.parent;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonUp("PickUpObject") && Player.pickedObject == gameObject || flag)
        {
            flag = false;
            DestroyImmediate(spot);
            spot = null;
            Color currColor = gameObject.GetComponent<MeshRenderer>().material.color;
            currColor.a = 1.0f;
            gameObject.GetComponent<MeshRenderer>().material.color = currColor;
			gameObject.transform.SetParent(originalParent);
            rigidbody.isKinematic = false;
            Player.pickedObject = null;
        }

    }

    void OnMouseOver()
    {
        if(GameVariables.GameMode == GameVariables.GameModes.Hero)
        {
           
            if (Input.GetButtonDown("PickUpObject") && Player.pickedObject == null &&
                Vector3.Distance(gameObject.transform.position, player.transform.position) < Player.maxPickUpDistance)
            {
                gameObject.transform.SetParent(player.transform);
                rigidbody.isKinematic = true;
                gameObject.transform.localPosition = new Vector3(0.25f, 0.25f, 1.5f);
                Player.pickedObject = gameObject;
                Color currColor = gameObject.GetComponent<MeshRenderer>().material.color;
                currColor.a = 0.4f;
                gameObject.GetComponent<MeshRenderer>().material.color = currColor;
                spot = new GameObject("SpotLight");
                Light lit = spot.AddComponent<Light>();
                lit.range = 3f;
                lit.type = LightType.Spot;
                lit.intensity = 0.3f;
                lit.color = new Color(229, 143, 33, 50f);
                lit.transform.rotation = Quaternion.Euler(90.0f, 0, 0);
                lit.transform.position = gameObject.transform.position;
                spot.transform.parent = gameObject.transform;
            }           
        }       
    }

    private void OnTriggerEnter(Collider other)
    {
        flag = true;
        rigidbody.isKinematic = false;
    }
}
