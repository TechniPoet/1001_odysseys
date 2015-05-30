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

	public bool IsSelected()
	{
		return selectedMarker.IsActive();
	}


	public void SetText(string newText)
	{
		text.text = newText;
	}

	public void Select(bool makeActive)
	{
		selectedMarker.gameObject.SetActive(makeActive);
	}

	public void ChoiceClicked()
	{
		parent.ChoiceClicked(choiceNum);
	}

}
