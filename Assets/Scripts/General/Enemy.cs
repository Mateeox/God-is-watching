using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : LightningHitable 
{

    public float health = 100;
    public float weaponDamage = 40;
    public float lighteningDamage = 80;
    public float particlesYOffset = 0.0f;
    public GameObject bloodParticles;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(health <= 0)
        {
            Destroy(gameObject);
        }
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            FPPCloseAttackSpear spear = other.gameObject.GetComponent<FPPCloseAttackSpear>();
            if(spear.attack == FPPCloseAttackSpear.attackDirection.down)
            {
                health -= weaponDamage;
                Instantiate(bloodParticles, gameObject.transform.position + transform.up * particlesYOffset, new Quaternion()); // generate blood effect
            }
           
        }
    }

    public override void afterHit()
    {
        health -= lighteningDamage;
        Instantiate(bloodParticles, gameObject.transform.position, new Quaternion()); // generate blood effect
    }
}
