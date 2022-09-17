namespace TowerDefense.Client
{
    partial class MainForm
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
            this.response = new System.Windows.Forms.Label();
            this.selectedNumber = new System.Windows.Forms.NumericUpDown();
            this.EndTurnButton = new System.Windows.Forms.Button();
            this.gamePhaseLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.selectedNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // response
            // 
            this.response.AutoSize = true;
            this.response.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.response.Location = new System.Drawing.Point(357, 274);
            this.response.Name = "response";
            this.response.Size = new System.Drawing.Size(50, 20);
            this.response.TabIndex = 2;
            this.response.Text = "label1";
            // 
            // selectedNumber
            // 
            this.selectedNumber.Location = new System.Drawing.Point(324, 112);
            this.selectedNumber.Name = "selectedNumber";
            this.selectedNumber.Size = new System.Drawing.Size(150, 27);
            this.selectedNumber.TabIndex = 4;
            // 
            // EndTurnButton
            // 
            this.EndTurnButton.Location = new System.Drawing.Point(346, 190);
            this.EndTurnButton.Name = "EndTurnButton";
            this.EndTurnButton.Size = new System.Drawing.Size(94, 29);
            this.EndTurnButton.TabIndex = 5;
            this.EndTurnButton.Text = "End turn";
            this.EndTurnButton.UseVisualStyleBackColor = true;
            this.EndTurnButton.Click += new System.EventHandler(this.EndTurnButton_Click);
            // 
            // gamePhaseLabel
            // 
            this.gamePhaseLabel.AutoSize = true;
            this.gamePhaseLabel.Location = new System.Drawing.Point(642, 114);
            this.gamePhaseLabel.Name = "gamePhaseLabel";
            this.gamePhaseLabel.Size = new System.Drawing.Size(50, 20);
            this.gamePhaseLabel.TabIndex = 6;
            this.gamePhaseLabel.Text = "label1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gamePhaseLabel);
            this.Controls.Add(this.EndTurnButton);
            this.Controls.Add(this.selectedNumber);
            this.Controls.Add(this.response);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.selectedNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label response;
        private NumericUpDown selectedNumber;
        private Button EndTurnButton;
        private Label gamePhaseLabel;
    }
}