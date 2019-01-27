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
        if (currentStateInfo.IsName("Spin"))//durring spinning attack
        {
            currentSpinTime -= Time.deltaTime;
            // Move our position a step closer to the target.
            Vector3 newPosition = new Vector3(enemyPos.x, originPosition.y, enemyPos.z);
            transform.position = Vector3.MoveTowards(transform.position, newPosition, step);
        }

        if (currentSpinTime <= 0)//after spinning attack
        {

            anim.SetTrigger("Dizzy");
            anim.ResetTrigger("Idle");
            anim.ResetTrigger("Spin");
            anim.ResetTrigger("Run");
            currentSpinCooldown = spinCooldown;
            currentSpinTime = spinTime;

        }


        if (currentStateInfo.IsName("Dizzy") && currentSpinCooldown > 0)//when boss is exhausted
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
                anim.ResetTrigger("Dizzy");
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
            }else if(currentSpinCooldown > 0)
            {
                anim.SetTrigger("Dizzy");
                anim.ResetTrigger("Idle");
                anim.ResetTrigger("Run");
                anim.ResetTrigger("Spin");
            }
            else
            {
                anim.SetTrigger("Idle");
                anim.ResetTrigger("Dizzy");
                anim.ResetTrigger("Run");
                anim.ResetTrigger("Spin");
            }
        }
        else if (currentSpinCooldown <= 0)//starting next spinning attack
        {
            anim.SetTrigger("Spin");
            anim.ResetTrigger("Dizzy");
            anim.ResetTrigger("Run");
            anim.ResetTrigger("Idle");

        }



    }
}
