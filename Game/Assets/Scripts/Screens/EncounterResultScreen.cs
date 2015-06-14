using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EncounterResultScreen : MonoBehaviour {
	public Text resultText;
	Encounter currEncounter;
	Option chosen;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetupResult(int choiceIndex, bool success)
	{
		currEncounter = GameMaster.Instance().CurrentEncounter;
		chosen = currEncounter.options[choiceIndex];
		resultText.text = success ? chosen.successText : chosen.failText;
	}
}
