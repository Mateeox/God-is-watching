using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollisionSound : MonoBehaviour {

    public AudioSource AudioSource;

    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.relativeVelocity.magnitude >= 3)
        {
            AudioSource.Play();
        }
    }
    
   /* private void OnCollisionStay(Collision collision)
    {
        if (collision.relativeVelocity.magnitude >= 2f)
        {
            AudioSource.Play();
        }
    }*/

   

    void Update()
    {

    }
}
