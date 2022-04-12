//Made by Alejandro Lopez

namespace ColorBuster
{
    partial class SettingsView
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.newGameButton = new System.Windows.Forms.Button();
            this.rowscomboBox = new System.Windows.Forms.ComboBox();
            this.columnscomboBox = new System.Windows.Forms.ComboBox();
            this.matchedcomboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(88, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Board Size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(346, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(284, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Matching Tiles Number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Rows";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(194, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Columns";
            // 
            // newGameButton
            // 
            this.newGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newGameButton.Location = new System.Drawing.Point(243, 265);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(151, 43);
            this.newGameButton.TabIndex = 4;
            this.newGameButton.Text = "Apply";
            this.newGameButton.UseVisualStyleBackColor = true;
            this.newGameButton.Click += new System.EventHandler(this.newGameButton_Click);
            // 
            // rowscomboBox
            // 
            this.rowscomboBox.FormattingEnabled = true;
            this.rowscomboBox.Location = new System.Drawing.Point(12, 169);
            this.rowscomboBox.Name = "rowscomboBox";
            this.rowscomboBox.Size = new System.Drawing.Size(121, 28);
            this.rowscomboBox.TabIndex = 5;
            // 
            // columnscomboBox
            // 
            this.columnscomboBox.FormattingEnabled = true;
            this.columnscomboBox.Location = new System.Drawing.Point(185, 169);
            this.columnscomboBox.Name = "columnscomboBox";
            this.columnscomboBox.Size = new System.Drawing.Size(121, 28);
            this.columnscomboBox.TabIndex = 6;
            // 
            // matchedcomboBox
            // 
            this.matchedcomboBox.FormattingEnabled = true;
            this.matchedcomboBox.Location = new System.Drawing.Point(428, 169);
            this.matchedcomboBox.Name = "matchedcomboBox";
            this.matchedcomboBox.Size = new System.Drawing.Size(121, 28);
            this.matchedcomboBox.TabIndex = 7;
            // 
            // SettingsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(668, 339);
            this.Controls.Add(this.matchedcomboBox);
            this.Controls.Add(this.columnscomboBox);
            this.Controls.Add(this.rowscomboBox);
            this.Controls.Add(this.newGameButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SettingsView";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button newGameButton;
        private System.Windows.Forms.ComboBox rowscomboBox;
        private System.Windows.Forms.ComboBox columnscomboBox;
        private System.Windows.Forms.ComboBox matchedcomboBox;
    }
}