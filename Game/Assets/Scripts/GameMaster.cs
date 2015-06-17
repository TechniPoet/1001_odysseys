using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class GameMaster
{
	#region Singleton
	static GameMaster singleton = null;

	/// <summary>
	/// Returns the instance of GameMaster or creates a new one.
	/// </summary>
	public static GameMaster Instance() 
	{
		if (GameMaster.singleton == null)
		{
			GameMaster.singleton = new GameMaster();
		}
		return GameMaster.singleton;
	}
	#endregion
	Phase1Manager p1;
	Dictionary<string, Encounter> encounters;
	public List<string> planetList;
	Dictionary<string, List<string>> planetEncounters;
	string currentPlanet;
	Encounter currentEncounter;
	public string CurrentPlanet
	{
		get { return currentPlanet; }
		set
		{
			currentPlanet = value;
			SetEncounter();
		}
	}

	public Encounter CurrentEncounter
	{
		get { return currentEncounter; }
	}

	GameMaster()
	{
		encounters = new Dictionary<string, Encounter>();
		planetList = new List<string>();
		planetEncounters = new Dictionary<string, List<string>>();

	}

	public void LoadEncounters()
	{
		//HashSet<string> encounterFiles = XMLUtility.ReadIndex();
		HashSet<string> encounterFiles = XMLUtility.ReadDevIndex();
		foreach (string s in encounterFiles)
		{
			Encounter temp;
			temp = XMLUtility.ReadEncounter(s, true);
			encounters.Add(temp.id, temp);
		}
		foreach (KeyValuePair<string, Encounter> kp in encounters)
		{
			Encounter tempE = kp.Value;
			List<string> tempList;
			for (int i = 0; i < tempE.planets.Count; i++)
			{
				if (planetList.Contains(tempE.planets[i]))
				{
					tempList = planetEncounters[tempE.planets[i]];
					tempList.Add(tempE.id);
				}
				else
				{
					planetList.Add(tempE.planets[i]);
					tempList = new List<string>();
					tempList.Add(tempE.id);
					planetEncounters.Add(tempE.planets[i], tempList);
				}
			}
		}
	}

	public void SetEncounter()
	{
		List<string> currentEncounters = planetEncounters[currentPlanet];
		int randNum = Random.Range(0, currentEncounters.Count - 1);
		string currEncID = currentEncounters[randNum];
		Debug.Log("current encounter set to " + currEncID);
		currentEncounter = encounters[currEncID];
	}
}
