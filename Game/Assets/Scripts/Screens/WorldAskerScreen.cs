using UnityEngine;
using System.Collections;
using UIWidgets;

public class WorldAskerScreen : MonoBehaviour {
	public Combobox worldCombo;
	GameMaster gm;

	// Use this for initialization
	void Start () {
		gm = GameMaster.Instance();
		worldCombo.Start();
		foreach (string s in worldCombo.ListView.Strings) {
			worldCombo.ListView.Remove(s);
		}
		//worldCombo.Clear();
		foreach(string planet in gm.planetList)
		{
			worldCombo.ListView.Add(planet);
		}
		//worldCombo.ListView.Select(0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetChosenPlanet()
	{
		gm.CurrentPlanet = worldCombo.ListView.Strings[worldCombo.ListView.SelectedIndex];
	}
}
