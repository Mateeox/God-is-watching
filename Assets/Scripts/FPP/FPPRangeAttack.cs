using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPPRangeAttack : MonoBehaviour
{

    public GameObject bullet;
    public float shootForce = 800.0f;
    public float forceOffset = 200.0f;
    public float maxTime = 1.0f;
    public float cooldown = 0.5f;
    public float time;
    public float cooldownTime;
    public float loadSpeed = 0.01f;
    public float startBulletPosition = 7.0f;
    private GameObject currentBullet;
    private float maxForce;

    // Use this for initialization
    void Start()
    {
        time = -1.0f;
        cooldownTime = 0.0f;
        currentBullet = null;
        maxForce = maxTime * shootForce + forceOffset;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (GameVariables.GameMode == GameVariables.GameModes.Hero &&
            GameVariables.PlayerWeapon == GameVariables.PlayerWeapons.Range)
        {
            if (time >= 0 && time < maxTime)
            {
                time += Time.deltaTime;
            }
            if (cooldownTime < cooldown)
            {
                cooldownTime += Time.deltaTime;
            }
            else
            {

                if (currentBullet == null)
                {
                    Vector3 bulletPosition = gameObject.transform.position;
                    bulletPosition += gameObject.transform.forward * startBulletPosition;
                    currentBullet = Instantiate(bullet, bulletPosition, gameObject.transform.rotation);
                     currentBullet.GetComponent<Rigidbody>().isKinematic = true;
                    currentBullet.GetComponent<Collider>().enabled = false;
                }
                else
                {
                    Vector3 bulletPosition = gameObject.transform.position;
                    bulletPosition += gameObject.transform.forward * (startBulletPosition - 2.0f * time);
                    currentBullet.transform.position = bulletPosition;
                }


            }
            if (Input.GetMouseButtonDown(0) && cooldownTime > cooldown) //LMB
            {

                time = 0.0f;
            }

            if (Input.GetMouseButtonUp(0) && cooldownTime > cooldown && time > 0) //LMB
            {
                if (time > maxTime)
                {
                    time = maxTime;
                }

                currentBullet.GetComponent<Rigidbody>().isKinematic = false;
                currentBullet.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * (time * shootForce + forceOffset));
                currentBullet = null;

                time = -1.0f;
                cooldownTime = 0.0f;
            }
        }
        else if(currentBullet != null)
        {
            Destroy(currentBullet);
        }
    }

}
