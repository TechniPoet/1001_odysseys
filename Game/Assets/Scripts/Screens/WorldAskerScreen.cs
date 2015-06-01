using UnityEngine;
using System.Collections;
using UIWidgets;

public class WorldAskerScreen : MonoBehaviour {
	public Combobox worldCombo;
	GameMaster gm;

	// Use this for initialization
	void Start () {
		gm = GameMaster.Instance();
		//worldCombo.ListView.Add("Endor");
		//worldCombo.ListView.Add("Volcan");
		worldCombo.ListView.Remove("Item 1");
		worldCombo.ListView.Remove("Item 2");
		worldCombo.ListView.Remove("Item 3");
		worldCombo.ListView.Remove("Item 4");
		worldCombo.ListView.Remove("Item 5");
		foreach(string planet in gm.planetList)
		{
			worldCombo.ListView.Add(planet);
		}
			worldCombo.ListView.Select(0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetChosenPlanet()
	{
		gm.CurrentPlanet = worldCombo.ListView.Strings[worldCombo.ListView.SelectedIndex];
	}
}
