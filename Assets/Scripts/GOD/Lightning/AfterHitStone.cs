using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterHitStone : LightningHitable {

	public GameObject afterThunderRemainder;
	
	public override void afterHit()
	{
		this.instantiate(afterThunderRemainder);
		Destroy(this.gameObject);
	}
}
