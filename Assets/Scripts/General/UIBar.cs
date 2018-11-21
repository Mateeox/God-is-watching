using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBar : MonoBehaviour {

	private Image content;
	public float MaxValue {get; private set;}
	public float Value {get; private set;}

	public void addValue(float valueToAdd)
	{
		if (Value + valueToAdd > MaxValue)
		{
			Value = MaxValue;
		}
		else if (Value + valueToAdd < 0)
		{
			Value = 0;
		}
		else
		{
			Value += valueToAdd;
		}
		content.fillAmount = Value / MaxValue;
	}
	
	public void init(float initValue, float maxValue)
	{
		Value = initValue;
		MaxValue = maxValue;
	}
	private IEnumerator blinkCoroutine()
	{
		Image background = this.transform.parent.gameObject.GetComponent<Image>();
		Color oldColor = background.color;
		background.color = Color.red;
		yield return new WaitForSeconds(.05f);
		background.color = oldColor;
	}
	public void blink()
	{
		StartCoroutine(blinkCoroutine());
	}
	// Use this for initialization
	void Start () {
		content = GetComponent<Image>();
	}
	
	public void boostMaxValue(float newMaxValue)
	{
		RectTransform contentTransform = content.GetComponent<RectTransform>();
		contentTransform.sizeDelta = new Vector2(contentTransform.sizeDelta.x * newMaxValue / MaxValue, contentTransform.sizeDelta.y);
		MaxValue = newMaxValue;
		addValue(newMaxValue);
	}	
}
