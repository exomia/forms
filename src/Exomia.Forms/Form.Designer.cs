namespace Exomia.Forms
{
    partial class Form
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
            this.panelSideLeft = new System.Windows.Forms.Panel();
            this.panelSidebarContainer = new System.Windows.Forms.Panel();
            this.panelSidebarIcon = new System.Windows.Forms.Panel();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelSideLeft.SuspendLayout();
            this.panelSidebarIcon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSideLeft
            // 
            this.panelSideLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.panelSideLeft.Controls.Add(this.panelSidebarContainer);
            this.panelSideLeft.Controls.Add(this.panelSidebarIcon);
            this.panelSideLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideLeft.Location = new System.Drawing.Point(0, 0);
            this.panelSideLeft.Name = "panelSideLeft";
            this.panelSideLeft.Size = new System.Drawing.Size(250, 600);
            this.panelSideLeft.TabIndex = 0;
            // 
            // panelSidebarContainer
            // 
            this.panelSidebarContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSidebarContainer.Location = new System.Drawing.Point(0, 150);
            this.panelSidebarContainer.Name = "panelSidebarContainer";
            this.panelSidebarContainer.Size = new System.Drawing.Size(250, 450);
            this.panelSidebarContainer.TabIndex = 1;
            // 
            // panelSidebarIcon
            // 
            this.panelSidebarIcon.Controls.Add(this.pictureBoxIcon);
            this.panelSidebarIcon.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSidebarIcon.Location = new System.Drawing.Point(0, 0);
            this.panelSidebarIcon.Name = "panelSidebarIcon";
            this.panelSidebarIcon.Padding = new System.Windows.Forms.Padding(7);
            this.panelSidebarIcon.Size = new System.Drawing.Size(250, 150);
            this.panelSidebarIcon.TabIndex = 0;
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxIcon.Location = new System.Drawing.Point(7, 7);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Size = new System.Drawing.Size(236, 136);
            this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxIcon.TabIndex = 0;
            this.pictureBoxIcon.TabStop = false;
            this.pictureBoxIcon.Click += new System.EventHandler(this.pictureBoxIcon_Click);
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(250, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(750, 600);
            this.panelMain.TabIndex = 1;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelSideLeft);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "Form";
            this.panelSideLeft.ResumeLayout(false);
            this.panelSidebarIcon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSideLeft;
        private System.Windows.Forms.Panel panelSidebarIcon;
        private System.Windows.Forms.Panel panelMain;
        
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.Panel panelSidebarContainer;
    }
}