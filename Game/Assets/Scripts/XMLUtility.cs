using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public static class XMLUtility
{
	#region Encounter Elements and Attributes
	const string ENCOUNTER_ELEMENT = "encounter";
	const string ID_ATTRIBUTE = "id";
	const string TITLE_ELEMENT = "title";
	const string DESC_ELEMENT = "description";
	const string TRIGGER_ELEMENT = "trigger";
	const string LOCATIONS_ELEMENT = "locations";
	const string LOCATION_ELEMENT = "location";
	const string CREW_INFO_ELEMENT = "crewinfo";
	const string CREW_ELEMENT = "crew";
	const string RACE_ELEMENT = "race";
	const string CHOICES_ELEMENT = "choices";
	const string OPTION_ELEMENT = "option";
	const string TEXT_ELEMENT = "text";
	const string CHOSEN_ELEMENT = "chosen";
	const string ROLL_TEXT_ELEMENT = "roll_text";
	const string DICE_ELEMENT = "dice";
	const string SUCCESS_ELEMENT = "success";
	const string FAILURE_ELEMENT = "failure";
	const string ADD_ELEMENT = "add";
	#endregion
	const string INDEX_FILE = "index";


	public static HashSet<string> ReadIndex()
	{
		HashSet<string>  encounters = new HashSet<string>();
		XmlDocument xmlDoc = new XmlDocument();
		TextAsset xmlData = new TextAsset();
		xmlData = (TextAsset)Resources.Load(INDEX_FILE, typeof(TextAsset));
		xmlDoc.LoadXml(xmlData.text);
		XmlNode filesNode = xmlDoc.GetElementsByTagName("encounterfiles")[0];
		foreach (XmlNode x in filesNode.ChildNodes)
		{
			encounters.Add(x.Attributes["fileName"].Value);
		}
		return encounters;
	}

	public static Encounter ReadEncounter(string fileName)
	{
		Debug.Log("Reading in encounter " + fileName);
		Encounter encounterCurr = new Encounter();
		// Load file.
		XmlDocument xmlDoc = new XmlDocument();
		TextAsset xmlData = new TextAsset();
		xmlData = (TextAsset)Resources.Load("Encounters/" + fileName, typeof(TextAsset));
		xmlDoc.LoadXml(xmlData.text);
		// Get encapsolating encounter node.
		XmlNode encounterNode = xmlDoc.GetElementsByTagName(ENCOUNTER_ELEMENT)[0];
		ReadEncounterAttributes(encounterNode, ref encounterCurr);

		XmlNodeList childNodes = encounterNode.ChildNodes;
		try
		{
			foreach (XmlNode node in childNodes)
			{
				switch (node.Name)
				{
					case TITLE_ELEMENT:
						Debug.Log("reading in title");
						encounterCurr.title = node.InnerText;
						break;
					case DESC_ELEMENT:
						Debug.Log("reading in description");
						encounterCurr.description = node.InnerText;
						break;
					case TRIGGER_ELEMENT:
						Debug.Log("reading in trigger element");
						ReadTriggerElement(node, ref encounterCurr);
						break;
					case CHOICES_ELEMENT:
						Debug.Log("reading in choices element");
						ReadChoicesElement(node, ref encounterCurr);
						break;
					default:
						break;
				}
			}
		}
		catch (System.Exception e)
		{
			Debug.LogErrorFormat("Exception" + e.Message);
		}
		return encounterCurr;
	}


	//
	static void ReadEncounterAttributes(XmlNode node, ref Encounter encounterCurr)
	{
		foreach (XmlAttribute a in node.Attributes)
		{
			switch (a.Name)
			{
				case ID_ATTRIBUTE:
					encounterCurr.id = a.Value;
					break;
				default:
					break;
			}
		}
	}

	static void ReadTriggerElement(XmlNode node, ref Encounter encounterCurr)
	{
		foreach (XmlNode n in node.ChildNodes)
		{
			switch (n.Name)
			{
				case LOCATIONS_ELEMENT:
					Debug.Log("reading in locations");
					ReadLocations(n, ref encounterCurr);
					break;
				case CREW_INFO_ELEMENT:
					//read in crew info.
					break;
			}
		}
	}


	static void ReadLocations(XmlNode node, ref Encounter encounterCurr)
	{
		foreach (XmlNode n in node.ChildNodes)
		{
			switch (n.Name)
			{
				case LOCATION_ELEMENT:
					Debug.Log("reading in location");
					encounterCurr.planets.Add(n.InnerText);
					break;
			}
		}
	}


	static void ReadChoicesElement(XmlNode node, ref Encounter encounterCurr)
	{
		foreach (XmlNode n in node.ChildNodes)
		{
			switch (n.Name)
			{
				case OPTION_ELEMENT:
					Debug.Log("reading in " + OPTION_ELEMENT);
					Option newOption = new Option();
					Debug.Log("reading in " + TEXT_ELEMENT);
					newOption.choiceText = n.SelectSingleNode(TEXT_ELEMENT).InnerText;
					
					XmlNode success = n.SelectSingleNode(SUCCESS_ELEMENT);
					Debug.Log("reading in " + DICE_ELEMENT);
					XmlNode dice = n.SelectSingleNode(DICE_ELEMENT);

					foreach (XmlAttribute x in dice.Attributes)
					{
						switch (x.Name)
						{
							case "min":
								newOption.diceMin = int.Parse(x.Value);
								break;
							case "max":
								newOption.diceMax = int.Parse(x.Value);
								break;
						}
					}
					Debug.Log("reading in " + SUCCESS_ELEMENT);
					foreach (XmlAttribute x in success.Attributes)
					{
						switch (x.Name)
						{
							case "min":
								newOption.successMin = int.Parse(x.Value);
								break;
						}
					}
					Debug.Log("reading in " + SUCCESS_ELEMENT + " " + TEXT_ELEMENT);
					newOption.successText = success.SelectSingleNode(TEXT_ELEMENT).InnerText;
					Debug.Log("reading in " + ROLL_TEXT_ELEMENT);
					newOption.rollText = n.SelectSingleNode(ROLL_TEXT_ELEMENT).InnerText;
					Debug.Log("reading in " + FAILURE_ELEMENT + " " + TEXT_ELEMENT);
					newOption.failText = n.SelectSingleNode(FAILURE_ELEMENT).SelectSingleNode(TEXT_ELEMENT).InnerText;
					encounterCurr.options.Add(newOption);
					break;
			}
		}
	}
}
