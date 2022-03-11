namespace ColorBuster
{
    partial class GameView
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
            this.board = new System.Windows.Forms.Panel();
            this.newGameButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.settingsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // board
            // 
            this.board.BackColor = System.Drawing.SystemColors.Control;
            this.board.Location = new System.Drawing.Point(100, 89);
            this.board.Name = "board";
            this.board.Size = new System.Drawing.Size(786, 832);
            this.board.TabIndex = 0;
            // 
            // newGameButton
            // 
            this.newGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newGameButton.Location = new System.Drawing.Point(356, 944);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(216, 43);
            this.newGameButton.TabIndex = 1;
            this.newGameButton.Text = "New Game";
            this.newGameButton.UseVisualStyleBackColor = true;
            this.newGameButton.Click += new System.EventHandler(this.newGameButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(410, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Score";
            // 
            // settingsButton
            // 
            this.settingsButton.BackgroundImage = global::ColorBuster.Properties.Resources.img_105979;
            this.settingsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.settingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsButton.Location = new System.Drawing.Point(12, 28);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(69, 65);
            this.settingsButton.TabIndex = 2;
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // GameView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1001, 999);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.newGameButton);
            this.Controls.Add(this.board);
            this.MaximizeBox = false;
            this.Name = "GameView";
            this.Text = "Color Buster Game";
            this.Load += new System.EventHandler(this.GameView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel board;
        private System.Windows.Forms.Button newGameButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button settingsButton;
    }
}

