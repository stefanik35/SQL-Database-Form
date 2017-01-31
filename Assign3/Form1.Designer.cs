namespace Assign3
{
    partial class Form1
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
            this.Query = new System.Windows.Forms.Label();
            this.sqlInputBox = new System.Windows.Forms.TextBox();
            this.outListBox = new System.Windows.Forms.ListBox();
            this.outputLabel = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.executeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tablesListb = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Query
            // 
            this.Query.AutoSize = true;
            this.Query.Font = new System.Drawing.Font("Monotype Corsiva", 15F, System.Drawing.FontStyle.Italic);
            this.Query.Location = new System.Drawing.Point(45, 82);
            this.Query.Name = "Query";
            this.Query.Size = new System.Drawing.Size(94, 24);
            this.Query.TabIndex = 0;
            this.Query.Text = "SQL Query:";
            this.Query.Click += new System.EventHandler(this.label1_Click);
            // 
            // sqlInputBox
            // 
            this.sqlInputBox.BackColor = System.Drawing.Color.Silver;
            this.sqlInputBox.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sqlInputBox.ForeColor = System.Drawing.Color.Indigo;
            this.sqlInputBox.Location = new System.Drawing.Point(49, 106);
            this.sqlInputBox.Name = "sqlInputBox";
            this.sqlInputBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.sqlInputBox.Size = new System.Drawing.Size(245, 25);
            this.sqlInputBox.TabIndex = 1;
            this.sqlInputBox.WordWrap = false;
            this.sqlInputBox.TextChanged += new System.EventHandler(this.sqlInputBox_TextChanged);
            // 
            // outListBox
            // 
            this.outListBox.BackColor = System.Drawing.SystemColors.Info;
            this.outListBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outListBox.ForeColor = System.Drawing.Color.Red;
            this.outListBox.FormattingEnabled = true;
            this.outListBox.HorizontalScrollbar = true;
            this.outListBox.ItemHeight = 19;
            this.outListBox.Location = new System.Drawing.Point(364, 208);
            this.outListBox.Name = "outListBox";
            this.outListBox.Size = new System.Drawing.Size(286, 194);
            this.outListBox.TabIndex = 2;
            // 
            // outputLabel
            // 
            this.outputLabel.AutoSize = true;
            this.outputLabel.Font = new System.Drawing.Font("Monotype Corsiva", 15F, System.Drawing.FontStyle.Italic);
            this.outputLabel.Location = new System.Drawing.Point(360, 181);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(112, 24);
            this.outputLabel.TabIndex = 3;
            this.outputLabel.Text = "Query Output:";
            this.outputLabel.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.clearButton.Font = new System.Drawing.Font("Algerian", 12F);
            this.clearButton.Location = new System.Drawing.Point(49, 295);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(100, 30);
            this.clearButton.TabIndex = 4;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.exitButton.Font = new System.Drawing.Font("Algerian", 12F);
            this.exitButton.Location = new System.Drawing.Point(49, 377);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(100, 30);
            this.exitButton.TabIndex = 5;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // executeButton
            // 
            this.executeButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.executeButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.executeButton.Font = new System.Drawing.Font("Algerian", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.executeButton.Location = new System.Drawing.Point(49, 208);
            this.executeButton.Name = "executeButton";
            this.executeButton.Size = new System.Drawing.Size(100, 31);
            this.executeButton.TabIndex = 6;
            this.executeButton.Text = "Execute";
            this.executeButton.UseVisualStyleBackColor = false;
            this.executeButton.Click += new System.EventHandler(this.executeButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Papyrus", 28F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.Location = new System.Drawing.Point(182, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(341, 60);
            this.label1.TabIndex = 7;
            this.label1.Text = "Department Data";
            this.label1.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // tablesListb
            // 
            this.tablesListb.BackColor = System.Drawing.SystemColors.Info;
            this.tablesListb.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tablesListb.ForeColor = System.Drawing.Color.Blue;
            this.tablesListb.FormattingEnabled = true;
            this.tablesListb.ItemHeight = 15;
            this.tablesListb.Location = new System.Drawing.Point(364, 106);
            this.tablesListb.Name = "tablesListb";
            this.tablesListb.Size = new System.Drawing.Size(286, 64);
            this.tablesListb.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 15F, System.Drawing.FontStyle.Italic);
            this.label2.Location = new System.Drawing.Point(360, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "Tables in the Database:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(697, 443);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tablesListb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.executeButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.outputLabel);
            this.Controls.Add(this.outListBox);
            this.Controls.Add(this.sqlInputBox);
            this.Controls.Add(this.Query);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Query;
        private System.Windows.Forms.TextBox sqlInputBox;
        private System.Windows.Forms.ListBox outListBox;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button executeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox tablesListb;
        private System.Windows.Forms.Label label2;
    }
}

