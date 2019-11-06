using rocket_engine_calc.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using Microsoft.Win32;   

namespace rocket_engine_calc
{
        public partial class Form_about : System.Windows.Forms.Form
    {
        public Form_about()
        {
            InitializeComponent();
         
          this.Disposed += new System.EventHandler ( this.Form_about_Disposed );
          MLRuntime.MLRuntime.LanguageChanged += new MLRuntime.MLRuntime.LanguageChangedDelegate ( ml_UpdateControls ) ;
        }

        private void LL_Website_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://tecur.github.io/";                  //MLHIDE
            try
            {

                VisitLink(url);
            }
            catch (Exception)
            {
                MessageBox.Show(Resources.Unable_to_open_link_that_was_c);
            }
        }

        private void VisitLink(string url)
        {
            // Change the color of the link text by setting LinkVisited   
            // to true.  
            lL_Repo.LinkVisited = true;
            //Call the Process.Start method to open the default browser   
            //with a URL:  
            System.Diagnostics.Process.Start(url);
        }

        private void LL_Licence_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://raw.githubusercontent.com/Tecur/rocket_engine_calc/master/LICENSE.md"; //MLHIDE
            try
            {
                VisitLink(url);
            }
            catch (Exception)
            {
                MessageBox.Show(Resources.Unable_to_open_link_that_was_c0);
            }
        }

        private void LL_Repo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://github.com/Tecur/rocket_engine_calc"; //MLHIDE
            try
            {
                VisitLink(url);
            }
            catch (Exception)
            {
                MessageBox.Show(Resources.Unable_to_open_link_that_was_c1);
            }
        }
        
            private void Form_about_Load(object sender, EventArgs e)
            {
                string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                SystemInfo si = new SystemInfo();       //Create an object of SystemInfo class.
                string os = GetOperatingSystemInfo();            //Call get operating system info method which will display operating system information.
                string cpu = GetProcessorInfo();

                L_desc.Text = "Version: " + version + Environment.NewLine;
                L_desc.Text += os + Environment.NewLine;
                L_desc.Text += cpu + Environment.NewLine;
                L_desc.Text += "© Joshua Stoll " + DateTime.Now.Year.ToString();
            }
        public class SystemInfo
        {
        }
            private static string GetOperatingSystemInfo()
            {
                //Create an object of ManagementObjectSearcher class and pass query as parameter.
                ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_OperatingSystem"); //MLHIDE
                string re = "";
                foreach (ManagementObject managementObject in mos.Get())
                {
                    if (managementObject["Caption"] != null)          //MLHIDE
                    {
                        re += ("OS: " + managementObject["Caption"].ToString());   //Display operating system caption //MLHIDE
                    }
                    if (managementObject["OSArchitecture"] != null)   //MLHIDE
                    {
                        re += (Environment.NewLine +"OS Architecture:" + managementObject["OSArchitecture"].ToString());   //Display operating system architecture. //MLHIDE
                    }
                    if (managementObject["CSDVersion"] != null)       //MLHIDE
                    {
                        re += (Environment.NewLine +"OS Service Pack: " + managementObject["CSDVersion"].ToString());     //Display operating system version. //MLHIDE
                    }
                }
                return re;
            }
            private static string GetProcessorInfo()
            {
                Console.WriteLine(@"

Displaying Processor Name....");
                RegistryKey processor_name = Registry.LocalMachine.OpenSubKey(@"Hardware\Description\System\CentralProcessor\0", RegistryKeyPermissionCheck.ReadSubTree);   //This registry entry contains entry for processor info. //MLHIDE

                if (processor_name != null)
                {
                    if (processor_name.GetValue("ProcessorNameString") != null) //MLHIDE
                    {
                        return "CPU: " +Convert.ToString(processor_name.GetValue("ProcessorNameString"));   //Display processor ingo. //MLHIDE
                    }
                    else { return "Error"; }
                }
                else { return "Error"; }
            }

        private void B_OK_Click(object sender, EventArgs e)
        {
            Close();
        }
      protected virtual void ml_UpdateControls()
      {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager ( typeof ( Form_about ) );
        this.Text = resources.GetString("$this.Text") ;
        B_OK.Text = resources.GetString("B_OK.Text") ;
        L_desc.Text = resources.GetString("L_desc.Text") ;
        lL_Licence.Text = resources.GetString("lL_Licence.Text") ;
      }

      public void Form_about_Disposed ( object sender, System.EventArgs e )
      {
        
        MLRuntime.MLRuntime.LanguageChanged -= new MLRuntime.MLRuntime.LanguageChangedDelegate ( ml_UpdateControls ) ;
      }
    }
}
