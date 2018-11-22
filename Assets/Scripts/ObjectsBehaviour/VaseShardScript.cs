using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseShardScript : MonoBehaviour {

    public GameObject vase;
    private string bulletTagName = "Bullet";
    Rigidbody rg;

    private void Awake()
    {
        rg = GetComponent<Rigidbody>();
        rg.Sleep();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.tag == bulletTagName)
        {
            vase.GetComponent<TutorialVaseDestroy>().OnDestroy();
        }
    }
}
