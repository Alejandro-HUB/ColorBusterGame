//Made by Alejandro Lopez

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
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.Notification = new System.Windows.Forms.Label();
            this.Cat = new System.Windows.Forms.PictureBox();
            this.settingsButton = new System.Windows.Forms.Button();
            this.NameGame = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Cat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameGame)).BeginInit();
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
            this.newGameButton.Location = new System.Drawing.Point(387, 944);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(216, 43);
            this.newGameButton.TabIndex = 1;
            this.newGameButton.Text = "New Game";
            this.newGameButton.UseVisualStyleBackColor = true;
            this.newGameButton.Click += new System.EventHandler(this.newGameButton_Click);
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.AutoSize = true;
            this.ScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreLabel.Location = new System.Drawing.Point(449, 28);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(93, 32);
            this.ScoreLabel.TabIndex = 2;
            this.ScoreLabel.Text = "Score";
            // 
            // Notification
            // 
            this.Notification.AutoSize = true;
            this.Notification.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Notification.Location = new System.Drawing.Point(717, 955);
            this.Notification.Name = "Notification";
            this.Notification.Size = new System.Drawing.Size(169, 32);
            this.Notification.TabIndex = 4;
            this.Notification.Text = "Notification";
            // 
            // Cat
            // 
            this.Cat.BackColor = System.Drawing.Color.Transparent;
            this.Cat.BackgroundImage = global::ColorBuster.Properties.Resources.Cat_Idle;
            this.Cat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Cat.Location = new System.Drawing.Point(923, 551);
            this.Cat.Name = "Cat";
            this.Cat.Size = new System.Drawing.Size(291, 370);
            this.Cat.TabIndex = 3;
            this.Cat.TabStop = false;
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
            // NameGame
            // 
            this.NameGame.BackColor = System.Drawing.Color.Transparent;
            this.NameGame.BackgroundImage = global::ColorBuster.Properties.Resources.Name;
            this.NameGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.NameGame.Location = new System.Drawing.Point(923, 284);
            this.NameGame.Name = "NameGame";
            this.NameGame.Size = new System.Drawing.Size(336, 143);
            this.NameGame.TabIndex = 5;
            this.NameGame.TabStop = false;
            // 
            // GameView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1271, 1043);
            this.Controls.Add(this.NameGame);
            this.Controls.Add(this.Notification);
            this.Controls.Add(this.Cat);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.ScoreLabel);
            this.Controls.Add(this.newGameButton);
            this.Controls.Add(this.board);
            this.MaximizeBox = false;
            this.Name = "GameView";
            this.Text = "Color Buster Game";
            this.Load += new System.EventHandler(this.GameView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Cat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameGame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel board;
        private System.Windows.Forms.Button newGameButton;
        private System.Windows.Forms.Label ScoreLabel;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.PictureBox Cat;
        private System.Windows.Forms.Label Notification;
        private System.Windows.Forms.PictureBox NameGame;
    }
}

