using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}


	/// <summary>
	/// Launches Setup for game loop.
	/// </summary>
	public void StartGame()
	{
		Application.LoadLevel("Phase1");
	}


	/// <summary>
	/// Opens the popup for settings.
	/// </summary>
	public void OpenSettings()
	{
		Debug.Log("Opening Settings");
	}


	/// <summary>
	/// Opens game website 
	/// </summary>
	public void OpenWebsite()
	{
		Debug.Log("Opening Website");
	}


	/// <summary>
	/// Opens the rules.
	/// </summary>
	public void OpenRules()
	{
		Debug.Log("Opening Rules");
	}
}
