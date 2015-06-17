using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UIWidgets;

public class WorldAskerScreen : MonoBehaviour {
	[SerializeField] Combobox worldCombo;
	[SerializeField] ListView worldList;
	GameMaster gm;

	// Use this for initialization
	void Start () {
		gm = GameMaster.Instance();
		worldList.Strings = gm.planetList;
		/*
		worldCombo.Start();
		//worldCombo.Clear();
		//worldCombo.ListView.Strings = new List<string>();
		List<string> temp = gm.planetList;
		//temp.AddRange(worldCombo.ListView.Strings);
		worldCombo.ListView.Strings = temp;
		 */
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void SetChosenPlanet()
	{
		//gm.CurrentPlanet = worldCombo.ListView.Strings[worldCombo.ListView.SelectedIndex];
		gm.CurrentPlanet = worldList.Strings[worldList.SelectedIndex];
	}
}
