using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyBehavior : Enemy
{
    public float afterDeadParticlesCooldown;
    public float afterDeadParticlesTimer;
    // Start is called before the first frame update
    void Start()
    {
        afterDeadParticlesTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(health < 0)
        {
            if(afterDeadParticlesTimer < afterDeadParticlesCooldown)
            {
                afterDeadParticlesTimer += Time.deltaTime;
            }
            else
            {
                afterDeadParticlesTimer = 0.0f;
                Instantiate(bloodParticles, gameObject.transform.position, new Quaternion()); // generate blood effect
            }
            
        }
        
    }
}
