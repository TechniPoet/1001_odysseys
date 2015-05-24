﻿using UnityEngine;
using System.Collections;
using UIWidgets;

public class WorldAskerScreen : MonoBehaviour {
	public Combobox worldCombo;

	// Use this for initialization
	void Start () {
		Debug.Log(worldCombo.ListView.SelectedIndex);
		try
		{
			//worldCombo.Clear();
		}
		catch(System.Exception e)
		{
			Debug.Log("Expected exception from gui system");
		}
		worldCombo.ListView.Add("Endor");
		worldCombo.ListView.Add("Volcan");
		worldCombo.ListView.Remove("Item 1");
		worldCombo.ListView.Remove("Item 2");
		worldCombo.ListView.Remove("Item 3");
		worldCombo.ListView.Remove("Item 4");
		worldCombo.ListView.Remove("Item 5");
		worldCombo.ListView.Select(0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}