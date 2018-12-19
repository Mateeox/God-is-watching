using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessGateBehaviour : MonoBehaviour {
	
	public float endVerticalPosition = -22.3f;
	
	public void Open() {
		Vector3 endPosition = transform.position;
		endPosition.y = endVerticalPosition;
		StartCoroutine(MoveOverSeconds(endPosition, 5));
	}
	
	public IEnumerator MoveOverSeconds(Vector3 end, float seconds) {
		float elapsedTime = 0;
		Vector3 startingPos = this.transform.position;
		while (elapsedTime < seconds) 
		{
			this.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
			elapsedTime += Time.deltaTime;
			Debug.LogWarning(transform.position);
			yield return new WaitForEndOfFrame();
		}
		this.transform.position = end;
	}

}
