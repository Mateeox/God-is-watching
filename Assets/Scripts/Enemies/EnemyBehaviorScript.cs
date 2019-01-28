using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviorScript : MonoBehaviour {

    // The target marker.
    public Transform target;
    private Vector3 originPosition;
    private Vector3 originRotation;
    // Speed in units per sec.
    public float speed;
    Animator anim;
    private float detectionDistance = 10.0f;
    public float attackDistance =  2.0f;
    private float damageDelay = 0;
    public float amountOfDelay = 2.0f;
    public bool righthanded = true;
    private Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        originPosition = this.gameObject.transform.position;
        originRotation = this.gameObject.transform.rotation * gameObject.transform.right;
        detectionDistance = 30.0f;

    }

    void Update()
    {


        AnimatorStateInfo currentStateInfo = anim.GetCurrentAnimatorStateInfo(0);
        Vector3 newDir, enemyPos;
        if (righthanded)
        {
            enemyPos = target.position + target.transform.right * 4.0f;
        }
        else
        {
            enemyPos = target.position + target.transform.right * -2.0f;
        }

        if(rigidbody.isKinematic && !currentStateInfo.IsName("idleProtect") && Vector3.Distance(transform.position, originPosition) > 3.0f)
        {
            rigidbody.isKinematic = false;
        }

        if (Vector3.Distance(transform.position, originPosition) < 2.0f && Vector3.Distance(enemyPos, transform.position) >= detectionDistance)
        {
            anim.SetTrigger("idleProtect");
            rigidbody.isKinematic = true;
        }

        // The step size is equal to speed times frame time.
        float step = speed * Time.deltaTime;

        if (currentStateInfo.IsName("Attack"))
        {
           
            Vector3 targetDir = target.position - transform.position;

          

            if (righthanded)
            {
                newDir = Vector3.RotateTowards(transform.forward, targetDir + transform.right * -1.5f + transform.up * -2.0f, step * 0.3f, 0.0f);
            }
            else
            {
                newDir = Vector3.RotateTowards(transform.forward, targetDir + transform.right * 1.5f + transform.up * -2.0f, step * 0.3f, 0.0f);
            }
            
            transform.rotation = Quaternion.LookRotation(newDir);

            if(Vector3.Distance(enemyPos, transform.position) >= attackDistance)
            {
                anim.SetTrigger("run");
            }
        }
        else if (Vector3.Distance(enemyPos, transform.position) > attackDistance)
        {
            if (Vector3.Distance(enemyPos, transform.position) < detectionDistance)
            {
                anim.ResetTrigger("idleProtect");
                anim.SetTrigger("run");
                Vector3 targetDir = target.position - transform.position;
                if (righthanded)
                {
                    newDir = Vector3.RotateTowards(transform.forward, targetDir + transform.right * -1.5f + transform.up * -2.0f, step * 0.4f, 0.0f);
                }
                else
                {
                    newDir = Vector3.RotateTowards(transform.forward, targetDir + transform.right * 1.5f + transform.up * -2.0f, step * 0.4f, 0.0f);
                }
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
                Vector3 targetDir = originPosition - transform.position;
                newDir = Vector3.RotateTowards(transform.forward, originPosition, step * 0.5f, 0.0f);
                newDir.y = 0.0f;
                transform.rotation = Quaternion.LookRotation(newDir);
                transform.position = Vector3.MoveTowards(transform.position, originPosition, step);
            }
        }


       
        //Set proper rotation during IdleProtect state
        if(currentStateInfo.IsName("IdleProtect"))
        {
            newDir = Vector3.RotateTowards(transform.forward, originRotation, step * 1.5f, 0.0f);
            newDir.y = 0.0f;
            transform.rotation = Quaternion.LookRotation(newDir);
        }

        
       
        
        float distance = Vector3.Distance(enemyPos, transform.position);
        if (distance < attackDistance)
        {
            anim.SetTrigger("attack");
        }
    }
}
