namespace JobAlert
{
    partial class AlertWindow
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.pBox1 = new System.Windows.Forms.PictureBox();
            this.pBoxMinimize = new System.Windows.Forms.PictureBox();
            this.pLink = new System.Windows.Forms.PictureBox();
            this.pBoxExit = new System.Windows.Forms.PictureBox();
            this.pBox2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lTag = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.lSite = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lLocation = new System.Windows.Forms.Label();
            this.lDate = new System.Windows.Forms.Label();
            this.lTitle = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pLink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::JobAlert.Properties.Resources.ACFO_job_vacancy_en_1024x800;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.pBox1);
            this.panel2.Controls.Add(this.pBoxMinimize);
            this.panel2.Controls.Add(this.pLink);
            this.panel2.Controls.Add(this.pBoxExit);
            this.panel2.Controls.Add(this.pBox2);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(660, 394);
            this.panel2.TabIndex = 14;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drag_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drag_MouseMove);
            // 
            // pBox1
            // 
            this.pBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pBox1.Image = global::JobAlert.Properties.Resources.next_button_png;
            this.pBox1.Location = new System.Drawing.Point(550, 285);
            this.pBox1.Name = "pBox1";
            this.pBox1.Size = new System.Drawing.Size(100, 100);
            this.pBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBox1.TabIndex = 10;
            this.pBox1.TabStop = false;
            this.pBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pBox1_MouseClick);
            this.pBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pBox1_MouseDoubleClick);
            this.pBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBox1_MouseDown);
            this.pBox1.MouseEnter += new System.EventHandler(this.pBox1_MouseEnter);
            this.pBox1.MouseLeave += new System.EventHandler(this.pBox1_MouseLeave_1);
            this.pBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBox1_MouseUp);
            // 
            // pBoxMinimize
            // 
            this.pBoxMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pBoxMinimize.Image = global::JobAlert.Properties.Resources.MinBlack;
            this.pBoxMinimize.Location = new System.Drawing.Point(582, 4);
            this.pBoxMinimize.Name = "pBoxMinimize";
            this.pBoxMinimize.Size = new System.Drawing.Size(25, 25);
            this.pBoxMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxMinimize.TabIndex = 5;
            this.pBoxMinimize.TabStop = false;
            this.pBoxMinimize.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pBoxMinimize.MouseLeave += new System.EventHandler(this.pBoxMinimize_MouseLeave);
            this.pBoxMinimize.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pBoxMinimize_MouseMove);
            // 
            // pLink
            // 
            this.pLink.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pLink.Image = global::JobAlert.Properties.Resources.link;
            this.pLink.Location = new System.Drawing.Point(290, 285);
            this.pLink.Name = "pLink";
            this.pLink.Size = new System.Drawing.Size(100, 100);
            this.pLink.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pLink.TabIndex = 13;
            this.pLink.TabStop = false;
            this.pLink.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pLink_MouseClick);
            this.pLink.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pLink_MouseDown);
            this.pLink.MouseEnter += new System.EventHandler(this.pLink_MouseEnter);
            this.pLink.MouseLeave += new System.EventHandler(this.pLink_MouseLeave);
            this.pLink.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pLink_MouseUp);
            // 
            // pBoxExit
            // 
            this.pBoxExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pBoxExit.Image = global::JobAlert.Properties.Resources.Xblack;
            this.pBoxExit.Location = new System.Drawing.Point(622, 4);
            this.pBoxExit.Name = "pBoxExit";
            this.pBoxExit.Size = new System.Drawing.Size(25, 25);
            this.pBoxExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxExit.TabIndex = 4;
            this.pBoxExit.TabStop = false;
            this.pBoxExit.Click += new System.EventHandler(this.pictureBox2_Click);
            this.pBoxExit.MouseLeave += new System.EventHandler(this.pBoxExit_MouseLeave);
            this.pBoxExit.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pBoxExit_MouseMove);
            // 
            // pBox2
            // 
            this.pBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pBox2.Image = global::JobAlert.Properties.Resources.prev_button_png;
            this.pBox2.Location = new System.Drawing.Point(15, 285);
            this.pBox2.Name = "pBox2";
            this.pBox2.Size = new System.Drawing.Size(100, 100);
            this.pBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBox2.TabIndex = 11;
            this.pBox2.TabStop = false;
            this.pBox2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pBox2_MouseClick);
            this.pBox2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pBox2_MouseDoubleClick);
            this.pBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBox2_MouseDown);
            this.pBox2.MouseEnter += new System.EventHandler(this.pBox2_MouseEnter);
            this.pBox2.MouseLeave += new System.EventHandler(this.pBox2_MouseLeave);
            this.pBox2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBox2_MouseUp);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.lTag);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.lSite);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lLocation);
            this.panel1.Controls.Add(this.lDate);
            this.panel1.Controls.Add(this.lTitle);
            this.panel1.Location = new System.Drawing.Point(10, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(640, 244);
            this.panel1.TabIndex = 6;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drag_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drag_MouseMove);
            // 
            // lTag
            // 
            this.lTag.AutoSize = true;
            this.lTag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lTag.Font = new System.Drawing.Font("Bahnschrift SemiBold Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lTag.ForeColor = System.Drawing.Color.DarkBlue;
            this.lTag.Location = new System.Drawing.Point(35, 210);
            this.lTag.MaximumSize = new System.Drawing.Size(635, 35);
            this.lTag.Name = "lTag";
            this.lTag.Size = new System.Drawing.Size(32, 24);
            this.lTag.TabIndex = 14;
            this.lTag.Text = "Tag";
            this.lTag.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drag_MouseDown);
            this.lTag.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drag_MouseMove);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox4.Image = global::JobAlert.Properties.Resources._585e4adacb11b227491c3392;
            this.pictureBox4.Location = new System.Drawing.Point(5, 210);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(25, 25);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 13;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drag_MouseDown);
            this.pictureBox4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drag_MouseMove);
            // 
            // lSite
            // 
            this.lSite.AutoSize = true;
            this.lSite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lSite.Font = new System.Drawing.Font("Bahnschrift SemiBold Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lSite.ForeColor = System.Drawing.Color.DarkBlue;
            this.lSite.Location = new System.Drawing.Point(35, 180);
            this.lSite.MaximumSize = new System.Drawing.Size(635, 35);
            this.lSite.Name = "lSite";
            this.lSite.Size = new System.Drawing.Size(43, 24);
            this.lSite.TabIndex = 9;
            this.lSite.Text = "Page";
            this.lSite.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lSite.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drag_MouseDown);
            this.lSite.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drag_MouseMove);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(554, 215);
            this.label1.MaximumSize = new System.Drawing.Size(150, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 29);
            this.label1.TabIndex = 12;
            this.label1.Text = "100/120";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.UseCompatibleTextRendering = true;
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drag_MouseDown);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drag_MouseMove);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox3.Image = global::JobAlert.Properties.Resources.web;
            this.pictureBox3.Location = new System.Drawing.Point(5, 180);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(25, 25);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drag_MouseDown);
            this.pictureBox3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drag_MouseMove);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox2.Image = global::JobAlert.Properties.Resources.img_149705;
            this.pictureBox2.Location = new System.Drawing.Point(5, 150);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 25);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drag_MouseDown);
            this.pictureBox2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drag_MouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox1.Image = global::JobAlert.Properties.Resources.location;
            this.pictureBox1.Location = new System.Drawing.Point(5, 120);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drag_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drag_MouseMove);
            // 
            // lLocation
            // 
            this.lLocation.AutoSize = true;
            this.lLocation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lLocation.Font = new System.Drawing.Font("Bahnschrift SemiBold Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lLocation.ForeColor = System.Drawing.Color.DarkBlue;
            this.lLocation.Location = new System.Drawing.Point(35, 120);
            this.lLocation.MaximumSize = new System.Drawing.Size(635, 35);
            this.lLocation.Name = "lLocation";
            this.lLocation.Size = new System.Drawing.Size(66, 24);
            this.lLocation.TabIndex = 5;
            this.lLocation.Text = "Location";
            this.lLocation.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drag_MouseDown);
            this.lLocation.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drag_MouseMove);
            // 
            // lDate
            // 
            this.lDate.AutoSize = true;
            this.lDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lDate.Font = new System.Drawing.Font("Bahnschrift SemiBold Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lDate.ForeColor = System.Drawing.Color.DarkBlue;
            this.lDate.Location = new System.Drawing.Point(35, 150);
            this.lDate.MaximumSize = new System.Drawing.Size(635, 35);
            this.lDate.Name = "lDate";
            this.lDate.Size = new System.Drawing.Size(95, 24);
            this.lDate.TabIndex = 4;
            this.lDate.Text = "21 December";
            this.lDate.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drag_MouseDown);
            this.lDate.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drag_MouseMove);
            // 
            // lTitle
            // 
            this.lTitle.AutoSize = true;
            this.lTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lTitle.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lTitle.ForeColor = System.Drawing.Color.Black;
            this.lTitle.Location = new System.Drawing.Point(0, 0);
            this.lTitle.MaximumSize = new System.Drawing.Size(620, 150);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(500, 68);
            this.lTitle.TabIndex = 0;
            this.lTitle.Text = "JOB JOB JOB JOB JOB JOB JOBJOB\r\n JOB JOB JOB JOB JOB JOB JOB JOB v JOB JOB v JOB";
            this.lTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drag_MouseDown);
            this.lTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drag_MouseMove);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(665, 400);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Opacity = 0.98D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drag_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drag_MouseMove);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pLink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pBoxExit;
        private System.Windows.Forms.PictureBox pBoxMinimize;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lTitle;
        private System.Windows.Forms.PictureBox pBox1;
        private System.Windows.Forms.PictureBox pBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lDate;
        private System.Windows.Forms.Label lLocation;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pLink;
        private System.Windows.Forms.Label lSite;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lTag;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel panel2;
    }
}

