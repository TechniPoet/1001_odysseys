 namespace OdesseyDesigner
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.LoadButton = new System.Windows.Forms.Button();
			this.EventSearcher = new System.Windows.Forms.OpenFileDialog();
			this.DescTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.TitleTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.OptionCounter = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.IdTextBox = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.OptionDescTextBox = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.RollInstruxTextBox = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.DiceMinTextBox = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.DiceMaxTextBox = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.SuccessMinTextBox = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.SuccessDescTextBox = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.FailDescTextBox = new System.Windows.Forms.TextBox();
			this.OptionSaveButton = new System.Windows.Forms.Button();
			this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
			this.AddPlanetTextBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.AddPlanetButton = new System.Windows.Forms.Button();
			this.DeletePlanetsButton = new System.Windows.Forms.Button();
			this.PlanetList = new System.Windows.Forms.ListBox();
			this.SaveEncounterButton = new System.Windows.Forms.Button();
			this.NewEncounterButton = new System.Windows.Forms.Button();
			this.EncountersBox = new System.Windows.Forms.ListBox();
			((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
			this.SuspendLayout();
			// 
			// LoadButton
			// 
			this.LoadButton.Location = new System.Drawing.Point(469, 63);
			this.LoadButton.Name = "LoadButton";
			this.LoadButton.Size = new System.Drawing.Size(122, 30);
			this.LoadButton.TabIndex = 0;
			this.LoadButton.Text = "Load Encounter";
			this.LoadButton.UseVisualStyleBackColor = true;
			this.LoadButton.Click += new System.EventHandler(this.button1_Click);
			// 
			// DescTextBox
			// 
			this.DescTextBox.AcceptsReturn = true;
			this.DescTextBox.AllowDrop = true;
			this.DescTextBox.Location = new System.Drawing.Point(468, 296);
			this.DescTextBox.MaximumSize = new System.Drawing.Size(600, 300);
			this.DescTextBox.MinimumSize = new System.Drawing.Size(30, 100);
			this.DescTextBox.Multiline = true;
			this.DescTextBox.Name = "DescTextBox";
			this.DescTextBox.Size = new System.Drawing.Size(600, 100);
			this.DescTextBox.TabIndex = 1;
			this.DescTextBox.TextChanged += new System.EventHandler(this.debug_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(465, 276);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(148, 17);
			this.label1.TabIndex = 2;
			this.label1.Text = "Encounter Description";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(35, 41);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 4;
			this.button2.Text = "Option 1";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// TitleTextBox
			// 
			this.TitleTextBox.Location = new System.Drawing.Point(468, 251);
			this.TitleTextBox.Name = "TitleTextBox";
			this.TitleTextBox.Size = new System.Drawing.Size(600, 22);
			this.TitleTextBox.TabIndex = 5;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(465, 231);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(104, 17);
			this.label2.TabIndex = 6;
			this.label2.Text = "Encounter Title";
			this.label2.Click += new System.EventHandler(this.label2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(116, 41);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 8;
			this.button3.Text = "Option 2";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(197, 41);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 23);
			this.button4.TabIndex = 9;
			this.button4.Text = "Option 3";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(278, 41);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(75, 23);
			this.button5.TabIndex = 10;
			this.button5.Text = "Option 4";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// OptionCounter
			// 
			this.OptionCounter.AutoSize = true;
			this.OptionCounter.Location = new System.Drawing.Point(137, 18);
			this.OptionCounter.Name = "OptionCounter";
			this.OptionCounter.Size = new System.Drawing.Size(16, 17);
			this.OptionCounter.TabIndex = 11;
			this.OptionCounter.Text = "1";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(30, 18);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(101, 17);
			this.label4.TabIndex = 12;
			this.label4.Text = "Current Option";
			// 
			// IdTextBox
			// 
			this.IdTextBox.Location = new System.Drawing.Point(468, 206);
			this.IdTextBox.Name = "IdTextBox";
			this.IdTextBox.Size = new System.Drawing.Size(281, 22);
			this.IdTextBox.TabIndex = 13;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(465, 186);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(90, 17);
			this.label5.TabIndex = 14;
			this.label5.Text = "Encounter ID";
			// 
			// OptionDescTextBox
			// 
			this.OptionDescTextBox.Location = new System.Drawing.Point(35, 99);
			this.OptionDescTextBox.Multiline = true;
			this.OptionDescTextBox.Name = "OptionDescTextBox";
			this.OptionDescTextBox.Size = new System.Drawing.Size(318, 56);
			this.OptionDescTextBox.TabIndex = 15;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(32, 79);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(81, 17);
			this.label6.TabIndex = 16;
			this.label6.Text = "Option Text";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(30, 171);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(108, 17);
			this.label7.TabIndex = 17;
			this.label7.Text = "Roll Instructions";
			// 
			// RollInstruxTextBox
			// 
			this.RollInstruxTextBox.Location = new System.Drawing.Point(33, 191);
			this.RollInstruxTextBox.Name = "RollInstruxTextBox";
			this.RollInstruxTextBox.Size = new System.Drawing.Size(318, 22);
			this.RollInstruxTextBox.TabIndex = 18;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(32, 227);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(36, 17);
			this.label8.TabIndex = 19;
			this.label8.Text = "Dice";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(30, 254);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(192, 17);
			this.label9.TabIndex = 20;
			this.label9.Text = "Minimum Possible Successes";
			// 
			// DiceMinTextBox
			// 
			this.DiceMinTextBox.Location = new System.Drawing.Point(248, 249);
			this.DiceMinTextBox.Name = "DiceMinTextBox";
			this.DiceMinTextBox.Size = new System.Drawing.Size(81, 22);
			this.DiceMinTextBox.TabIndex = 21;
			this.DiceMinTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntInputSanitizer);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(30, 286);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(195, 17);
			this.label10.TabIndex = 22;
			this.label10.Text = "Maximum Possible Successes";
			// 
			// DiceMaxTextBox
			// 
			this.DiceMaxTextBox.Location = new System.Drawing.Point(248, 281);
			this.DiceMaxTextBox.Name = "DiceMaxTextBox";
			this.DiceMaxTextBox.Size = new System.Drawing.Size(81, 22);
			this.DiceMaxTextBox.TabIndex = 23;
			this.DiceMaxTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntInputSanitizer);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(32, 319);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(213, 17);
			this.label11.TabIndex = 24;
			this.label11.Text = "Minimum Successes for Success";
			// 
			// SuccessMinTextBox
			// 
			this.SuccessMinTextBox.Location = new System.Drawing.Point(248, 314);
			this.SuccessMinTextBox.Name = "SuccessMinTextBox";
			this.SuccessMinTextBox.Size = new System.Drawing.Size(81, 22);
			this.SuccessMinTextBox.TabIndex = 25;
			this.SuccessMinTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntInputSanitizer);
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(32, 346);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(92, 17);
			this.label12.TabIndex = 26;
			this.label12.Text = "Success Text";
			// 
			// SuccessDescTextBox
			// 
			this.SuccessDescTextBox.Location = new System.Drawing.Point(35, 366);
			this.SuccessDescTextBox.Multiline = true;
			this.SuccessDescTextBox.Name = "SuccessDescTextBox";
			this.SuccessDescTextBox.Size = new System.Drawing.Size(318, 85);
			this.SuccessDescTextBox.TabIndex = 27;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(32, 464);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(82, 17);
			this.label13.TabIndex = 28;
			this.label13.Text = "Failure Text";
			// 
			// FailDescTextBox
			// 
			this.FailDescTextBox.Location = new System.Drawing.Point(33, 484);
			this.FailDescTextBox.Multiline = true;
			this.FailDescTextBox.Name = "FailDescTextBox";
			this.FailDescTextBox.Size = new System.Drawing.Size(316, 83);
			this.FailDescTextBox.TabIndex = 29;
			// 
			// OptionSaveButton
			// 
			this.OptionSaveButton.Location = new System.Drawing.Point(243, 589);
			this.OptionSaveButton.Name = "OptionSaveButton";
			this.OptionSaveButton.Size = new System.Drawing.Size(106, 32);
			this.OptionSaveButton.TabIndex = 30;
			this.OptionSaveButton.Text = "Save Option";
			this.OptionSaveButton.UseVisualStyleBackColor = true;
			this.OptionSaveButton.Click += new System.EventHandler(this.SaveOption);
			// 
			// fileSystemWatcher1
			// 
			this.fileSystemWatcher1.EnableRaisingEvents = true;
			this.fileSystemWatcher1.SynchronizingObject = this;
			// 
			// AddPlanetTextBox
			// 
			this.AddPlanetTextBox.Location = new System.Drawing.Point(647, 549);
			this.AddPlanetTextBox.Name = "AddPlanetTextBox";
			this.AddPlanetTextBox.Size = new System.Drawing.Size(146, 22);
			this.AddPlanetTextBox.TabIndex = 32;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(796, 419);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(272, 17);
			this.label3.TabIndex = 33;
			this.label3.Text = "Planets where this encounter could occur.";
			this.label3.Click += new System.EventHandler(this.label3_Click);
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(644, 529);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(79, 17);
			this.label14.TabIndex = 34;
			this.label14.Text = "New Planet";
			// 
			// AddPlanetButton
			// 
			this.AddPlanetButton.Location = new System.Drawing.Point(647, 577);
			this.AddPlanetButton.Name = "AddPlanetButton";
			this.AddPlanetButton.Size = new System.Drawing.Size(146, 23);
			this.AddPlanetButton.TabIndex = 35;
			this.AddPlanetButton.Text = "Add Planet";
			this.AddPlanetButton.UseVisualStyleBackColor = true;
			this.AddPlanetButton.Click += new System.EventHandler(this.AddPlanet);
			// 
			// DeletePlanetsButton
			// 
			this.DeletePlanetsButton.Location = new System.Drawing.Point(799, 637);
			this.DeletePlanetsButton.Name = "DeletePlanetsButton";
			this.DeletePlanetsButton.Size = new System.Drawing.Size(269, 23);
			this.DeletePlanetsButton.TabIndex = 36;
			this.DeletePlanetsButton.Text = "Delete Selected Planets";
			this.DeletePlanetsButton.UseVisualStyleBackColor = true;
			this.DeletePlanetsButton.Click += new System.EventHandler(this.DeleteSelectedPlanets);
			// 
			// PlanetList
			// 
			this.PlanetList.FormattingEnabled = true;
			this.PlanetList.ItemHeight = 16;
			this.PlanetList.Location = new System.Drawing.Point(799, 439);
			this.PlanetList.Name = "PlanetList";
			this.PlanetList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.PlanetList.Size = new System.Drawing.Size(269, 180);
			this.PlanetList.TabIndex = 37;
			// 
			// SaveEncounterButton
			// 
			this.SaveEncounterButton.Location = new System.Drawing.Point(469, 107);
			this.SaveEncounterButton.Name = "SaveEncounterButton";
			this.SaveEncounterButton.Size = new System.Drawing.Size(122, 30);
			this.SaveEncounterButton.TabIndex = 38;
			this.SaveEncounterButton.Text = "Save Encounter";
			this.SaveEncounterButton.UseVisualStyleBackColor = true;
			this.SaveEncounterButton.Click += new System.EventHandler(this.SaveEncounterButton_Click);
			// 
			// NewEncounterButton
			// 
			this.NewEncounterButton.Location = new System.Drawing.Point(469, 21);
			this.NewEncounterButton.Name = "NewEncounterButton";
			this.NewEncounterButton.Size = new System.Drawing.Size(122, 30);
			this.NewEncounterButton.TabIndex = 39;
			this.NewEncounterButton.Text = "New Encounter";
			this.NewEncounterButton.UseVisualStyleBackColor = true;
			this.NewEncounterButton.Click += new System.EventHandler(this.NewEncounterButton_Click);
			// 
			// EncountersBox
			// 
			this.EncountersBox.FormattingEnabled = true;
			this.EncountersBox.ItemHeight = 16;
			this.EncountersBox.Location = new System.Drawing.Point(621, 21);
			this.EncountersBox.Name = "EncountersBox";
			this.EncountersBox.Size = new System.Drawing.Size(307, 132);
			this.EncountersBox.TabIndex = 40;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1120, 777);
			this.Controls.Add(this.EncountersBox);
			this.Controls.Add(this.NewEncounterButton);
			this.Controls.Add(this.SaveEncounterButton);
			this.Controls.Add(this.PlanetList);
			this.Controls.Add(this.DeletePlanetsButton);
			this.Controls.Add(this.AddPlanetButton);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.AddPlanetTextBox);
			this.Controls.Add(this.OptionSaveButton);
			this.Controls.Add(this.FailDescTextBox);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.SuccessDescTextBox);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.SuccessMinTextBox);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.DiceMaxTextBox);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.DiceMinTextBox);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.RollInstruxTextBox);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.OptionDescTextBox);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.IdTextBox);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.OptionCounter);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.TitleTextBox);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.DescTextBox);
			this.Controls.Add(this.LoadButton);
			this.Name = "MainForm";
			this.Text = "Odyssey Designer";
			this.Load += new System.EventHandler(this.MainForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button LoadButton;
		private System.Windows.Forms.OpenFileDialog EventSearcher;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.TextBox DescTextBox;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox TitleTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Label OptionCounter;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox IdTextBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox OptionDescTextBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox RollInstruxTextBox;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox DiceMinTextBox;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox DiceMaxTextBox;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox SuccessMinTextBox;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox SuccessDescTextBox;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox FailDescTextBox;
		private System.Windows.Forms.Button OptionSaveButton;
		private System.IO.FileSystemWatcher fileSystemWatcher1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox AddPlanetTextBox;
		private System.Windows.Forms.Button AddPlanetButton;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Button DeletePlanetsButton;
		private System.Windows.Forms.ListBox PlanetList;
		private System.Windows.Forms.Button SaveEncounterButton;
		private System.Windows.Forms.Button NewEncounterButton;
		private System.Windows.Forms.ListBox EncountersBox;

	}
}

