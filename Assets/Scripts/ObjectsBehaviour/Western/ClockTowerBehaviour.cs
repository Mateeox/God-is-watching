using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockTowerBehaviour : MonoBehaviour
{
	[SerializeField]
	private float attachmentTime;
	[SerializeField]
	private float trainMovementTime;
	[SerializeField]
	private GameObject train;
	private bool oneHandAttached = false;
	private Vector3 finalPositionOnClock = new Vector3(-0.47f, 6.076f, 0.42f);
	
    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
	{
		
    }
	
	public IEnumerator AttachHandToClock(Transform objectToMove, Vector3 newPosition, Quaternion newRotation, float time)
	{
		float elapsedTime = 0.1f;
		Vector3 startingPos = objectToMove.localPosition;
		Quaternion startingRotation = objectToMove.localRotation;
		while (elapsedTime < time)
		{
			objectToMove.localPosition = Vector3.Lerp(startingPos, newPosition, (elapsedTime / time));
			objectToMove.localRotation = Quaternion.Lerp(startingRotation , newRotation, (elapsedTime / time));
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		Destroy(objectToMove.gameObject.GetComponent<ObjectGodMove>());
		Destroy(objectToMove.gameObject.GetComponent<Rigidbody>());
		objectToMove.localPosition = newPosition;
		if (oneHandAttached)
		{
			Vector3 newPos = new Vector3(train.transform.position.x, train.transform.position.y, train.transform.position.z - 120.0f);
			StartCoroutine(moveTrain(trainMovementTime, newPos));
		}
		else
		{
			oneHandAttached = true;
		}
	}
	
	private void OnTriggerEnter(Collider other)
    {
		//the magic numbers here are appropriate position/rotation coords of hands attached to the clock
		if (other.CompareTag("ClockHandMinute"))
		{
			Quaternion newRotation = Quaternion.identity;
			newRotation.eulerAngles = new Vector3(90.0f, 90.0f, 90.0f);
			StartCoroutine(AttachHandToClock(other.transform, finalPositionOnClock, newRotation, attachmentTime));
		}
		
		else if (other.CompareTag("ClockHandHour"))
		{
			Quaternion newRotation = Quaternion.identity;
			newRotation.eulerAngles = new Vector3(0.0f, 270.0f, 270.0f);
			StartCoroutine(AttachHandToClock(other.transform, finalPositionOnClock, newRotation, attachmentTime));
		}
	}
	
	public IEnumerator moveTrain(float time, Vector3 newPosition)
	{
		float elapsedTime = 0.1f;
		Vector3 startingPos = train.transform.position;
		while (elapsedTime < time)
		{
			train.transform.position = Vector3.Lerp(startingPos, newPosition, (elapsedTime / time));
			elapsedTime += Time.deltaTime;
			yield return null;
		}
	}
}
