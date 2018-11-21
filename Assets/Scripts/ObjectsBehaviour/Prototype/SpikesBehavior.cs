using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesBehavior : MonoBehaviour {

    private Vector3 MovingDirection = Vector3.up;
    public float Speed;
    private float CurrentSpeed;
    public List<GameObject> Spikes;
    private bool triggered = false;
    private Collider slowZone;
    // Use this for initialization
    void Start () {
        CurrentSpeed = Speed;
        int i = 0;
        foreach (Transform child in transform)
        {
            if (i != 0)
            {
                Spikes.Add(child.gameObject);           
            }
            i++;
        }
    }
	
	// Update is called once per frame
	void Update () {

        foreach (GameObject spike in Spikes)
        {
            spike.transform.Translate(MovingDirection * Time.smoothDeltaTime * CurrentSpeed);
        }

        if (Spikes[1].transform.position.y >= 0.0)
        {
            MovingDirection = Vector3.down;
        }
        else if (Spikes[1].transform.position.y <= -5)
        {
            MovingDirection = Vector3.up;
        }

        if (triggered && !slowZone)
        {
            triggered = false;
            CurrentSpeed = Speed;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SlowZone")
        {
            triggered = true;
            this.slowZone = other;
            CurrentSpeed = Speed / 10;
        }

        if (other.gameObject.name == "Player")
        {
            Physics.IgnoreCollision(other.gameObject.GetComponent<Collider>(), this.gameObject.GetComponent<Collider>());
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "SlowZone")
        {
            triggered = false;
            CurrentSpeed = Speed;
        }
    }
}
