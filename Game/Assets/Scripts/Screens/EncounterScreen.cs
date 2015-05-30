using UnityEngine;
using System.Collections;

public class EncounterScreen : MonoBehaviour {
	ChoiceButton[] choices = new ChoiceButton[4];
	bool choiceChosen = false;
	int chosenChoiceIndex = -1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	/// <summary>
	/// Callback function for when the submit button is clicked.
	/// </summary>
	public void Submit()
	{
		if (choiceChosen)
		{
			Debug.LogFormat("Submit choice {0}!", chosenChoiceIndex);
		}
		else
		{
			Debug.Log("No choice chosen");
		}
	}


	/// <summary>
	/// Adds a choice to be kept by the encounter screen.
	/// will only accept choices with certain indexes.
	/// </summary>
	public void AddChoice(int choiceNum, ChoiceButton choice)
	{
		if (choiceNum < choices.Length)
		{
			choices[choiceNum] = choice;
		}
		else
		{
			Debug.LogErrorFormat("Choice button attempted to add itself" +  
			"with an index {0} greater than {1}", choiceNum, choices.Length);
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
		for (int i = 0; i < choices.Length; i++ )
		{
			if (choices[i] != null)
			{
				choices[i].Select(i == choiceNum);
			}
		}
	}
}
