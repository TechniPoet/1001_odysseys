using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EncounterRollScreen : MonoBehaviour {
	public EncounterManager manager;
	public Text instructions;
	public Text generalInstructions;
	public DiceSlider slider;
	Encounter currEncounter;
	Option chosen;


	public void SetupScreen(int choice)
	{
		currEncounter = GameMaster.Instance().CurrentEncounter;
		chosen = currEncounter.options[choice];
		instructions.text = chosen.rollText;
		slider.SetSlider(chosen.diceMin, chosen.diceMax);
	}

	public void SubmitSuccesses()
	{
		manager.MoveToResults(slider.GetValue() >= chosen.successMin);
	}
}
