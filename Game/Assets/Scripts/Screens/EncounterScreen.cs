using UnityEngine;
using System.Collections;

public class EncounterScreen : MonoBehaviour {
	ChoiceButton[] choices = new ChoiceButton[4];
	bool choiceChosen = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Submit()
	{
		if (choiceChosen)
		{
			Debug.Log("Submit!");
		}
		else
		{
			Debug.Log("No choice chosen");
		}
	}


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


	public void ChoiceClicked(int choiceNum)
	{
		choiceChosen = true;
		for (int i = 0; i < choices.Length; i++ )
		{
			if (choices[i] != null)
			{
				choices[i].Select(i == choiceNum);
			}
		}
	}
}
