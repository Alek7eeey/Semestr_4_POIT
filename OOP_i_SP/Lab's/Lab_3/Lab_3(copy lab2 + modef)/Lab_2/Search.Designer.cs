namespace Lab_2
{
    partial class Search
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Search));
            this.fill = new System.Windows.Forms.TextBox();
            this.comboBoxModel = new System.Windows.Forms.ComboBox();
            this.TypeOfPlane = new System.Windows.Forms.Label();
            this.listBoxType = new System.Windows.Forms.ListBox();
            this.CountOfSeating = new System.Windows.Forms.Label();
            this.Model = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.Label();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.From = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // fill
            // 
            this.fill.Cursor = System.Windows.Forms.Cursors.No;
            this.fill.Location = new System.Drawing.Point(358, 12);
            this.fill.Multiline = true;
            this.fill.Name = "fill";
            this.fill.ReadOnly = true;
            this.fill.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.fill.Size = new System.Drawing.Size(466, 490);
            this.fill.TabIndex = 0;
            this.fill.Enter += new System.EventHandler(this.fill_Enter);
            // 
            // comboBoxModel
            // 
            this.comboBoxModel.FormattingEnabled = true;
            this.comboBoxModel.Items.AddRange(new object[] {
            "Boeing ",
            "Airbus",
            "Embraer",
            "CRJ"});
            this.comboBoxModel.Location = new System.Drawing.Point(106, 78);
            this.comboBoxModel.Name = "comboBoxModel";
            this.comboBoxModel.Size = new System.Drawing.Size(168, 33);
            this.comboBoxModel.TabIndex = 43;
            this.comboBoxModel.SelectedIndexChanged += new System.EventHandler(this.comboBoxModel_SelectedIndexChanged);
            // 
            // TypeOfPlane
            // 
            this.TypeOfPlane.Location = new System.Drawing.Point(11, 129);
            this.TypeOfPlane.Name = "TypeOfPlane";
            this.TypeOfPlane.Size = new System.Drawing.Size(135, 28);
            this.TypeOfPlane.TabIndex = 41;
            this.TypeOfPlane.Text = "Тип самолёта:";
            // 
            // listBoxType
            // 
            this.listBoxType.FormattingEnabled = true;
            this.listBoxType.ItemHeight = 25;
            this.listBoxType.Items.AddRange(new object[] {
            "Пассажирский",
            "Грузовой",
            "Военный"});
            this.listBoxType.Location = new System.Drawing.Point(152, 128);
            this.listBoxType.Name = "listBoxType";
            this.listBoxType.Size = new System.Drawing.Size(180, 29);
            this.listBoxType.TabIndex = 36;
            this.listBoxType.SelectedIndexChanged += new System.EventHandler(this.listBoxType_SelectedIndexChanged);
            // 
            // CountOfSeating
            // 
            this.CountOfSeating.Location = new System.Drawing.Point(12, 177);
            this.CountOfSeating.Name = "CountOfSeating";
            this.CountOfSeating.Size = new System.Drawing.Size(262, 28);
            this.CountOfSeating.TabIndex = 32;
            this.CountOfSeating.Text = "Количество посадочных мест:";
            // 
            // Model
            // 
            this.Model.Location = new System.Drawing.Point(12, 82);
            this.Model.Name = "Model";
            this.Model.Size = new System.Drawing.Size(88, 28);
            this.Model.TabIndex = 30;
            this.Model.Text = "Модель:";
            // 
            // ID
            // 
            this.ID.Location = new System.Drawing.Point(12, 30);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(88, 28);
            this.ID.TabIndex = 29;
            this.ID.Text = "ID:";
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(106, 27);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(168, 31);
            this.textBoxID.TabIndex = 28;
            this.textBoxID.TextChanged += new System.EventHandler(this.textBoxID_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(179, 213);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(52, 31);
            this.textBox2.TabIndex = 45;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // From
            // 
            this.From.Location = new System.Drawing.Point(12, 216);
            this.From.Name = "From";
            this.From.Size = new System.Drawing.Size(39, 28);
            this.From.TabIndex = 46;
            this.From.Text = "От:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(134, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 28);
            this.label1.TabIndex = 47;
            this.label1.Text = "До:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(57, 214);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(52, 30);
            this.textBox3.TabIndex = 48;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 286);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(340, 262);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 50;
            this.pictureBox1.TabStop = false;
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 513);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.From);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.comboBoxModel);
            this.Controls.Add(this.TypeOfPlane);
            this.Controls.Add(this.listBoxType);
            this.Controls.Add(this.CountOfSeating);
            this.Controls.Add(this.Model);
            this.Controls.Add(this.ID);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.fill);
            this.Name = "Search";
            this.Text = "Search";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox fill;
        private ComboBox comboBoxModel;
        private Label TypeOfPlane;
        private ListBox listBoxType;
        private Label CountOfSeating;
        private Label Model;
        private Label ID;
        private TextBox textBoxID;
        private TextBox textBox2;
        private Label From;
        private Label label1;
        private TextBox textBox3;
        private PictureBox pictureBox1;
    }
}