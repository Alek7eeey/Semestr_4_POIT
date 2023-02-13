namespace Lab_2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textAirport = new System.Windows.Forms.Label();
            this.inputID = new System.Windows.Forms.TextBox();
            this.ID = new System.Windows.Forms.Label();
            this.TypeOfPlane = new System.Windows.Forms.MenuStrip();
            this.типСамолётаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пассажирскийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.грузовойToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.военныйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.TypeOfPlane.SuspendLayout();
            this.SuspendLayout();
            // 
            // textAirport
            // 
            this.textAirport.AutoSize = true;
            this.textAirport.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textAirport.Location = new System.Drawing.Point(12, 21);
            this.textAirport.Name = "textAirport";
            this.textAirport.Size = new System.Drawing.Size(97, 27);
            this.textAirport.TabIndex = 0;
            this.textAirport.Text = "Airport";
            // 
            // inputID
            // 
            this.inputID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inputID.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.inputID.Location = new System.Drawing.Point(12, 93);
            this.inputID.Multiline = true;
            this.inputID.Name = "inputID";
            this.inputID.Size = new System.Drawing.Size(221, 30);
            this.inputID.TabIndex = 1;
            // 
            // ID
            // 
            this.ID.AutoSize = true;
            this.ID.Font = new System.Drawing.Font("Lucida Sans", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID.Location = new System.Drawing.Point(9, 72);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(27, 18);
            this.ID.TabIndex = 2;
            this.ID.Text = "ID";
            // 
            // TypeOfPlane
            // 
            this.TypeOfPlane.BackColor = System.Drawing.Color.White;
            this.TypeOfPlane.Dock = System.Windows.Forms.DockStyle.None;
            this.TypeOfPlane.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.TypeOfPlane.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.типСамолётаToolStripMenuItem});
            this.TypeOfPlane.Location = new System.Drawing.Point(93, 314);
            this.TypeOfPlane.Name = "TypeOfPlane";
            this.TypeOfPlane.Size = new System.Drawing.Size(222, 26);
            this.TypeOfPlane.TabIndex = 4;
            this.TypeOfPlane.Text = "Type";
            // 
            // типСамолётаToolStripMenuItem
            // 
            this.типСамолётаToolStripMenuItem.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.типСамолётаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.пассажирскийToolStripMenuItem,
            this.грузовойToolStripMenuItem,
            this.военныйToolStripMenuItem});
            this.типСамолётаToolStripMenuItem.Font = new System.Drawing.Font("Lucida Sans", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.типСамолётаToolStripMenuItem.Name = "типСамолётаToolStripMenuItem";
            this.типСамолётаToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.типСамолётаToolStripMenuItem.Text = "                                      ";
            // 
            // пассажирскийToolStripMenuItem
            // 
            this.пассажирскийToolStripMenuItem.Font = new System.Drawing.Font("Lucida Sans", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.пассажирскийToolStripMenuItem.Name = "пассажирскийToolStripMenuItem";
            this.пассажирскийToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.пассажирскийToolStripMenuItem.Text = "пассажирский";
            // 
            // грузовойToolStripMenuItem
            // 
            this.грузовойToolStripMenuItem.Font = new System.Drawing.Font("Lucida Sans", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.грузовойToolStripMenuItem.Name = "грузовойToolStripMenuItem";
            this.грузовойToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.грузовойToolStripMenuItem.Text = "грузовой";
            // 
            // военныйToolStripMenuItem
            // 
            this.военныйToolStripMenuItem.Font = new System.Drawing.Font("Lucida Sans", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.военныйToolStripMenuItem.Name = "военныйToolStripMenuItem";
            this.военныйToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.военныйToolStripMenuItem.Text = "военный";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 304);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Model";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(12, 163);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(221, 30);
            this.textBox1.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Sans", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "Count of passanger";
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.Location = new System.Drawing.Point(12, 232);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(221, 30);
            this.textBox2.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 587);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ID);
            this.Controls.Add(this.inputID);
            this.Controls.Add(this.textAirport);
            this.Controls.Add(this.TypeOfPlane);
            this.MainMenuStrip = this.TypeOfPlane;
            this.Name = "Form1";
            this.Text = "Airport";
            this.TypeOfPlane.ResumeLayout(false);
            this.TypeOfPlane.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label textAirport;
        private System.Windows.Forms.TextBox inputID;
        private System.Windows.Forms.Label ID;
        private System.Windows.Forms.MenuStrip TypeOfPlane;
        private System.Windows.Forms.ToolStripMenuItem типСамолётаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пассажирскийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem грузовойToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem военныйToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
    }
}

