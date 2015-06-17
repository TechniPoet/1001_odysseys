using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EncounterChoiceScreen : MonoBehaviour {
	public EncounterManager manager;
	public ChoiceButton[] choices;
	public Text title;
	public Text description;

	bool choiceChosen = false;
	int chosenChoiceIndex = -1;
	Encounter currEncounter;
	// Use this for initialization
	void Start () {
	}

	void Awake()
	{
		currEncounter = GameMaster.Instance().CurrentEncounter;
		Debug.Log(currEncounter.options.Count + " choices");
		for (int i = 0; i < currEncounter.options.Count; i++)
		{
			Option tempOpt = currEncounter.options[i];
			choices[i].SetChoiceButton(i, tempOpt.choiceText, this);
			Debug.Log("starting " + i);
		}
		title.text = currEncounter.title;
		description.text = currEncounter.description;
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	/// <summary>
	/// Callback function for when the submit button is clicked.
	/// </summary>
	public void SubmitChoice()
	{
		if (choiceChosen)
		{
			Debug.LogFormat("Submit choice {0}!", chosenChoiceIndex);
			manager.MoveToRoll(chosenChoiceIndex);
		}
		else
		{
			Debug.Log("No choice chosen");
		}
	}


	/// <summary>
	/// Method called by choices when they are clicked.
	/// marks given choice as selected and marks the rest unselected.
	/// </summary>
	/// <param name="choiceNum"></param>
	public void ChoiceClicked(int choiceNum)
	{
		choiceChosen = true;
		chosenChoiceIndex = choiceNum;
		for (int i = 0; i < choices.Length; i++)
		{
			if (choices[i] != null)
			{
				choices[i].Select(i == choiceNum);
			}
		}
	}
}
