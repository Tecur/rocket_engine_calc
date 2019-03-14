using System;
using System.Windows.Forms;

namespace rocket_engine_calc
{
    partial class Form_about
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent_2()
        {
            
            // 
            // Form
            // 
            this.ClientSize = new System.Drawing.Size(274, 229);
            this.Name = "Form_about";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label l_header;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.LinkLabel lL_Licence;
        private System.Windows.Forms.LinkLabel lL_Website;
        private System.Windows.Forms.LinkLabel lL_Repo;
        private System.Windows.Forms.Label l_Links;
        private System.Windows.Forms.Panel panel3;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_about));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.l_header = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.B_OK = new System.Windows.Forms.Button();
            this.lL_Licence = new System.Windows.Forms.LinkLabel();
            this.lL_Website = new System.Windows.Forms.LinkLabel();
            this.lL_Repo = new System.Windows.Forms.LinkLabel();
            this.l_Links = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.L_desc = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // l_header
            // 
            this.l_header.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.l_header.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_header.ForeColor = System.Drawing.Color.Teal;
            this.l_header.Location = new System.Drawing.Point(3, 45);
            this.l_header.Name = "l_header";
            this.l_header.Size = new System.Drawing.Size(591, 55);
            this.l_header.TabIndex = 0;
            this.l_header.Text = "Rocket Engine Calculator";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.l_header);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(594, 103);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.B_OK);
            this.panel2.Controls.Add(this.lL_Licence);
            this.panel2.Controls.Add(this.lL_Website);
            this.panel2.Controls.Add(this.lL_Repo);
            this.panel2.Controls.Add(this.l_Links);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(384, 103);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(210, 355);
            this.panel2.TabIndex = 2;
            // 
            // B_OK
            // 
            this.B_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_OK.Location = new System.Drawing.Point(22, 304);
            this.B_OK.Name = "B_OK";
            this.B_OK.Size = new System.Drawing.Size(176, 39);
            this.B_OK.TabIndex = 4;
            this.B_OK.Text = "OK";
            this.B_OK.UseVisualStyleBackColor = true;
            this.B_OK.Click += new System.EventHandler(this.B_OK_Click);
            // 
            // lL_Licence
            // 
            this.lL_Licence.AutoSize = true;
            this.lL_Licence.Location = new System.Drawing.Point(7, 93);
            this.lL_Licence.Name = "lL_Licence";
            this.lL_Licence.Size = new System.Drawing.Size(200, 25);
            this.lL_Licence.TabIndex = 3;
            this.lL_Licence.TabStop = true;
            this.lL_Licence.Text = "Lizenzbedingungen";
            this.lL_Licence.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LL_Licence_LinkClicked);
            // 
            // lL_Website
            // 
            this.lL_Website.AutoSize = true;
            this.lL_Website.Location = new System.Drawing.Point(4, 64);
            this.lL_Website.Name = "lL_Website";
            this.lL_Website.Size = new System.Drawing.Size(181, 25);
            this.lL_Website.TabIndex = 2;
            this.lL_Website.TabStop = true;
            this.lL_Website.Text = "Joshua\'s Website";
            this.lL_Website.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LL_Website_LinkClicked);
            // 
            // lL_Repo
            // 
            this.lL_Repo.AutoSize = true;
            this.lL_Repo.Location = new System.Drawing.Point(7, 35);
            this.lL_Repo.Name = "lL_Repo";
            this.lL_Repo.Size = new System.Drawing.Size(187, 25);
            this.lL_Repo.TabIndex = 1;
            this.lL_Repo.TabStop = true;
            this.lL_Repo.Text = "GitHub Repository";
            this.lL_Repo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LL_Repo_LinkClicked);
            // 
            // l_Links
            // 
            this.l_Links.AutoSize = true;
            this.l_Links.Dock = System.Windows.Forms.DockStyle.Top;
            this.l_Links.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Links.Location = new System.Drawing.Point(0, 0);
            this.l_Links.Name = "l_Links";
            this.l_Links.Size = new System.Drawing.Size(83, 31);
            this.l_Links.TabIndex = 0;
            this.l_Links.Text = "Links";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.L_desc);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 103);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(384, 355);
            this.panel3.TabIndex = 3;
            // 
            // L_desc
            // 
            this.L_desc.AutoSize = true;
            this.L_desc.Location = new System.Drawing.Point(4, 7);
            this.L_desc.Name = "L_desc";
            this.L_desc.Size = new System.Drawing.Size(223, 25);
            this.L_desc.TabIndex = 0;
            this.L_desc.Text = "-Loading Version Info-";
            // 
            // Form_about
            // 
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(594, 458);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_about";
            this.ShowIcon = false;
            this.Text = "Über RE Calc";
            this.Load += new System.EventHandler(this.Form_about_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        private Button B_OK;
        private Label L_desc;
    }
}

