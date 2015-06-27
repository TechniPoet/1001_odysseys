using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OdesseyDesigner
{
	public partial class MainForm : Form
	{

		Encounter curr;
		int optionIndex = 0;
		List<string> encountersAvailable;
		HashSet<XMLUtility.EncounterDest> encounterFiles;

		public MainForm()
		{
			InitializeComponent();
			ReadIndex();
			EnableTextBoxes(false);
		}

		void ReadIndex()
		{
			encountersAvailable = new List<string>();
			encounterFiles = XMLUtility.ReadDevIndex();
			EncountersBox.Items.Clear();
			foreach (XMLUtility.EncounterDest enc in encounterFiles)
			{
				string[] brokenFile = enc.fileName.Split('/');
				string encounterFile = brokenFile[brokenFile.Length - 1];
				encountersAvailable.Add(encounterFile);
				EncountersBox.Items.Add(enc.id + " " + encounterFile + ".xml");
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			/*
			EventSearcher.ShowDialog();
			if (EventSearcher.ShowDialog() == DialogResult.OK)
			{
				curr = XMLUtility.ReadEncounter(EventSearcher.FileName);
				IdTextBox.Text = curr.id;
				TitleTextBox.Text = curr.title;
				DescTextBox.Text = curr.description;
				PlanetList.Items.AddRange(curr.planets.ToArray());
				ChangeOption();
				EnableTextBoxes(true);
			}*/
			if (EncountersBox.SelectedIndex != -1)
			{
				curr = XMLUtility.ReadEncounter(encountersAvailable[EncountersBox.SelectedIndex]);
				IdTextBox.Text = curr.id;
				TitleTextBox.Text = curr.title;
				DescTextBox.Text = curr.description;
				PlanetList.Items.Clear();
				PlanetList.Items.AddRange(curr.planets.ToArray());
				ChangeOption();
				EnableTextBoxes(true);
			}

		}

		private void debug_TextChanged(object sender, EventArgs e)
		{

		}

		private void MainForm_Load(object sender, EventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{
			
			if (optionIndex != 0)
			{
				OptionCounter.Text = "1";
				optionIndex = 0;
				ChangeOption();
			}
			
		}
		private void button3_Click(object sender, EventArgs e)
		{
			if (optionIndex != 1)
			{
				OptionCounter.Text = "2";
				optionIndex = 1;
				ChangeOption();
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			if (optionIndex != 2)
			{
				OptionCounter.Text = "3";
				optionIndex = 2;
				ChangeOption();
			}
			
		}

		private void button5_Click(object sender, EventArgs e)
		{
			if (optionIndex != 3)
			{
				OptionCounter.Text = "4";
				optionIndex = 3;
				ChangeOption();
			}
			
		}

		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void ChangeOption()
		{
			if (curr != null)
			{
				bool optionExists = curr.options.Count >= optionIndex + 1;
				OptionDescTextBox.Text = optionExists ? curr.options[optionIndex].choiceText : string.Empty;
				RollInstruxTextBox.Text = optionExists ? curr.options[optionIndex].rollText : string.Empty;
				DiceMinTextBox.Text = optionExists ? curr.options[optionIndex].diceMin.ToString() : string.Empty;
				DiceMaxTextBox.Text = optionExists ? curr.options[optionIndex].diceMax.ToString() : string.Empty;
				SuccessMinTextBox.Text = optionExists ? curr.options[optionIndex].successMin.ToString() : string.Empty;
				SuccessDescTextBox.Text = optionExists ? curr.options[optionIndex].successText : string.Empty;
				FailDescTextBox.Text = optionExists ? curr.options[optionIndex].failText : string.Empty;
				if (!optionExists)
				{
					OptionCounter.Text = (curr.options.Count + 1).ToString();
					optionIndex = curr.options.Count + 1;
				}
			}
		}

		private void SaveOption(object sender, EventArgs e)
		{
			List<string> optionTexts = new List<string> {OptionDescTextBox.Text, RollInstruxTextBox.Text,
				DiceMinTextBox.Text, DiceMaxTextBox.Text, SuccessMinTextBox.Text, SuccessDescTextBox.Text, FailDescTextBox.Text};
			foreach (string s in optionTexts)
			{
				if (string.IsNullOrWhiteSpace(s))
				{
					MessageBox.Show("One of the option textboxes is empty, cannot save.");
					return;
				}
			}
			
			if (curr.options.Count - 1 < optionIndex)
			{
				curr.options.Add(new Option());
			}
			int saveIndex = curr.options.Count - 1;
			curr.options[saveIndex].choiceText = OptionDescTextBox.Text;
			curr.options[saveIndex].rollText = RollInstruxTextBox.Text;
			curr.options[saveIndex].diceMin = int.Parse(DiceMinTextBox.Text);
			curr.options[saveIndex].diceMax = int.Parse(DiceMaxTextBox.Text);
			curr.options[saveIndex].successMin = int.Parse(SuccessMinTextBox.Text);
			curr.options[saveIndex].successText = SuccessDescTextBox.Text;
			curr.options[saveIndex].failText = FailDescTextBox.Text;
		}

		private void IntInputSanitizer(object sender, KeyPressEventArgs e)
		{
			const char Delete = (char)8;
			e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
		}

		private void AddPlanet(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(AddPlanetTextBox.Text) && !PlanetList.Items.Contains(AddPlanetTextBox.Text))
			{
				curr.planets.Add(AddPlanetTextBox.Text);
				PlanetList.Items.Add(AddPlanetTextBox.Text);
				AddPlanetTextBox.Text = string.Empty;
			}
		}

		private void DeleteSelectedPlanets(object sender, EventArgs e)
		{
			while (PlanetList.SelectedIndex != -1)
			{
				curr.planets.RemoveAt(PlanetList.SelectedIndex);
				PlanetList.Items.RemoveAt(PlanetList.SelectedIndex);
			}
		}

		private void SaveEncounterButton_Click(object sender, EventArgs e)
		{
			List<string> required = new List<string> { IdTextBox.Text, TitleTextBox.Text, DescTextBox.Text};
			foreach(string s in required)
			{
				if (string.IsNullOrWhiteSpace(s)) {
					MessageBox.Show("One of the required items is empty, please ensure that there is an ID, Title, and Description set and try again.");
					return;
				}
			}
			if (curr.options.Count < 3) {
				MessageBox.Show("Encounters must have at least 2 options, Please add more and try again.");
				return;
			}
			if (PlanetList.Items.Count <= 0)
			{
				MessageBox.Show("Encounters must have at least 1 planet to occur on.");
				return;
			}
			SaveEncounterValues();
			foreach (XMLUtility.EncounterDest enc in encounterFiles)
			{
				if (IdTextBox.Text == enc.id)
				{
					string confirmation1 = "An Encounter already exists with this id, are you sure you would like to overwrite it?";
					string confirmation2 = "Overwrite Confirmation";
					if (MessageBox.Show(confirmation1, confirmation2, MessageBoxButtons.YesNo) == DialogResult.Yes)
					{
						XMLUtility.WriteEncounter(curr, TitleTextBox.Text.Replace(' ', '_'), false);
						ReadIndex();
						MessageBox.Show(string.Format("File Saved to {0}{1}{2}.xml", XMLUtility.DEV_DIRECTORY, XMLUtility.ENCOUNTERS_DIRECTORY, TitleTextBox.Text.Replace(' ', '_')));
						return;
					}
				}
			}
			XMLUtility.WriteEncounter(curr, TitleTextBox.Text.Replace(' ', '_'), true);
			ReadIndex();
		}

		private void EnableTextBoxes(bool enable)
		{
			foreach (Control c in this.Controls)
			{
				if (c.Name != "LoadButton" && c.Name != "SaveEncounterButton" && c.Name != "NewEncounterButton" && c.Name != "EncountersBox")
				{
					c.Enabled = enable;
				}
			}
		}

		private void NewEncounterButton_Click(object sender, EventArgs e)
		{
			curr = new Encounter();
			IdTextBox.Text = string.Empty;
			TitleTextBox.Text = string.Empty;
			DescTextBox.Text = string.Empty;
			PlanetList.Items.Clear();
			PlanetList.Items.AddRange(curr.planets.ToArray());
			ChangeOption();
			EnableTextBoxes(true);
		}

		private void label3_Click(object sender, EventArgs e)
		{

		}

		void SaveEncounterValues()
		{
			curr.id = IdTextBox.Text;
			curr.title = TitleTextBox.Text;
			curr.description = DescTextBox.Text;
		}
	}
}
