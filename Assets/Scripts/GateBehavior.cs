using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateBehavior : MonoBehaviour {
    public PressurePlate[] plates;
    public float openAngle = 80.0f;   
    public float openSpeed = 10.0f;
    private float closeAngle;


    // Use this for initialization
    void Start () {
        closeAngle = gameObject.transform.eulerAngles.y;

    }

    // Update is called once per frame
    void Update() {
        bool isActivated = true;
        for (int i = 0; i < plates.Length; i++)
        {
            isActivated &= plates[i].isActivated;
        }

        if (isActivated && gameObject.transform.eulerAngles.y < closeAngle + openAngle)
        {
            gameObject.transform.Rotate(new Vector3(0, openSpeed * Time.deltaTime, 0));
        }else if(!isActivated && gameObject.transform.eulerAngles.y > closeAngle)
        {
            Debug.Log(gameObject.transform.eulerAngles.y);
            gameObject.transform.Rotate(new Vector3(0, -1 * openSpeed * Time.deltaTime, 0));
        }

	}
}
