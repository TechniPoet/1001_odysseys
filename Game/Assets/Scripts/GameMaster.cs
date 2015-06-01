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
	public HashSet<string> planetList;
	Dictionary<string, HashSet<string>> planetEncounters;
	string currentPlanet;
	public string CurrentPlanet
	{
		get { return currentPlanet; }
		set
		{
			currentPlanet = value;
		}
	}

	GameMaster()
	{
		encounters = new Dictionary<string, Encounter>();
		planetList = new HashSet<string>();
		planetEncounters = new Dictionary<string, HashSet<string>>();
	}

	public void LoadEncounters()
	{
		foreach (string s in XMLUtility.ReadIndex())
		{
			Encounter temp;
			temp = XMLUtility.ReadEncounter(s);
			encounters.Add(temp.id, temp);
		}
		foreach (KeyValuePair<string, Encounter> kp in encounters)
		{
			Encounter tempE = kp.Value;
			HashSet<string> tempHashset;
			for (int i = 0; i < tempE.planets.Count; i++)
			{
				if (planetList.Contains(tempE.planets[i]))
				{
					tempHashset = planetEncounters[tempE.planets[i]];
					tempHashset.Add(tempE.id);
				}
				else
				{
					tempHashset = new HashSet<string>();
					tempHashset.Add(tempE.id);
					planetEncounters.Add(tempE.planets[i], tempHashset);
				}
			}
		}
	}
}
