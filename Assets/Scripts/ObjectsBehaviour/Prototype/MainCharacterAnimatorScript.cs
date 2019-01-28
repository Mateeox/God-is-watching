using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterAnimatorScript : Enemy{

    // The target marker.
    public Transform target;
    private Vector3 originPosition;
    // Speed in units per sec.
    public float speed;
    Animator anim;
    private float detectionDistance = 10.0f;
    private float damageDelay = 0;
    public float amountOfDelay = 2.0f;

	[SerializeField]
	private GameObject portal;

    private void Awake()
    {
       DisableRagdoll();
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        originPosition = this.gameObject.transform.position;
    }

    void Update()
    {
		if(health <= 0)
        {
            //Destroy(gameObject);
            EnableRagdoll();
			GameObject.Find("GameVariables").GetComponent<NextLevel>().proceedToNextLevel(20.0f);
        }
		
		float distance = Vector3.Distance(target.position, transform.position);		
        if (distance < detectionDistance && distance > 5.0f)
        {
            detectionDistance = 30.0f;
            anim.ResetTrigger("idle");
            anim.ResetTrigger("attack");
            anim.SetTrigger("run");
            Vector3 targetDir = target.position - transform.position;
            // The step size is equal to speed times frame time.
            float step = speed * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step * 1.5f, 0.0f);
            newDir.y = 0;
            // Move our position a step closer to the target.
            Vector3 newPosition = new Vector3(target.position.x, 0, target.position.z);
            transform.rotation = Quaternion.LookRotation(newDir);
            transform.position = Vector3.MoveTowards(transform.position, newPosition, step);
        }
        else if (distance > 5.0f)
        {
            Vector3 targetDir = originPosition - transform.position;
            float step = speed * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, originPosition, step * 1.5f, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDir);
            transform.position = Vector3.MoveTowards(transform.position, originPosition, step);
        }

        if (Vector3.Distance(transform.position, originPosition) == 0 || distance <= 5.0f)
        {
            anim.ResetTrigger("run");
            anim.ResetTrigger("attack");
            anim.SetTrigger("idle");
        }
        
        if (distance < 6.0f)
        {
            anim.ResetTrigger("run");
            anim.ResetTrigger("idle");
            anim.SetTrigger("attack");
            Attack(target.gameObject);
        }
    }

    private void Attack(GameObject target)
    {
        if (damageDelay <= 0)
        {
            target.GetComponent<Player>().takeDamage(20);
            damageDelay = amountOfDelay;
        }
        else if (damageDelay > 0)
        {
            damageDelay -= Time.deltaTime;
        }
    }
	
	private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            FPPCloseAttackSpear spear = other.gameObject.GetComponent<FPPCloseAttackSpear>();
            if (spear.attack == FPPCloseAttackSpear.attackDirection.down)
            {
                health -= weaponDamage;
                Vector3 pos = new Vector3(gameObject.transform.position.x, 4.0f, gameObject.transform.position.z);
                Instantiate(bloodParticles, pos, new Quaternion()); // generate blood effect
            }
        }
    }

    private void DisableRagdoll()
    {
        Rigidbody[] rbJoints = GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody rbJoint in rbJoints)
        {
            rbJoint.isKinematic = true;
        }
    }

    private void EnableRagdoll()
    {
        Collider baseCollider = GetComponent<Collider>();
        baseCollider.enabled = false;
        GameObject spear = transform.Find("pCylinder1").gameObject;
        spear.transform.parent = null;
        spear.GetComponent<Rigidbody>().isKinematic = false;
        anim.enabled = false;
        enabled = false;
        Rigidbody[] rbJoints = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rbJoint in rbJoints)
        {
            rbJoint.isKinematic = false;
        }

		if(portal != null){
			portal.SetActive(true);
		}

    }
}
