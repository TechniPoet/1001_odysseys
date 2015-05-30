using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DiceSlider : MonoBehaviour {
	Text textBox;
	Slider thisSlider;

	// Use this for initialization
	void Start () {
		textBox = GetComponentInChildren<Text>();
		thisSlider = GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
		textBox.text = thisSlider.value.ToString();
	}
}
