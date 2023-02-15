namespace Lab_2
{
    partial class crewMem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(crewMem));
            this.crew = new System.Windows.Forms.Label();
            this.nameText = new System.Windows.Forms.Label();
            this.photoWithPilot = new System.Windows.Forms.PictureBox();
            this.workExText = new System.Windows.Forms.Label();
            this.ageText = new System.Windows.Forms.Label();
            this.PositionText = new System.Windows.Forms.Label();
            this.expInput = new System.Windows.Forms.TextBox();
            this.nameInput = new System.Windows.Forms.TextBox();
            this.ageInp = new System.Windows.Forms.TextBox();
            this.comboBoxConditionlInput = new System.Windows.Forms.ComboBox();
            this.AddButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.photoWithPilot)).BeginInit();
            this.SuspendLayout();
            // 
            // crew
            // 
            this.crew.AutoSize = true;
            this.crew.Font = new System.Drawing.Font("Magneto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.crew.Location = new System.Drawing.Point(12, 9);
            this.crew.Name = "crew";
            this.crew.Size = new System.Drawing.Size(187, 28);
            this.crew.TabIndex = 0;
            this.crew.Text = "Члены экипажа";
            // 
            // nameText
            // 
            this.nameText.Location = new System.Drawing.Point(12, 100);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(88, 28);
            this.nameText.TabIndex = 2;
            this.nameText.Text = "Имя:";
            // 
            // photoWithPilot
            // 
            this.photoWithPilot.Image = ((System.Drawing.Image)(resources.GetObject("photoWithPilot.Image")));
            this.photoWithPilot.Location = new System.Drawing.Point(320, 49);
            this.photoWithPilot.Name = "photoWithPilot";
            this.photoWithPilot.Size = new System.Drawing.Size(506, 283);
            this.photoWithPilot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.photoWithPilot.TabIndex = 3;
            this.photoWithPilot.TabStop = false;
            // 
            // workExText
            // 
            this.workExText.Location = new System.Drawing.Point(12, 154);
            this.workExText.Name = "workExText";
            this.workExText.Size = new System.Drawing.Size(88, 28);
            this.workExText.TabIndex = 4;
            this.workExText.Text = "Стаж:";
            // 
            // ageText
            // 
            this.ageText.Location = new System.Drawing.Point(12, 211);
            this.ageText.Name = "ageText";
            this.ageText.Size = new System.Drawing.Size(88, 28);
            this.ageText.TabIndex = 5;
            this.ageText.Text = "Возраст:";
            // 
            // PositionText
            // 
            this.PositionText.Location = new System.Drawing.Point(12, 52);
            this.PositionText.Name = "PositionText";
            this.PositionText.Size = new System.Drawing.Size(125, 28);
            this.PositionText.TabIndex = 6;
            this.PositionText.Text = "Должность:";
            // 
            // expInput
            // 
            this.expInput.Location = new System.Drawing.Point(127, 154);
            this.expInput.Name = "expInput";
            this.expInput.Size = new System.Drawing.Size(93, 31);
            this.expInput.TabIndex = 7;
            this.expInput.TextChanged += new System.EventHandler(this.expInput_TextChanged);
            this.expInput.Leave += new System.EventHandler(this.expInput_Leave);
            // 
            // nameInput
            // 
            this.nameInput.Location = new System.Drawing.Point(127, 100);
            this.nameInput.Name = "nameInput";
            this.nameInput.Size = new System.Drawing.Size(154, 31);
            this.nameInput.TabIndex = 8;
            this.nameInput.Leave += new System.EventHandler(this.nameInput_Leave);
            // 
            // ageInp
            // 
            this.ageInp.Location = new System.Drawing.Point(127, 211);
            this.ageInp.Name = "ageInp";
            this.ageInp.Size = new System.Drawing.Size(93, 31);
            this.ageInp.TabIndex = 9;
            this.ageInp.TextChanged += new System.EventHandler(this.ageInp_TextChanged);
            this.ageInp.Leave += new System.EventHandler(this.ageInp_Leave);
            // 
            // comboBoxConditionlInput
            // 
            this.comboBoxConditionlInput.FormattingEnabled = true;
            this.comboBoxConditionlInput.Items.AddRange(new object[] {
            "Пилот",
            "Стюардеса ",
            "Механик"});
            this.comboBoxConditionlInput.Location = new System.Drawing.Point(127, 49);
            this.comboBoxConditionlInput.Name = "comboBoxConditionlInput";
            this.comboBoxConditionlInput.Size = new System.Drawing.Size(168, 33);
            this.comboBoxConditionlInput.TabIndex = 27;
            this.comboBoxConditionlInput.Leave += new System.EventHandler(this.comboBoxConditionlInput_Leave);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(12, 271);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(112, 34);
            this.AddButton.TabIndex = 28;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // crewMem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 477);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.comboBoxConditionlInput);
            this.Controls.Add(this.ageInp);
            this.Controls.Add(this.nameInput);
            this.Controls.Add(this.expInput);
            this.Controls.Add(this.PositionText);
            this.Controls.Add(this.ageText);
            this.Controls.Add(this.workExText);
            this.Controls.Add(this.photoWithPilot);
            this.Controls.Add(this.nameText);
            this.Controls.Add(this.crew);
            this.Name = "crewMem";
            this.Text = "Члены экипажа";
            ((System.ComponentModel.ISupportInitialize)(this.photoWithPilot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label crew;
        private Label nameText;
        private PictureBox photoWithPilot;
        private Label workExText;
        private Label ageText;
        private Label PositionText;
        private TextBox expInput;
        private TextBox nameInput;
        private TextBox ageInp;
        private ComboBox comboBoxConditionlInput;
        private Button AddButton;
    }
}