using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterHitTerrain : LightningHitable {

	public GameObject afterThunderRemainder;
	
	public override void afterHit()
	{
		Vector3 pos = GameVariables.getPos();
		Instantiate(afterThunderRemainder, new Vector3(pos.x, 0.01f, pos.z), Quaternion.identity);
	}
}
