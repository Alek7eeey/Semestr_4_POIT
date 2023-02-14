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
            this.SuspendLayout();
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(107, 50);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(150, 31);
            this.textBoxID.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.Location = new System.Drawing.Point(13, 53);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(88, 28);
            this.ID.TabIndex = 1;
            this.ID.Text = "ID:";
            // 
            // Model
            // 
            this.Model.Location = new System.Drawing.Point(13, 96);
            this.Model.Name = "Model";
            this.Model.Size = new System.Drawing.Size(88, 28);
            this.Model.TabIndex = 2;
            this.Model.Text = "Модель:";
            // 
            // crew
            // 
            this.crew.Location = new System.Drawing.Point(13, 136);
            this.crew.Name = "crew";
            this.crew.Size = new System.Drawing.Size(88, 28);
            this.crew.TabIndex = 3;
            this.crew.Text = "Экипаж:";
            // 
            // CountOfSeating
            // 
            this.CountOfSeating.Location = new System.Drawing.Point(13, 180);
            this.CountOfSeating.Name = "CountOfSeating";
            this.CountOfSeating.Size = new System.Drawing.Size(262, 28);
            this.CountOfSeating.TabIndex = 4;
            this.CountOfSeating.Text = "Количество посадочных мест:";
            // 
            // yearOfIssue
            // 
            this.yearOfIssue.Location = new System.Drawing.Point(13, 223);
            this.yearOfIssue.Name = "yearOfIssue";
            this.yearOfIssue.Size = new System.Drawing.Size(262, 28);
            this.yearOfIssue.TabIndex = 5;
            this.yearOfIssue.Text = "Год выпуска:";
            // 
            // labelCarrying
            // 
            this.labelCarrying.Location = new System.Drawing.Point(13, 265);
            this.labelCarrying.Name = "labelCarrying";
            this.labelCarrying.Size = new System.Drawing.Size(174, 28);
            this.labelCarrying.TabIndex = 6;
            this.labelCarrying.Text = "Грузоподъёмность:";
            // 
            // DateOfService
            // 
            this.DateOfService.Location = new System.Drawing.Point(13, 307);
            this.DateOfService.Name = "DateOfService";
            this.DateOfService.Size = new System.Drawing.Size(262, 28);
            this.DateOfService.TabIndex = 7;
            this.DateOfService.Text = "Дата тех. обслуживания:";
            // 
            // barFilling
            // 
            this.barFilling.Location = new System.Drawing.Point(620, 13);
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
            this.listBoxType.Location = new System.Drawing.Point(154, 352);
            this.listBoxType.Name = "listBoxType";
            this.listBoxType.Size = new System.Drawing.Size(180, 29);
            this.listBoxType.TabIndex = 9;
            // 
            // textBoxCarrying
            // 
            this.textBoxCarrying.Location = new System.Drawing.Point(193, 262);
            this.textBoxCarrying.Name = "textBoxCarrying";
            this.textBoxCarrying.Size = new System.Drawing.Size(99, 31);
            this.textBoxCarrying.TabIndex = 11;
            // 
            // dateOfServiceChoose
            // 
            this.dateOfServiceChoose.Location = new System.Drawing.Point(227, 304);
            this.dateOfServiceChoose.Name = "dateOfServiceChoose";
            this.dateOfServiceChoose.Size = new System.Drawing.Size(195, 31);
            this.dateOfServiceChoose.TabIndex = 13;
            // 
            // ConfirmTheCorrect
            // 
            this.ConfirmTheCorrect.AutoSize = true;
            this.ConfirmTheCorrect.Location = new System.Drawing.Point(13, 400);
            this.ConfirmTheCorrect.Name = "ConfirmTheCorrect";
            this.ConfirmTheCorrect.Size = new System.Drawing.Size(433, 29);
            this.ConfirmTheCorrect.TabIndex = 14;
            this.ConfirmTheCorrect.Text = "Подтверждаю правильность введённых данных";
            this.ConfirmTheCorrect.UseVisualStyleBackColor = true;
            // 
            // dateOfIssueChoose
            // 
            this.dateOfIssueChoose.Location = new System.Drawing.Point(136, 220);
            this.dateOfIssueChoose.Name = "dateOfIssueChoose";
            this.dateOfIssueChoose.Size = new System.Drawing.Size(189, 31);
            this.dateOfIssueChoose.TabIndex = 16;
            // 
            // textBoxCountOfSeat
            // 
            this.textBoxCountOfSeat.Location = new System.Drawing.Point(272, 177);
            this.textBoxCountOfSeat.Name = "textBoxCountOfSeat";
            this.textBoxCountOfSeat.Size = new System.Drawing.Size(96, 31);
            this.textBoxCountOfSeat.TabIndex = 17;
            // 
            // TypeOfPlane
            // 
            this.TypeOfPlane.Location = new System.Drawing.Point(13, 352);
            this.TypeOfPlane.Name = "TypeOfPlane";
            this.TypeOfPlane.Size = new System.Drawing.Size(135, 28);
            this.TypeOfPlane.TabIndex = 18;
            this.TypeOfPlane.Text = "Тип самолёта:";
            // 
            // chooseButton
            // 
            this.chooseButton.Location = new System.Drawing.Point(107, 131);
            this.chooseButton.Name = "chooseButton";
            this.chooseButton.Size = new System.Drawing.Size(185, 34);
            this.chooseButton.TabIndex = 19;
            this.chooseButton.Text = "Выбор экипажа";
            this.chooseButton.UseVisualStyleBackColor = true;
            // 
            // FillWithInf
            // 
            this.FillWithInf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FillWithInf.Cursor = System.Windows.Forms.Cursors.No;
            this.FillWithInf.Location = new System.Drawing.Point(499, 50);
            this.FillWithInf.Multiline = true;
            this.FillWithInf.Name = "FillWithInf";
            this.FillWithInf.ReadOnly = true;
            this.FillWithInf.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.FillWithInf.Size = new System.Drawing.Size(596, 379);
            this.FillWithInf.TabIndex = 20;
            // 
            // buttonSave
            // 
            this.buttonSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSave.Location = new System.Drawing.Point(13, 450);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(135, 34);
            this.buttonSave.TabIndex = 21;
            this.buttonSave.Text = "Сохранить данные";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // buttonClear
            // 
            this.buttonClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClear.Location = new System.Drawing.Point(166, 450);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(135, 34);
            this.buttonClear.TabIndex = 22;
            this.buttonClear.Text = "Отчистить";
            this.buttonClear.UseVisualStyleBackColor = true;
            // 
            // filling
            // 
            this.filling.Location = new System.Drawing.Point(499, 15);
            this.filling.Name = "filling";
            this.filling.Size = new System.Drawing.Size(115, 28);
            this.filling.TabIndex = 23;
            this.filling.Text = "Заполнение:";
            // 
            // serialize
            // 
            this.serialize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.serialize.Location = new System.Drawing.Point(620, 435);
            this.serialize.Name = "serialize";
            this.serialize.Size = new System.Drawing.Size(166, 34);
            this.serialize.TabIndex = 24;
            this.serialize.Text = "Сериализация";
            this.serialize.UseVisualStyleBackColor = true;
            // 
            // deserialize
            // 
            this.deserialize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deserialize.Location = new System.Drawing.Point(805, 435);
            this.deserialize.Name = "deserialize";
            this.deserialize.Size = new System.Drawing.Size(166, 34);
            this.deserialize.TabIndex = 25;
            this.deserialize.Text = "Десериализация";
            this.deserialize.UseVisualStyleBackColor = true;
            // 
            // comboBoxModel
            // 
            this.comboBoxModel.FormattingEnabled = true;
            this.comboBoxModel.Items.AddRange(new object[] {
            "Boeing ",
            "Airbus",
            "Embraer",
            "CRJ"});
            this.comboBoxModel.Location = new System.Drawing.Point(107, 92);
            this.comboBoxModel.Name = "comboBoxModel";
            this.comboBoxModel.Size = new System.Drawing.Size(168, 33);
            this.comboBoxModel.TabIndex = 26;
            // 
            // airportText
            // 
            this.airportText.Font = new System.Drawing.Font("Magneto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.airportText.Location = new System.Drawing.Point(12, 9);
            this.airportText.Name = "airportText";
            this.airportText.Size = new System.Drawing.Size(119, 28);
            this.airportText.TabIndex = 27;
            this.airportText.Text = "Аэропорт";
            // 
            // Airport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 516);
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
    }
}