using UnityEngine;

using System.Collections;

public class EncounterManager : MonoBehaviour 
{
	public GameObject encounterChoices;
	public GameObject encounterInstructs;
	public GameObject encounterResults;

	public EncounterChoiceScreen choiceScreen;
	public EncounterRollScreen rollScreen;
	public EncounterResultScreen resultScreen;
	int choiceIndex = 0;

	void Awake()
	{
		choiceScreen.manager = this;
		rollScreen.manager = this;

		encounterChoices.SetActive(true);
		encounterInstructs.SetActive(false);
		encounterResults.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void MoveToRoll(int choiceNum)
	{
		choiceIndex = choiceNum;
		rollScreen.SetupScreen(choiceNum);
		encounterChoices.SetActive(false);
		encounterResults.SetActive(false);
		encounterInstructs.SetActive(true);
	}


	public void MoveToResults(bool success)
	{
		resultScreen.SetupResult(choiceIndex, success);
		encounterChoices.SetActive(false);
		encounterResults.SetActive(true);
		encounterInstructs.SetActive(false);
	}

	public void MoveToMainMenu()
	{
		Application.LoadLevel("TitleScreen");
	}

	public void MoveToNextEncounter()
	{
		Application.LoadLevel("Phase1");
	}

}
