using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Diagnostics;
using System.IO;

public static class XMLUtility
{

	public struct EncounterDest
	{
		public string id;
		public string fileName;

		public EncounterDest(string id, string fileName)
		{
			this.id = id;
			this.fileName = fileName;
		}
	}
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
	public const string DEV_DIRECTORY = "C:/1001Devs/";
	public const string ENCOUNTERS_DIRECTORY = "Encounters/";

	#region READ

	public static HashSet<EncounterDest> ReadDevIndex()
	{
		EncounterDest temp;
		HashSet<EncounterDest> encounters = new HashSet<EncounterDest>();
		XmlDocument xmlDoc = new XmlDocument();
		using (XmlTextReader reader = new XmlTextReader(DEV_DIRECTORY + INDEX_FILE + ".xml"))
		{
			xmlDoc.Load(reader);
			XmlNode filesNode = xmlDoc.GetElementsByTagName("encounterfiles")[0];
			foreach (XmlNode x in filesNode.ChildNodes)
			{
				string fileName = x.Attributes["fileName"].Value;
				string id = x.Attributes["id"].Value;
				temp = new EncounterDest(id, fileName);
				encounters.Add(temp);
			}
			reader.Close();
		}
		return encounters;
	}

	public static Encounter ReadEncounter(string file)
	{
		Encounter encounterCurr = new Encounter();
		// Load file.
		XmlDocument xmlDoc = new XmlDocument();
		using (XmlTextReader reader = new XmlTextReader(DEV_DIRECTORY + ENCOUNTERS_DIRECTORY + file + ".xml"))
		{
			xmlDoc.Load(reader);

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
							encounterCurr.title = node.InnerText;
							break;
						case DESC_ELEMENT:
							encounterCurr.description = node.InnerText;
							break;
						case TRIGGER_ELEMENT:
							ReadTriggerElement(node, ref encounterCurr);
							break;
						case CHOICES_ELEMENT:
							ReadChoicesElement(node, ref encounterCurr);
							break;
						default:
							break;
					}
				}
			}
			catch (System.Exception e)
			{
				Debug.WriteLine("Exception" + e.Message);
			}
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
					Debug.WriteLine("reading in locations");
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
					Debug.WriteLine("reading in location");
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
					Debug.WriteLine("reading in " + OPTION_ELEMENT);
					Option newOption = new Option();
					Debug.WriteLine("reading in " + TEXT_ELEMENT);
					newOption.choiceText = n.SelectSingleNode(TEXT_ELEMENT).InnerText;
					
					XmlNode success = n.SelectSingleNode(SUCCESS_ELEMENT);
					Debug.WriteLine("reading in " + DICE_ELEMENT);
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
					Debug.WriteLine("reading in " + SUCCESS_ELEMENT);
					foreach (XmlAttribute x in success.Attributes)
					{
						switch (x.Name)
						{
							case "min":
								newOption.successMin = int.Parse(x.Value);
								break;
						}
					}
					Debug.WriteLine("reading in " + SUCCESS_ELEMENT + " " + TEXT_ELEMENT);
					newOption.successText = success.SelectSingleNode(TEXT_ELEMENT).InnerText;
					Debug.WriteLine("reading in " + ROLL_TEXT_ELEMENT);
					newOption.rollText = n.SelectSingleNode(ROLL_TEXT_ELEMENT).InnerText;
					Debug.WriteLine("reading in " + FAILURE_ELEMENT + " " + TEXT_ELEMENT);
					newOption.failText = n.SelectSingleNode(FAILURE_ELEMENT).SelectSingleNode(TEXT_ELEMENT).InnerText;
					encounterCurr.options.Add(newOption);
					break;
			}
		}
	}

	#endregion

	#region WRITE


	public static void UpdateIndex(Encounter newEnc, string saveName, bool newElement)
	{
		XmlDocument xmlDoc = new XmlDocument();
		/*
		XmlTextReader reader = new XmlTextReader(DEV_DIRECTORY + INDEX_FILE + ".xml");
		xmlDoc.Load(reader);
		 * */
		xmlDoc.Load(DEV_DIRECTORY + INDEX_FILE + ".xml");
		XmlNode filesNode = xmlDoc.GetElementsByTagName("encounterfiles")[0];
		if (newElement)
		{
			XmlElement newNode = (XmlElement) xmlDoc.CreateNode(XmlNodeType.Element, "encounter", null);
			newNode.SetAttribute("id", newEnc.id);
			newNode.SetAttribute("fileName", saveName);
			filesNode.AppendChild(newNode);
		}
		else
		{
			foreach (XmlNode node in filesNode.ChildNodes)
			{
				if (node.Attributes["id"].Value == newEnc.id) {
					File.Delete(DEV_DIRECTORY + ENCOUNTERS_DIRECTORY + node.Attributes["fileName"] + ".xml");
					XmlElement newNode = xmlDoc.CreateElement("encounter");
					newNode.SetAttribute("id", newEnc.id);
					newNode.SetAttribute("fileName", saveName);
					filesNode.ReplaceChild(newNode, node);
					break;
				}
			}
		}
		xmlDoc.Save(DEV_DIRECTORY + INDEX_FILE + ".xml");
	}


	public static void WriteEncounter(Encounter encounter, string saveName, bool newElement)
	{
		if (File.Exists(DEV_DIRECTORY + ENCOUNTERS_DIRECTORY + saveName + ".xml"))
		{
			File.Delete(DEV_DIRECTORY + ENCOUNTERS_DIRECTORY + saveName + ".xml");
		}
		using (StreamWriter textWriter = File.CreateText(DEV_DIRECTORY + ENCOUNTERS_DIRECTORY + saveName + ".xml"))
		{
			XmlWriterSettings settings = new XmlWriterSettings();
			XmlTextWriter writer = new XmlTextWriter(textWriter);
			writer.Formatting = Formatting.Indented;

			writer.WriteStartDocument();

			writer.WriteStartElement(ENCOUNTER_ELEMENT);
				writer.WriteAttributeString(ID_ATTRIBUTE, encounter.id);

			writer.WriteStartElement(TITLE_ELEMENT);
				writer.WriteString(encounter.title);
			writer.WriteEndElement();

			writer.WriteStartElement(DESC_ELEMENT);
				writer.WriteString(encounter.description);
			writer.WriteEndElement();

			writer.WriteStartElement(TRIGGER_ELEMENT);
				writer.WriteStartElement(LOCATIONS_ELEMENT);
				foreach (string location in encounter.planets)
				{
					writer.WriteStartElement(LOCATION_ELEMENT);
						writer.WriteString(location);
					writer.WriteEndElement();
				}
				writer.WriteEndElement();
			writer.WriteEndElement();

			writer.WriteStartElement(CHOICES_ELEMENT);
			foreach (Option op in encounter.options)
			{
				writer.WriteStartElement(OPTION_ELEMENT);

					writer.WriteStartElement(TEXT_ELEMENT);
						writer.WriteString(op.choiceText);
					writer.WriteEndElement();

					writer.WriteStartElement(ROLL_TEXT_ELEMENT);
						writer.WriteString(op.rollText);
					writer.WriteEndElement();

					writer.WriteStartElement(DICE_ELEMENT);
						writer.WriteAttributeString("min", op.diceMin.ToString());
						writer.WriteAttributeString("max", op.diceMax.ToString());
					writer.WriteEndElement();

					writer.WriteStartElement(SUCCESS_ELEMENT);
						writer.WriteAttributeString("min", op.successMin.ToString());

						writer.WriteStartElement(TEXT_ELEMENT);
							writer.WriteString(op.successText);
						writer.WriteEndElement();
					writer.WriteEndElement();

					writer.WriteStartElement(FAILURE_ELEMENT);
						writer.WriteStartElement(TEXT_ELEMENT);
							writer.WriteString(op.failText);
						writer.WriteEndElement();
					writer.WriteEndElement();

				writer.WriteEndElement();
			}
			writer.WriteEndElement();

			writer.WriteEndElement();
			writer.WriteEndDocument();
			writer.Close();
			textWriter.Close();
		}
		UpdateIndex(encounter, saveName, newElement);
	}

	#endregion

}
