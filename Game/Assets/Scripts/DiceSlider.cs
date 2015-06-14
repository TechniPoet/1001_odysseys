using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DiceSlider : MonoBehaviour {
	Text textBox;
	Slider thisSlider;
	int min = 0;
	int max = 1;

	// Use this for initialization
	void Start () {
		textBox = GetComponentInChildren<Text>();
		thisSlider = GetComponent<Slider>();
		thisSlider.minValue = min;
		thisSlider.maxValue = max;
	}
	
	// Update is called once per frame
	void Update () {
		textBox.text = thisSlider.value.ToString();
	}

	public void SetSlider(int newMin, int newMax)
	{
		min = newMin;
		max = newMax;

		if (thisSlider != null)
		{
			thisSlider.minValue = newMin;
			thisSlider.maxValue = newMax;
		}
	}

	public int GetValue()
	{
		return (int)thisSlider.value;
	}
}
