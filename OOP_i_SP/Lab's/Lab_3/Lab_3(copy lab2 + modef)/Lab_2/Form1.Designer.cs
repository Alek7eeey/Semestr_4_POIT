namespace Lab_2
{
    partial class Airport
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Airport));
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.ID = new System.Windows.Forms.Label();
            this.Model = new System.Windows.Forms.Label();
            this.crew = new System.Windows.Forms.Label();
            this.CountOfSeating = new System.Windows.Forms.Label();
            this.yearOfIssue = new System.Windows.Forms.Label();
            this.labelCarrying = new System.Windows.Forms.Label();
            this.DateOfService = new System.Windows.Forms.Label();
            this.barFilling = new System.Windows.Forms.ProgressBar();
            this.listBoxType = new System.Windows.Forms.ListBox();
            this.textBoxCarrying = new System.Windows.Forms.TextBox();
            this.dateOfServiceChoose = new System.Windows.Forms.DateTimePicker();
            this.ConfirmTheCorrect = new System.Windows.Forms.CheckBox();
            this.dateOfIssueChoose = new System.Windows.Forms.DateTimePicker();
            this.textBoxCountOfSeat = new System.Windows.Forms.TextBox();
            this.TypeOfPlane = new System.Windows.Forms.Label();
            this.chooseButton = new System.Windows.Forms.Button();
            this.FillWithInf = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.filling = new System.Windows.Forms.Label();
            this.serialize = new System.Windows.Forms.Button();
            this.deserialize = new System.Windows.Forms.Button();
            this.comboBoxModel = new System.Windows.Forms.ComboBox();
            this.airportText = new System.Windows.Forms.Label();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.labelCountOfObjects = new System.Windows.Forms.Label();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(120, 87);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(150, 31);
            this.textBoxID.TabIndex = 0;
            this.textBoxID.TextChanged += new System.EventHandler(this.textBoxID_TextChanged);
            this.textBoxID.Leave += new System.EventHandler(this.textBoxID_Leave);
            // 
            // ID
            // 
            this.ID.Location = new System.Drawing.Point(26, 90);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(88, 28);
            this.ID.TabIndex = 1;
            this.ID.Text = "ID:";
            // 
            // Model
            // 
            this.Model.Location = new System.Drawing.Point(26, 133);
            this.Model.Name = "Model";
            this.Model.Size = new System.Drawing.Size(88, 28);
            this.Model.TabIndex = 2;
            this.Model.Text = "Модель:";
            // 
            // crew
            // 
            this.crew.Location = new System.Drawing.Point(26, 173);
            this.crew.Name = "crew";
            this.crew.Size = new System.Drawing.Size(88, 28);
            this.crew.TabIndex = 3;
            this.crew.Text = "Экипаж:";
            // 
            // CountOfSeating
            // 
            this.CountOfSeating.Location = new System.Drawing.Point(26, 217);
            this.CountOfSeating.Name = "CountOfSeating";
            this.CountOfSeating.Size = new System.Drawing.Size(262, 28);
            this.CountOfSeating.TabIndex = 4;
            this.CountOfSeating.Text = "Количество посадочных мест:";
            // 
            // yearOfIssue
            // 
            this.yearOfIssue.Location = new System.Drawing.Point(26, 260);
            this.yearOfIssue.Name = "yearOfIssue";
            this.yearOfIssue.Size = new System.Drawing.Size(262, 28);
            this.yearOfIssue.TabIndex = 5;
            this.yearOfIssue.Text = "Год выпуска:";
            // 
            // labelCarrying
            // 
            this.labelCarrying.Location = new System.Drawing.Point(26, 302);
            this.labelCarrying.Name = "labelCarrying";
            this.labelCarrying.Size = new System.Drawing.Size(174, 28);
            this.labelCarrying.TabIndex = 6;
            this.labelCarrying.Text = "Грузоподъёмность:";
            // 
            // DateOfService
            // 
            this.DateOfService.Location = new System.Drawing.Point(26, 344);
            this.DateOfService.Name = "DateOfService";
            this.DateOfService.Size = new System.Drawing.Size(262, 28);
            this.DateOfService.TabIndex = 7;
            this.DateOfService.Text = "Дата тех. обслуживания:";
            // 
            // barFilling
            // 
            this.barFilling.Location = new System.Drawing.Point(630, 68);
            this.barFilling.Name = "barFilling";
            this.barFilling.Size = new System.Drawing.Size(475, 31);
            this.barFilling.TabIndex = 8;
            // 
            // listBoxType
            // 
            this.listBoxType.FormattingEnabled = true;
            this.listBoxType.ItemHeight = 25;
            this.listBoxType.Items.AddRange(new object[] {
            "Пассажирский",
            "Грузовой",
            "Военный"});
            this.listBoxType.Location = new System.Drawing.Point(167, 389);
            this.listBoxType.Name = "listBoxType";
            this.listBoxType.Size = new System.Drawing.Size(180, 29);
            this.listBoxType.TabIndex = 9;
            this.listBoxType.SelectedIndexChanged += new System.EventHandler(this.listBoxType_SelectedIndexChanged);
            // 
            // textBoxCarrying
            // 
            this.textBoxCarrying.Location = new System.Drawing.Point(206, 299);
            this.textBoxCarrying.Name = "textBoxCarrying";
            this.textBoxCarrying.Size = new System.Drawing.Size(99, 31);
            this.textBoxCarrying.TabIndex = 11;
            this.textBoxCarrying.TextChanged += new System.EventHandler(this.textBoxCarrying_TextChanged);
            this.textBoxCarrying.Leave += new System.EventHandler(this.textBoxCarrying_Leave);
            // 
            // dateOfServiceChoose
            // 
            this.dateOfServiceChoose.Location = new System.Drawing.Point(240, 341);
            this.dateOfServiceChoose.Name = "dateOfServiceChoose";
            this.dateOfServiceChoose.Size = new System.Drawing.Size(195, 31);
            this.dateOfServiceChoose.TabIndex = 13;
            this.dateOfServiceChoose.ValueChanged += new System.EventHandler(this.dateOfServiceChoose_ValueChanged);
            this.dateOfServiceChoose.Leave += new System.EventHandler(this.dateOfServiceChoose_Leave);
            // 
            // ConfirmTheCorrect
            // 
            this.ConfirmTheCorrect.AutoSize = true;
            this.ConfirmTheCorrect.Location = new System.Drawing.Point(26, 437);
            this.ConfirmTheCorrect.Name = "ConfirmTheCorrect";
            this.ConfirmTheCorrect.Size = new System.Drawing.Size(433, 29);
            this.ConfirmTheCorrect.TabIndex = 14;
            this.ConfirmTheCorrect.Text = "Подтверждаю правильность введённых данных";
            this.ConfirmTheCorrect.UseVisualStyleBackColor = true;
            this.ConfirmTheCorrect.CheckedChanged += new System.EventHandler(this.ConfirmTheCorrect_CheckedChanged);
            // 
            // dateOfIssueChoose
            // 
            this.dateOfIssueChoose.Location = new System.Drawing.Point(149, 257);
            this.dateOfIssueChoose.Name = "dateOfIssueChoose";
            this.dateOfIssueChoose.Size = new System.Drawing.Size(189, 31);
            this.dateOfIssueChoose.TabIndex = 16;
            this.dateOfIssueChoose.ValueChanged += new System.EventHandler(this.dateOfIssueChoose_ValueChanged);
            this.dateOfIssueChoose.Leave += new System.EventHandler(this.dateOfIssueChoose_Leave);
            // 
            // textBoxCountOfSeat
            // 
            this.textBoxCountOfSeat.Location = new System.Drawing.Point(285, 214);
            this.textBoxCountOfSeat.Name = "textBoxCountOfSeat";
            this.textBoxCountOfSeat.Size = new System.Drawing.Size(96, 31);
            this.textBoxCountOfSeat.TabIndex = 17;
            this.textBoxCountOfSeat.TextChanged += new System.EventHandler(this.textBoxCountOfSeat_TextChanged);
            this.textBoxCountOfSeat.Leave += new System.EventHandler(this.textBoxCountOfSeat_Leave);
            // 
            // TypeOfPlane
            // 
            this.TypeOfPlane.Location = new System.Drawing.Point(26, 389);
            this.TypeOfPlane.Name = "TypeOfPlane";
            this.TypeOfPlane.Size = new System.Drawing.Size(135, 28);
            this.TypeOfPlane.TabIndex = 18;
            this.TypeOfPlane.Text = "Тип самолёта:";
            // 
            // chooseButton
            // 
            this.chooseButton.Location = new System.Drawing.Point(120, 168);
            this.chooseButton.Name = "chooseButton";
            this.chooseButton.Size = new System.Drawing.Size(185, 34);
            this.chooseButton.TabIndex = 19;
            this.chooseButton.Text = "Выбор экипажа";
            this.chooseButton.UseVisualStyleBackColor = true;
            this.chooseButton.Click += new System.EventHandler(this.chooseButton_Click);
            // 
            // FillWithInf
            // 
            this.FillWithInf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FillWithInf.Cursor = System.Windows.Forms.Cursors.No;
            this.FillWithInf.Location = new System.Drawing.Point(509, 105);
            this.FillWithInf.Multiline = true;
            this.FillWithInf.Name = "FillWithInf";
            this.FillWithInf.ReadOnly = true;
            this.FillWithInf.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.FillWithInf.Size = new System.Drawing.Size(596, 379);
            this.FillWithInf.TabIndex = 20;
            this.FillWithInf.Enter += new System.EventHandler(this.FillWithInf_Enter);
            // 
            // buttonSave
            // 
            this.buttonSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSave.Location = new System.Drawing.Point(26, 487);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(135, 34);
            this.buttonSave.TabIndex = 21;
            this.buttonSave.Text = "Сохранить данные";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClear.Location = new System.Drawing.Point(179, 487);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(135, 34);
            this.buttonClear.TabIndex = 22;
            this.buttonClear.Text = "Отчистить";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // filling
            // 
            this.filling.Location = new System.Drawing.Point(509, 70);
            this.filling.Name = "filling";
            this.filling.Size = new System.Drawing.Size(115, 28);
            this.filling.TabIndex = 23;
            this.filling.Text = "Заполнение:";
            // 
            // serialize
            // 
            this.serialize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.serialize.Location = new System.Drawing.Point(630, 490);
            this.serialize.Name = "serialize";
            this.serialize.Size = new System.Drawing.Size(166, 34);
            this.serialize.TabIndex = 24;
            this.serialize.Text = "Сериализация";
            this.serialize.UseVisualStyleBackColor = true;
            this.serialize.Click += new System.EventHandler(this.serialize_Click);
            // 
            // deserialize
            // 
            this.deserialize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deserialize.Location = new System.Drawing.Point(815, 490);
            this.deserialize.Name = "deserialize";
            this.deserialize.Size = new System.Drawing.Size(166, 34);
            this.deserialize.TabIndex = 25;
            this.deserialize.Text = "Десериализация";
            this.deserialize.UseVisualStyleBackColor = true;
            this.deserialize.Click += new System.EventHandler(this.deserialize_Click);
            // 
            // comboBoxModel
            // 
            this.comboBoxModel.FormattingEnabled = true;
            this.comboBoxModel.Items.AddRange(new object[] {
            "Boeing ",
            "Airbus",
            "Embraer",
            "CRJ"});
            this.comboBoxModel.Location = new System.Drawing.Point(120, 129);
            this.comboBoxModel.Name = "comboBoxModel";
            this.comboBoxModel.Size = new System.Drawing.Size(168, 33);
            this.comboBoxModel.TabIndex = 26;
            this.comboBoxModel.SelectedIndexChanged += new System.EventHandler(this.comboBoxModel_SelectedIndexChanged);
            this.comboBoxModel.Leave += new System.EventHandler(this.comboBoxModel_Leave);
            // 
            // airportText
            // 
            this.airportText.Font = new System.Drawing.Font("Magneto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.airportText.Location = new System.Drawing.Point(27, 41);
            this.airportText.Name = "airportText";
            this.airportText.Size = new System.Drawing.Size(134, 43);
            this.airportText.TabIndex = 27;
            this.airportText.Text = "Аэропорт";
            // 
            // toolStrip
            // 
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton3,
            this.toolStripButton1,
            this.toolStripButton5,
            this.toolStripButton6});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(297, 34);
            this.toolStrip.TabIndex = 28;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(67, 29);
            this.toolStripButton3.Text = "Поиск";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(116, 29);
            this.toolStripButton1.Text = "Сортировка";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(62, 29);
            this.toolStripButton5.Text = "О нас";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(34, 29);
            this.toolStripButton6.Text = "toolStripButton6";
            this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // labelCountOfObjects
            // 
            this.labelCountOfObjects.BackColor = System.Drawing.Color.LightCyan;
            this.labelCountOfObjects.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelCountOfObjects.Cursor = System.Windows.Forms.Cursors.No;
            this.labelCountOfObjects.Location = new System.Drawing.Point(630, 9);
            this.labelCountOfObjects.Name = "labelCountOfObjects";
            this.labelCountOfObjects.Size = new System.Drawing.Size(475, 52);
            this.labelCountOfObjects.TabIndex = 29;
            this.labelCountOfObjects.Text = "Количество объектов: 0\r\nПоследнее время создания:\r\n";
            // 
            // Airport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 550);
            this.Controls.Add(this.labelCountOfObjects);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.airportText);
            this.Controls.Add(this.comboBoxModel);
            this.Controls.Add(this.deserialize);
            this.Controls.Add(this.serialize);
            this.Controls.Add(this.filling);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.FillWithInf);
            this.Controls.Add(this.chooseButton);
            this.Controls.Add(this.TypeOfPlane);
            this.Controls.Add(this.textBoxCountOfSeat);
            this.Controls.Add(this.dateOfIssueChoose);
            this.Controls.Add(this.ConfirmTheCorrect);
            this.Controls.Add(this.dateOfServiceChoose);
            this.Controls.Add(this.textBoxCarrying);
            this.Controls.Add(this.listBoxType);
            this.Controls.Add(this.barFilling);
            this.Controls.Add(this.DateOfService);
            this.Controls.Add(this.labelCarrying);
            this.Controls.Add(this.yearOfIssue);
            this.Controls.Add(this.CountOfSeating);
            this.Controls.Add(this.crew);
            this.Controls.Add(this.Model);
            this.Controls.Add(this.ID);
            this.Controls.Add(this.textBoxID);
            this.Name = "Airport";
            this.Text = "Аэропорт";
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBoxID;
        private Label ID;
        private Label Model;
        private Label crew;
        private Label CountOfSeating;
        private Label yearOfIssue;
        private Label labelCarrying;
        private Label DateOfService;
        private ProgressBar barFilling;
        private ListBox listBoxType;
        private TextBox textBoxCarrying;
        private DateTimePicker dateOfServiceChoose;
        private CheckBox ConfirmTheCorrect;
        private DateTimePicker dateOfIssueChoose;
        private TextBox textBoxCountOfSeat;
        private Label TypeOfPlane;
        private Button chooseButton;
        private TextBox FillWithInf;
        private Button buttonSave;
        private Button buttonClear;
        private Label filling;
        private Button serialize;
        private Button deserialize;
        private ComboBox comboBoxModel;
        private Label airportText;
        private ToolStrip toolStrip;
        private ToolStripButton toolStripButton3;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton5;
        private ToolStripButton toolStripButton6;
        private Label labelCountOfObjects;
    }
}