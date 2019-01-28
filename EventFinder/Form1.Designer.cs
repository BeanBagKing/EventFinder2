namespace EventFinder
{
    partial class FindEvents
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
            this.StartButton = new System.Windows.Forms.Button();
            this.EndButton = new System.Windows.Forms.Button();
            this.StartInput = new System.Windows.Forms.TextBox();
            this.EndInput = new System.Windows.Forms.TextBox();
            this.FindEventsButton = new System.Windows.Forms.Button();
            this.StatusOutput = new System.Windows.Forms.Label();
            this.EventRangeBox = new System.Windows.Forms.GroupBox();
            this.Status = new System.Windows.Forms.GroupBox();
            this.EventRangeBox.SuspendLayout();
            this.Status.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(6, 37);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(123, 52);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start Time";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // EndButton
            // 
            this.EndButton.Location = new System.Drawing.Point(6, 95);
            this.EndButton.Name = "EndButton";
            this.EndButton.Size = new System.Drawing.Size(123, 53);
            this.EndButton.TabIndex = 1;
            this.EndButton.Text = "End Time";
            this.EndButton.UseVisualStyleBackColor = true;
            this.EndButton.Click += new System.EventHandler(this.EndButton_Click);
            // 
            // StartInput
            // 
            this.StartInput.Location = new System.Drawing.Point(153, 48);
            this.StartInput.Name = "StartInput";
            this.StartInput.Size = new System.Drawing.Size(256, 29);
            this.StartInput.TabIndex = 2;
            // 
            // EndInput
            // 
            this.EndInput.Location = new System.Drawing.Point(153, 106);
            this.EndInput.Name = "EndInput";
            this.EndInput.Size = new System.Drawing.Size(256, 29);
            this.EndInput.TabIndex = 3;
            // 
            // FindEventsButton
            // 
            this.FindEventsButton.Location = new System.Drawing.Point(142, 198);
            this.FindEventsButton.Name = "FindEventsButton";
            this.FindEventsButton.Size = new System.Drawing.Size(147, 51);
            this.FindEventsButton.TabIndex = 4;
            this.FindEventsButton.Text = "Find Events";
            this.FindEventsButton.UseVisualStyleBackColor = true;
            this.FindEventsButton.Click += new System.EventHandler(this.FindEventsButton_Click);
            // 
            // StatusOutput
            // 
            this.StatusOutput.AutoSize = true;
            this.StatusOutput.Location = new System.Drawing.Point(16, 35);
            this.StatusOutput.Name = "StatusOutput";
            this.StatusOutput.Text = "Checking for administrator rights...";
            this.StatusOutput.Size = new System.Drawing.Size(0, 25);
            this.StatusOutput.TabIndex = 5;
            // 
            // EventRangeBox
            // 
            this.EventRangeBox.Controls.Add(this.StartButton);
            this.EventRangeBox.Controls.Add(this.EndButton);
            this.EventRangeBox.Controls.Add(this.StartInput);
            this.EventRangeBox.Controls.Add(this.EndInput);
            this.EventRangeBox.Location = new System.Drawing.Point(12, 13);
            this.EventRangeBox.Name = "EventRangeBox";
            this.EventRangeBox.Size = new System.Drawing.Size(423, 168);
            this.EventRangeBox.TabIndex = 6;
            this.EventRangeBox.TabStop = false;
            this.EventRangeBox.Text = "Event Range";
            // 
            // Status
            // 
            this.Status.Controls.Add(this.StatusOutput);
            this.Status.Location = new System.Drawing.Point(18, 268);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(403, 147);
            this.Status.TabIndex = 7;
            this.Status.TabStop = false;
            this.Status.Text = "Status";
            // 
            // FindEvents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 427);
            this.Controls.Add(this.FindEventsButton);
            this.Controls.Add(this.EventRangeBox);
            this.Controls.Add(this.Status);
            this.Name = "FindEvents";
            this.Text = "EventFinder 2.0";
            this.EventRangeBox.ResumeLayout(false);
            this.EventRangeBox.PerformLayout();
            this.Status.ResumeLayout(false);
            this.Status.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button EndButton;
        private System.Windows.Forms.TextBox StartInput;
        private System.Windows.Forms.TextBox EndInput;
        private System.Windows.Forms.Button FindEventsButton;
        private System.Windows.Forms.Label StatusOutput;
        private System.Windows.Forms.GroupBox EventRangeBox;
        private System.Windows.Forms.GroupBox Status;
    }
}

