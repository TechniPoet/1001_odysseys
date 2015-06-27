using System.Collections;
using System.Collections.Generic;

public class Encounter {
	public string id, title, description;
	public List<string> planets;
	public List<Option> options;

	public Encounter()
	{
		id = "";
		title = "";
		description = "";
		planets = new List<string>();
		options = new List<Option>();
	}
}

public class Option
{
	public string choiceText = "";
	public string rollText = "";
	public int diceMin = 0;
	public int diceMax = 0;
	public int successMin = 0;
	public string successText = "";
	public string failText = "";

	public Option()
	{

	}
}

