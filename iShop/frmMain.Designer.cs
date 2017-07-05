namespace iShop
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.mPanel = new MetroFramework.Controls.MetroPanel();
            this.lblDateTime = new MetroFramework.Controls.MetroLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnLogout = new System.Windows.Forms.PictureBox();
            this.mBack = new MetroFramework.Controls.MetroLink();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mPanel.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // mPanel
            // 
            this.mPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mPanel.AutoScroll = true;
            this.mPanel.BackColor = System.Drawing.Color.White;
            this.mPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mPanel.Controls.Add(this.lblDateTime);
            this.mPanel.HorizontalScrollbar = true;
            this.mPanel.HorizontalScrollbarBarColor = true;
            this.mPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.mPanel.HorizontalScrollbarSize = 10;
            this.mPanel.Location = new System.Drawing.Point(5, 52);
            this.mPanel.Name = "mPanel";
            this.mPanel.Size = new System.Drawing.Size(1298, 702);
            this.mPanel.TabIndex = 0;
            this.mPanel.UseCustomBackColor = true;
            this.mPanel.UseCustomForeColor = true;
            this.mPanel.UseStyleColors = true;
            this.mPanel.VerticalScrollbar = true;
            this.mPanel.VerticalScrollbarBarColor = true;
            this.mPanel.VerticalScrollbarHighlightOnWheel = false;
            this.mPanel.VerticalScrollbarSize = 10;
            // 
            // lblDateTime
            // 
            this.lblDateTime.Location = new System.Drawing.Point(520, 676);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(100, 23);
            this.lblDateTime.TabIndex = 2;
            this.lblDateTime.Text = "??";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(104, 48);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Important Notice";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // btnLogout
            // 
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.Image = global::iShop.Properties.Resources.Reset1;
            this.btnLogout.Location = new System.Drawing.Point(1132, 14);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(46, 32);
            this.btnLogout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnLogout.TabIndex = 3;
            this.btnLogout.TabStop = false;
            this.btnLogout.Visible = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // mBack
            // 
            this.mBack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mBack.AutoSize = true;
            this.mBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mBack.Image = global::iShop.Properties.Resources.arrow_left;
            this.mBack.ImageSize = 32;
            this.mBack.Location = new System.Drawing.Point(753, 25);
            this.mBack.Name = "mBack";
            this.mBack.Size = new System.Drawing.Size(52, 23);
            this.mBack.TabIndex = 2;
            this.mBack.UseSelectable = true;
            this.mBack.Click += new System.EventHandler(this.mBack_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::iShop.Properties.Resources.dapt_logoo;
            this.pictureBox1.Location = new System.Drawing.Point(35, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(66, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(1310, 759);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.mBack);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.mPanel);
            this.Name = "frmMain";
            this.Text = "                  Stock InV";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.mPanel.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnLogout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroPanel mPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroLink mBack;
        private MetroFramework.Controls.MetroLabel lblDateTime;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.PictureBox btnLogout;
    }
}