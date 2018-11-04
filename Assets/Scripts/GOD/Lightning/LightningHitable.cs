using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LightningHitable : MonoBehaviour {
	
	public abstract void afterHit();
	
	public void instantiate(GameObject obj)
	{
		Instantiate(obj, this.transform.position, this.transform.rotation);
		
	}
}
