using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedievalBossBehaviour : MonoBehaviour
{

    // The target marker.
    public Transform target;
    private Vector3 chargePoint;
    private Vector3 originPosition;
    // Speed in units per sec.
    public float speed;
    Animator anim;
    public float detectionDistance = 30.0f;
    public float attackDistance = 10.0f;
    public float spinCooldown;
    public float currentSpinCooldown;
    public float spinTime;
    public float currentSpinTime;

    private void Start()
    {
        anim = GetComponent<Animator>();
        originPosition = this.gameObject.transform.position;
        currentSpinCooldown = 0;
        currentSpinTime = spinTime;

    }

    void Update()
    {

        AnimatorStateInfo currentStateInfo = anim.GetCurrentAnimatorStateInfo(0);
        Vector3 newDir, enemyPos;

        float step = speed * Time.deltaTime;
        enemyPos = target.position + target.transform.right * 4.0f;

        //
        if (currentStateInfo.IsName("Spin"))
        {
            currentSpinTime -= Time.deltaTime;
            // Move our position a step closer to the target.
            Vector3 newPosition = new Vector3(enemyPos.x, originPosition.y, enemyPos.z);
            transform.position = Vector3.MoveTowards(transform.position, newPosition, step);
        }

        if (currentSpinTime <= 0)
        {

            anim.SetTrigger("Idle");
            anim.ResetTrigger("Spin");
            anim.ResetTrigger("Run");
            currentSpinCooldown = spinCooldown;
            currentSpinTime = spinTime;

        }


        if (currentStateInfo.IsName("Idle") && currentSpinCooldown > 0)
        {
            currentSpinCooldown -= Time.deltaTime;
        }


        if (Vector3.Distance(enemyPos, transform.position) > attackDistance && !currentStateInfo.IsName("Spin"))
        {
            if (Vector3.Distance(enemyPos, transform.position) < detectionDistance && currentSpinCooldown <= 0)
            {
                anim.SetTrigger("Run");
                anim.ResetTrigger("Idle");
                anim.ResetTrigger("Spin");
                Vector3 targetDir = target.position - transform.position;

                newDir = Vector3.RotateTowards(transform.forward, targetDir + transform.right * -1.5f + transform.up * -2.0f, step * 0.5f, 0.0f);

                newDir.y = 0;
                // Move our position a step closer to the target.
                Vector3 newPosition = new Vector3(enemyPos.x, originPosition.y, enemyPos.z);
                if (currentStateInfo.IsName("Run"))
                {
                    transform.rotation = Quaternion.LookRotation(newDir);
                    transform.position = Vector3.MoveTowards(transform.position, newPosition, step);
                }
            }
            else
            {
                anim.SetTrigger("Idle");
                anim.ResetTrigger("Run");
                anim.ResetTrigger("Spin");
            }
        }
        else if (currentSpinCooldown <= 0)
        {
            anim.SetTrigger("Spin");
            anim.ResetTrigger("Run");
            anim.ResetTrigger("Idle");

        }



    }
}
