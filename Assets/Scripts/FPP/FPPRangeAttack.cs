using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPPRangeAttack : MonoBehaviour {

    public GameObject bullet;
    public float shootForce = 800.0f;
    public float forceOffset = 200.0f;
    public float maxTime = 1.0f;
    public float cooldown = 0.5f;
    public float time;
    public float cooldownTime;

	// Use this for initialization
	void Start () {
        time = -1.0f;
        cooldownTime = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {

        if (GameVariables.GameMode == GameVariables.GameModes.Hero &&
            GameVariables.PlayerWeapon == GameVariables.PlayerWeapons.Range)
        {
            if (time >= 0)
            {
                time += Time.deltaTime;
            }
            if (cooldownTime < cooldown)
            {
                cooldownTime += Time.deltaTime;
            }
            if (Input.GetMouseButtonDown(0) && cooldownTime > cooldown) //LMB
            {
                time = 0.0f;
            }

            if (Input.GetMouseButtonUp(0) && cooldownTime > cooldown && time > 0) //LMB
            {
                Vector3 bulletPosition = gameObject.transform.position;
                bulletPosition += gameObject.transform.forward * 5.0f;

                GameObject currentBullet = Instantiate(bullet, bulletPosition, gameObject.transform.rotation);
                //currentBullet.transform.Rotate(new Vector3(0, -90.0f, 0));
                if (time > maxTime)
                {
                    time = maxTime;
                }
                currentBullet.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * (time * shootForce + forceOffset));
                //bullet.GetComponent<Rigidbody>.

                time = -1.0f;
                cooldownTime = 0.0f;
            }
        }
	}
    
}
