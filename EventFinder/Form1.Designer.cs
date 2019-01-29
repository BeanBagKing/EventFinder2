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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EventRangeBox.SuspendLayout();
            this.Status.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(3, 20);
            this.StartButton.Margin = new System.Windows.Forms.Padding(2);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(67, 28);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start Time";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // EndButton
            // 
            this.EndButton.Location = new System.Drawing.Point(3, 51);
            this.EndButton.Margin = new System.Windows.Forms.Padding(2);
            this.EndButton.Name = "EndButton";
            this.EndButton.Size = new System.Drawing.Size(67, 29);
            this.EndButton.TabIndex = 1;
            this.EndButton.Text = "End Time";
            this.EndButton.UseVisualStyleBackColor = true;
            this.EndButton.Click += new System.EventHandler(this.EndButton_Click);
            // 
            // StartInput
            // 
            this.StartInput.Location = new System.Drawing.Point(83, 26);
            this.StartInput.Margin = new System.Windows.Forms.Padding(2);
            this.StartInput.Name = "StartInput";
            this.StartInput.Size = new System.Drawing.Size(141, 20);
            this.StartInput.TabIndex = 2;
            // 
            // EndInput
            // 
            this.EndInput.Location = new System.Drawing.Point(83, 57);
            this.EndInput.Margin = new System.Windows.Forms.Padding(2);
            this.EndInput.Name = "EndInput";
            this.EndInput.Size = new System.Drawing.Size(141, 20);
            this.EndInput.TabIndex = 3;
            // 
            // FindEventsButton
            // 
            this.FindEventsButton.Location = new System.Drawing.Point(77, 130);
            this.FindEventsButton.Margin = new System.Windows.Forms.Padding(2);
            this.FindEventsButton.Name = "FindEventsButton";
            this.FindEventsButton.Size = new System.Drawing.Size(80, 28);
            this.FindEventsButton.TabIndex = 4;
            this.FindEventsButton.Text = "Find Events";
            this.FindEventsButton.UseVisualStyleBackColor = true;
            this.FindEventsButton.Click += new System.EventHandler(this.FindEventsButton_Click);
            // 
            // StatusOutput
            // 
            this.StatusOutput.AutoSize = true;
            this.StatusOutput.Location = new System.Drawing.Point(9, 19);
            this.StatusOutput.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.StatusOutput.Name = "StatusOutput";
            this.StatusOutput.Size = new System.Drawing.Size(166, 13);
            this.StatusOutput.TabIndex = 5;
            this.StatusOutput.Text = "Checking for administrator rights...";
            // 
            // EventRangeBox
            // 
            this.EventRangeBox.Controls.Add(this.StartButton);
            this.EventRangeBox.Controls.Add(this.EndButton);
            this.EventRangeBox.Controls.Add(this.StartInput);
            this.EventRangeBox.Controls.Add(this.EndInput);
            this.EventRangeBox.Location = new System.Drawing.Point(7, 30);
            this.EventRangeBox.Margin = new System.Windows.Forms.Padding(2);
            this.EventRangeBox.Name = "EventRangeBox";
            this.EventRangeBox.Padding = new System.Windows.Forms.Padding(2);
            this.EventRangeBox.Size = new System.Drawing.Size(231, 91);
            this.EventRangeBox.TabIndex = 6;
            this.EventRangeBox.TabStop = false;
            this.EventRangeBox.Text = "Event Range";
            // 
            // Status
            // 
            this.Status.Controls.Add(this.StatusOutput);
            this.Status.Location = new System.Drawing.Point(10, 168);
            this.Status.Margin = new System.Windows.Forms.Padding(2);
            this.Status.Name = "Status";
            this.Status.Padding = new System.Windows.Forms.Padding(2);
            this.Status.Size = new System.Drawing.Size(220, 80);
            this.Status.TabIndex = 7;
            this.Status.TabStop = false;
            this.Status.Text = "Status";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(244, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.fileToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem1.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // FindEvents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 258);
            this.Controls.Add(this.FindEventsButton);
            this.Controls.Add(this.EventRangeBox);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FindEvents";
            this.Text = "EventFinder";
            this.EventRangeBox.ResumeLayout(false);
            this.EventRangeBox.PerformLayout();
            this.Status.ResumeLayout(false);
            this.Status.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

