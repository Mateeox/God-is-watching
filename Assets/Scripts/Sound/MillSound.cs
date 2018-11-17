
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MillSound : MonoBehaviour {

    public AudioSource MusicSource;

    // Use this for initialization
    void Start () {
        MusicSource = GetComponent<AudioSource>();
        MusicSource.Play();
    }

    // Update is called once per frame
    void Update () {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "rockBig")
        {
            MusicSource.Stop();
        }

        if (other.gameObject.tag == "SlowZone")
        {
            MusicSource.pitch = 0.7f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "rockBig")
        {
            MusicSource.Play();
        }

        if (other.gameObject.tag == "SlowZone")
        {
            MusicSource.pitch = 1f;
        }
    }
}
