using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float health = 100;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(health <= 0)
        {
            Destroy(gameObject);
        }
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            Debug.Log("Hit");
            health -= 40;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.CompareTag("Weapon"))
        {
            Debug.Log("Hit");
            health -= 40;
        }
    }

}
