namespace MatiAplikacja
{
    partial class MatiForm
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
            this.buttonStart = new System.Windows.Forms.Button();
            this.progressBarTimeElapsed = new System.Windows.Forms.ProgressBar();
            this.textBoxTimeRemaining = new System.Windows.Forms.TextBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonStart.Location = new System.Drawing.Point(75, 178);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(100, 50);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "START";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // progressBarTimeElapsed
            // 
            this.progressBarTimeElapsed.Location = new System.Drawing.Point(12, 116);
            this.progressBarTimeElapsed.Maximum = 10000;
            this.progressBarTimeElapsed.Name = "progressBarTimeElapsed";
            this.progressBarTimeElapsed.Size = new System.Drawing.Size(460, 23);
            this.progressBarTimeElapsed.Step = 1;
            this.progressBarTimeElapsed.TabIndex = 1;
            // 
            // textBoxTimeRemaining
            // 
            this.textBoxTimeRemaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 29F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxTimeRemaining.Location = new System.Drawing.Point(12, 28);
            this.textBoxTimeRemaining.Name = "textBoxTimeRemaining";
            this.textBoxTimeRemaining.Size = new System.Drawing.Size(460, 51);
            this.textBoxTimeRemaining.TabIndex = 2;
            this.textBoxTimeRemaining.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonReset
            // 
            this.buttonReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonReset.Location = new System.Drawing.Point(315, 178);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(100, 50);
            this.buttonReset.TabIndex = 3;
            this.buttonReset.Text = "RESET";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // MatiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 262);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.textBoxTimeRemaining);
            this.Controls.Add(this.progressBarTimeElapsed);
            this.Controls.Add(this.buttonStart);
            this.Name = "MatiForm";
            this.Text = "Mati is the greatest!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.ProgressBar progressBarTimeElapsed;
        private System.Windows.Forms.TextBox textBoxTimeRemaining;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Timer timer;
    }
}

