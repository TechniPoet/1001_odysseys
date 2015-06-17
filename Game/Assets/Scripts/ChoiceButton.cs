using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChoiceButton : MonoBehaviour{
	public Image selectedMarker;
	public Text text;
	int choiceNum = -1;
	EncounterChoiceScreen parent;

	// Use this for initialization
	void Start () {
	}


	public void SetChoiceButton(int num, string newText, EncounterChoiceScreen newParent)
	{
		choiceNum = num;
		text.text = newText;
		parent = newParent;
		this.gameObject.SetActive(true);
	}


	/// <summary>
	/// Sets the text on the button
	/// </summary>
	/// <param name="newText">text to be put on button</param>
	public void SetText(string newText)
	{
		text.text = newText;
	}


	/// <summary>
	/// Makes selected marker active state match given bool.
	/// </summary>
	public void Select(bool makeActive)
	{
		selectedMarker.gameObject.SetActive(makeActive);
	}


	/// <summary>
	/// Callback function for when this button is clicked.
	/// Tells the Encounter script that it has been clicked.
	/// </summary>
	public void ChoiceClicked()
	{
		parent.ChoiceClicked(choiceNum);
	}

}
