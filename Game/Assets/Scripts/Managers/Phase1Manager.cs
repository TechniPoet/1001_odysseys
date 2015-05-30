using UnityEngine;
using System.Collections;

public class Phase1Manager : MonoBehaviour {

	public GameObject WorldAsker;
	public GameObject Encounter;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartEncounter()
	{
		WorldAsker.SetActive(false);
		Encounter.SetActive(true);
	}
}
