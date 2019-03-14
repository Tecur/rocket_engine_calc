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
        }

        private void LL_Website_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://tecur.github.io/";
            try
            {

                VisitLink(url);
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to open link that was clicked.");
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
            string url = "https://raw.githubusercontent.com/Tecur/rocket_engine_calc/master/LICENSE.md";
            try
            {
                VisitLink(url);
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to open link that was clicked.");
            }
        }

        private void LL_Repo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://github.com/Tecur/rocket_engine_calc";
            try
            {
                VisitLink(url);
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to open link that was clicked.");
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
                ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_OperatingSystem");
                string re = "";
                foreach (ManagementObject managementObject in mos.Get())
                {
                    if (managementObject["Caption"] != null)
                    {
                        re += ("OS Name  :  " + managementObject["Caption"].ToString());   //Display operating system caption
                    }
                    if (managementObject["OSArchitecture"] != null)
                    {
                        re += (Environment.NewLine +"OS Architektur  :  " + managementObject["OSArchitecture"].ToString());   //Display operating system architecture.
                    }
                    if (managementObject["CSDVersion"] != null)
                    {
                        re += (Environment.NewLine +"OS Service Pack   :  " + managementObject["CSDVersion"].ToString());     //Display operating system version.
                    }
                }
                return re;
            }
            private static string GetProcessorInfo()
            {
                Console.WriteLine("\n\nDisplaying Processor Name....");
                RegistryKey processor_name = Registry.LocalMachine.OpenSubKey(@"Hardware\Description\System\CentralProcessor\0", RegistryKeyPermissionCheck.ReadSubTree);   //This registry entry contains entry for processor info.

                if (processor_name != null)
                {
                    if (processor_name.GetValue("ProcessorNameString") != null)
                    {
                        return "CPU: " +Convert.ToString(processor_name.GetValue("ProcessorNameString"));   //Display processor ingo.
                    }
                    else { return "Error"; }
                }
                else { return "Error"; }
            }

        private void B_OK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
