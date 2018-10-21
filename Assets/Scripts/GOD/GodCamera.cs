using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodCamera : MonoBehaviour
{

    private float movedHeight;
    private float movedWidth;

    private bool _animation = false;

    void Start()
    {
        Vector3 pos = Input.mousePosition;
        movedWidth = pos.x;
        movedHeight = pos.y;
    }

    void Update()
    {
        if (!_animation && this.GetComponent<Camera>().enabled)
        {
            Vector3 pos = Input.mousePosition;
            Camera cam = this.GetComponent<Camera>();
            cam.transform.position += new Vector3(0, (pos.y - movedHeight) / 1000.0f, (pos.x - movedWidth) / 1000.0f);
            movedHeight = pos.y;
            movedWidth = pos.x;
        }
    }

    public void SetAnimation(bool status)
    {
        _animation = status;
    }

}
