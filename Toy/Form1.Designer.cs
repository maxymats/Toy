
namespace Toy
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
            this.components = new System.ComponentModel.Container();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.penaltyLabel = new System.Windows.Forms.Label();
            this.playerNameTextBox = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.startButton = new System.Windows.Forms.Button();
            this.nameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // score
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.Location = new System.Drawing.Point(16, 11);
            this.scoreLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(81, 25);
            this.scoreLabel.TabIndex = 0;
            this.scoreLabel.Text = "Очки: 0";
            // penalty
            this.penaltyLabel.AutoSize = true;
            this.penaltyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.penaltyLabel.Location = new System.Drawing.Point(16, 48);
            this.penaltyLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.penaltyLabel.Name = "penaltyLabel";
            this.penaltyLabel.Size = new System.Drawing.Size(102, 25);
            this.penaltyLabel.TabIndex = 1;
            this.penaltyLabel.Text = "Штраф: 0";
            // playerNameTextBox
            this.playerNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerNameTextBox.Location = new System.Drawing.Point(21, 113);
            this.playerNameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.playerNameTextBox.Name = "playerNameTextBox";
            this.playerNameTextBox.Size = new System.Drawing.Size(140, 30);
            this.playerNameTextBox.TabIndex = 2;
            this.playerNameTextBox.TextChanged += new System.EventHandler(this.playerNameTextBox_TextChanged);
            // timer1
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // startButton
            this.startButton.Location = new System.Drawing.Point(21, 150);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(129, 30);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Старт";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // nameLabel
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(16, 84);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(130, 25);
            this.nameLabel.TabIndex = 4;
            this.nameLabel.Text = "Введіть ім\'я:";
            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.playerNameTextBox);
            this.Controls.Add(this.penaltyLabel);
            this.Controls.Add(this.scoreLabel);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Попади в кульку";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private bool isGameStarted = false;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label penaltyLabel;
        private System.Windows.Forms.TextBox playerNameTextBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label nameLabel;
    }
}
