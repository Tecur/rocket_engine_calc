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
            this.Name = "Form_about";                                 //MLHIDE
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
            resources.ApplyResources(this.notifyIcon1, "notifyIcon1");
            // 
            // l_header
            // 
            resources.ApplyResources(this.l_header, "l_header");
            this.l_header.ForeColor = System.Drawing.Color.Teal;
            this.l_header.Name = "l_header";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.l_header);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.B_OK);
            this.panel2.Controls.Add(this.lL_Licence);
            this.panel2.Controls.Add(this.lL_Website);
            this.panel2.Controls.Add(this.lL_Repo);
            this.panel2.Controls.Add(this.l_Links);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // B_OK
            // 
            resources.ApplyResources(this.B_OK, "B_OK");
            this.B_OK.Name = "B_OK";
            this.B_OK.UseVisualStyleBackColor = true;
            this.B_OK.Click += new System.EventHandler(this.B_OK_Click);
            // 
            // lL_Licence
            // 
            resources.ApplyResources(this.lL_Licence, "lL_Licence");
            this.lL_Licence.Name = "lL_Licence";
            this.lL_Licence.TabStop = true;
            this.lL_Licence.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LL_Licence_LinkClicked);
            // 
            // lL_Website
            // 
            resources.ApplyResources(this.lL_Website, "lL_Website");
            this.lL_Website.Name = "lL_Website";
            this.lL_Website.TabStop = true;
            this.lL_Website.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LL_Website_LinkClicked);
            // 
            // lL_Repo
            // 
            resources.ApplyResources(this.lL_Repo, "lL_Repo");
            this.lL_Repo.Name = "lL_Repo";
            this.lL_Repo.TabStop = true;
            this.lL_Repo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LL_Repo_LinkClicked);
            // 
            // l_Links
            // 
            resources.ApplyResources(this.l_Links, "l_Links");
            this.l_Links.Name = "l_Links";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.L_desc);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // L_desc
            // 
            resources.ApplyResources(this.L_desc, "L_desc");
            this.L_desc.Name = "L_desc";
            // 
            // Form_about
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form_about";
            this.ShowIcon = false;
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

