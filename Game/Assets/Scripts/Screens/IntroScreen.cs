using UnityEngine;
using System.Collections;

public class IntroScreen : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		GameMaster.Instance().LoadEncounters();
		Application.LoadLevel("TitleScreen");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
