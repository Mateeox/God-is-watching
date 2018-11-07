using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlayerMove : MonoBehaviour {

    public static GameObject player;
    private Rigidbody rigidbody;
    private Light spot;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        rigidbody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonUp("PickUpObject") && Player.pickedObject == gameObject)
        {
            DestroyImmediate(spot);
            spot = null;
            gameObject.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            gameObject.transform.SetParent(null);
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
                gameObject.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.4f);
                spot = gameObject.AddComponent<Light>();
                spot.range = 3f;
                spot.type = LightType.Spot;
                spot.intensity = 0.3f;
                spot.color = new Color(229, 143, 33, 50f);
                spot.transform.rotation = Quaternion.Euler(90.0f, 0, 0);
            }           
        }       
    }
}
