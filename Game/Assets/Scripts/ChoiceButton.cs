using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChoiceButton : MonoBehaviour{
	public Image selectedMarker;
	public Text text;
	public int choiceNum = -1;
	EncounterScreen parent;

	// Use this for initialization
	void Start () {
		parent = GetComponentInParent<EncounterScreen>();
		if (parent == null)
		{
			throw new System.Exception("Could not find Parent EncounterScreen script");
		}
		if (choiceNum < 0)
		{
			throw new System.Exception("choice number not set");
		}
		parent.AddChoice(choiceNum, this);
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
