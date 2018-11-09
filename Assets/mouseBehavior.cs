using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseBehavior : MonoBehaviour {

    // The target marker.
    public Transform target;
    private Vector3 originPosition;
    // Speed in units per sec.
    public float speed;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        originPosition = this.gameObject.transform.position;
    }

    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) < 30)
        {
            anim.SetTrigger("running");
            Vector3 targetDir = target.position - transform.position;
            // The step size is equal to speed times frame time.
            float step = speed * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, -targetDir, step * 1.5f, 0.0f);
            newDir.y = 0;
            // Move our position a step closer to the target.
            Vector3 newPosition = new Vector3(target.position.x, 0, target.position.z);
            transform.rotation = Quaternion.LookRotation(newDir);
            transform.position = Vector3.MoveTowards(transform.position, newPosition, step);
        } else
        {
            Vector3 targetDir = originPosition - transform.position;
            float step = speed * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, -originPosition, step * 1.5f, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDir);
            transform.position = Vector3.MoveTowards(transform.position, originPosition, step);
        }
        if (Vector3.Distance(this.gameObject.transform.position, originPosition) == 0 )
        {
            Debug.Log("XXX");
            anim.ResetTrigger("running");
        }

	}
}
