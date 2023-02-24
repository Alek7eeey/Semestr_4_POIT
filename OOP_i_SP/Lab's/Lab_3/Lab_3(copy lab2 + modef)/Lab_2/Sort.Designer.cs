namespace Lab_2
{
    partial class Sort
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
            this.buttonSort = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.fill_2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSort
            // 
            this.buttonSort.BackColor = System.Drawing.Color.PapayaWhip;
            this.buttonSort.Location = new System.Drawing.Point(12, 417);
            this.buttonSort.Name = "buttonSort";
            this.buttonSort.Size = new System.Drawing.Size(447, 34);
            this.buttonSort.TabIndex = 0;
            this.buttonSort.Text = "Сортировка по дате последнего тех обслуживания";
            this.buttonSort.UseVisualStyleBackColor = false;
            this.buttonSort.Click += new System.EventHandler(this.buttonSort_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.PapayaWhip;
            this.button1.Location = new System.Drawing.Point(12, 457);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(275, 34);
            this.button1.TabIndex = 1;
            this.button1.Text = "Сортировка по году выпуска\r\n";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // fill_2
            // 
            this.fill_2.Cursor = System.Windows.Forms.Cursors.No;
            this.fill_2.Location = new System.Drawing.Point(12, 12);
            this.fill_2.Multiline = true;
            this.fill_2.Name = "fill_2";
            this.fill_2.ReadOnly = true;
            this.fill_2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.fill_2.Size = new System.Drawing.Size(853, 389);
            this.fill_2.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.PapayaWhip;
            this.button2.Location = new System.Drawing.Point(12, 497);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(155, 34);
            this.button2.TabIndex = 3;
            this.button2.Text = "Сериализация";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Sort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 544);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.fill_2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonSort);
            this.Name = "Sort";
            this.Text = "Sort";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonSort;
        private Button button1;
        private TextBox fill_2;
        private Button button2;
    }
}