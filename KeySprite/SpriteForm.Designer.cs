namespace KeySprite
{
    partial class SpriteForm
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
            this.btnStart = new System.Windows.Forms.Button();
            this.numExecTime = new System.Windows.Forms.NumericUpDown();
            this.lbAlreadyExecTimes = new System.Windows.Forms.Label();
            this.tbTaskArg = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numExecTime)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(125, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(96, 21);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // numExecTime
            // 
            this.numExecTime.Location = new System.Drawing.Point(57, 14);
            this.numExecTime.Name = "numExecTime";
            this.numExecTime.Size = new System.Drawing.Size(50, 21);
            this.numExecTime.TabIndex = 1;
            // 
            // lbAlreadyExecTimes
            // 
            this.lbAlreadyExecTimes.AutoSize = true;
            this.lbAlreadyExecTimes.Location = new System.Drawing.Point(23, 16);
            this.lbAlreadyExecTimes.Name = "lbAlreadyExecTimes";
            this.lbAlreadyExecTimes.Size = new System.Drawing.Size(11, 12);
            this.lbAlreadyExecTimes.TabIndex = 2;
            this.lbAlreadyExecTimes.Text = "0";
            // 
            // tbTaskArg
            // 
            this.tbTaskArg.Location = new System.Drawing.Point(25, 42);
            this.tbTaskArg.Name = "tbTaskArg";
            this.tbTaskArg.Size = new System.Drawing.Size(196, 21);
            this.tbTaskArg.TabIndex = 3;
            // 
            // SpriteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 75);
            this.Controls.Add(this.tbTaskArg);
            this.Controls.Add(this.lbAlreadyExecTimes);
            this.Controls.Add(this.numExecTime);
            this.Controls.Add(this.btnStart);
            this.Name = "SpriteForm";
            this.Text = "SpriteForm";
            ((System.ComponentModel.ISupportInitialize)(this.numExecTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.NumericUpDown numExecTime;
        private System.Windows.Forms.Label lbAlreadyExecTimes;
        private System.Windows.Forms.TextBox tbTaskArg;
    }
}