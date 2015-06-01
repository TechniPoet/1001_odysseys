using UnityEngine;
using System.Collections;

public class Phase1Manager : MonoBehaviour {

	static Phase1Manager singleton = null;
	public GameObject WorldAsker;
	public GameObject Encounter;

	void Start()
	{
		singleton = this;
	}

	public static Phase1Manager Instance()
	{
		return singleton;
	}

	public void StartEncounter()
	{
		WorldAsker.SetActive(false);
		Encounter.SetActive(true);
	}
}
