using rocket_engine_calc.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace rocket_engine_calc
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
 
          this.Disposed += new System.EventHandler ( this.Form_Disposed );
          MLRuntime.MLRuntime.LanguageChanged += new MLRuntime.MLRuntime.LanguageChangedDelegate ( ml_UpdateControls ) ;
        }

        private void B_calc_Click(object sender, EventArgs e)
        {
            int digitcount = 2;

            Calculator _calculator = new Calculator(
                Convert.ToDouble(i_schub.Text),
                Convert.ToDouble(i_brenndr.Text),
                Convert.ToDouble(i_aussendr.Text),
                Convert.ToDouble(i_diabaten.Text),
                Convert.ToDouble(i_char_laenge.Text),
                Convert.ToDouble(i_T0.Text),
                Convert.ToDouble(i_Molmasse.Text),
                Convert.ToDouble(i_theta.Text)
                );

            //Berechnen
            _calculator.Calculate();
            //Ergebnisse anzeigen
            o_mae.Text = Convert.ToString(_calculator.Get_Ma_e(digitcount));
            System.Diagnostics.Debug.WriteLine("Ma_e = " + Convert.ToString(_calculator.Get_Ma_e(digitcount)) + " [-]"); //MLHIDE
            o_epsilon.Text = Convert.ToString(_calculator.Get_epsilon(digitcount));
            System.Diagnostics.Debug.WriteLine("ε = " + Convert.ToString(_calculator.Get_epsilon(digitcount)) + " [-]"); //MLHIDE
            o_gamma.Text = Convert.ToString(_calculator.Get_Gamma(digitcount));
            System.Diagnostics.Debug.WriteLine("Γ = " + Convert.ToString(_calculator.Get_Gamma(digitcount)) + " [-]"); //MLHIDE
            o_isp.Text = Convert.ToString(_calculator.Get_Isp(digitcount));
            System.Diagnostics.Debug.WriteLine("Isp = " + Convert.ToString(_calculator.Get_Isp(digitcount)) + " [s]"); //MLHIDE
            o_mdot.Text = Convert.ToString(_calculator.Get_massflow(digitcount));
            System.Diagnostics.Debug.WriteLine("m. = " + Convert.ToString(_calculator.Get_massflow(digitcount)) + " [kg/s]"); //MLHIDE
            o_pt.Text = Convert.ToString(_calculator.Get_pt(digitcount));
            System.Diagnostics.Debug.WriteLine("pt = " + Convert.ToString(_calculator.Get_pt(digitcount)) + " [Pa]"); //MLHIDE
            o_Tt.Text = Convert.ToString(_calculator.Get_Tt(digitcount));
            System.Diagnostics.Debug.WriteLine("Tt = " + Convert.ToString(_calculator.Get_Tt(digitcount)) + " [K]"); //MLHIDE
            o_At.Text = Convert.ToString(_calculator.Get_At(digitcount) * 10000);
            System.Diagnostics.Debug.WriteLine("At = " + Convert.ToString(_calculator.Get_At(digitcount) * 10000) + " [cm²]"); //MLHIDE
            o_Ae.Text = Convert.ToString(_calculator.Get_Ae(digitcount) * 10000);
            System.Diagnostics.Debug.WriteLine("Ae = " + Convert.ToString(_calculator.Get_Ae(digitcount) * 10000) + " [cm²]"); //MLHIDE
            o_Dt.Text = Convert.ToString(_calculator.Get_Dt(digitcount));
            System.Diagnostics.Debug.WriteLine("Dt = " + Convert.ToString(_calculator.Get_Dt(digitcount)) + " [cm]"); //MLHIDE
            o_De.Text = Convert.ToString(_calculator.Get_De(digitcount));
            System.Diagnostics.Debug.WriteLine("De = " + Convert.ToString(_calculator.Get_De(digitcount)) + " [cm]"); //MLHIDE
            o_Dc.Text = Convert.ToString(_calculator.Get_Dc(digitcount));
            System.Diagnostics.Debug.WriteLine("Dc = " + Convert.ToString(_calculator.Get_Dc(digitcount)) + " [cm]"); //MLHIDE
            o_Vc.Text = Convert.ToString(_calculator.Get_Vc(digitcount));
            System.Diagnostics.Debug.WriteLine("Vc = " + Convert.ToString(_calculator.Get_Vc(digitcount)) + " [cm³]"); //MLHIDE
            o_Lc.Text = Convert.ToString(_calculator.Get_Lc(digitcount));
            System.Diagnostics.Debug.WriteLine("Lc = " + Convert.ToString(_calculator.Get_Lc(digitcount)) + " [cm]"); //MLHIDE

            //Zeichnen
            Form_Drawboard f = new Form_Drawboard(_calculator);
            f.Show();

        }



        private void NeuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Neu
            i_schub.Text = "0";                                       //MLHIDE
            i_brenndr.Text = "0";                                     //MLHIDE
            i_aussendr.Text = "0";                                    //MLHIDE
            i_diabaten.Text = "0";                                    //MLHIDE
            i_char_laenge.Text = "0";                                 //MLHIDE
            i_T0.Text = "0";                                          //MLHIDE
            i_Molmasse.Text = "0";                                    //MLHIDE
            i_theta.Text = "0";                                       //MLHIDE

            o_mae.Text = "---";                                       //MLHIDE
            o_Ae .Text = "---";                                       //MLHIDE
            o_At.Text = "---";                                        //MLHIDE
            o_Dc.Text = "---";                                        //MLHIDE
            o_De.Text = "---";                                        //MLHIDE
            o_Dt.Text = "---";                                        //MLHIDE
            o_epsilon.Text = "---";                                   //MLHIDE
            o_gamma.Text = "---";                                     //MLHIDE
            o_Lc.Text = "---";                                        //MLHIDE
            o_isp.Text = "---";                                       //MLHIDE
            o_mdot.Text = "---";                                      //MLHIDE
            o_pt.Text = "---";                                        //MLHIDE
            o_Tt.Text = "---";                                        //MLHIDE
            o_Vc.Text = "---";                                        //MLHIDE


        }

        private void BeendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Beenden
            Application.Exit();
        }

        private void ÜberRECalcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Über
            Form_about f = new Form_about();
            f.Show();
        }

        private void SpeichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Displays a SaveFileDialog so the user can save  
            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                FileName = Resources.unknown_recp,
                Filter = "RE Calc Project|*.recp",                    //MLHIDE
                Title = Resources.Speichern_unter,
                //InitialDirectory = @"C:\",
                RestoreDirectory = true,
                DefaultExt = "recp"                                   //MLHIDE
            };

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Data _data = new Data
                {
                        F = Convert.ToDouble(i_schub.Text),
                        P0 = Convert.ToDouble(i_brenndr.Text),
                        Pa = Convert.ToDouble(i_aussendr.Text),
                        Kappa = Convert.ToDouble(i_diabaten.Text),
                        L_star = Convert.ToDouble(i_char_laenge.Text),
                        T0 = Convert.ToDouble(i_T0.Text),
                        Mm = Convert.ToDouble(i_Molmasse.Text),
                        Theta = Convert.ToDouble(i_theta.Text)
                };

                //open file stream
                using (StreamWriter file = File.CreateText(@saveFileDialog1.FileName))
                {
                    System.Diagnostics.Debug.WriteLine(Resources.Saving_File_to + saveFileDialog1.FileName); //MLHIDE

                    // serialize JSON directly to a file
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, _data);
                }
            }
        }

        private void ÖffnenToolStripMenuItem_Click(object sender, EventArgs e)
        {         
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "RE Calc Project|*.recp";     //MLHIDE
                openFileDialog.Title = Resources.Öffnen;
                //openFileDialog.InitialDirectory = @"C:\";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // read file into a string and deserialize JSON to a type
                    Data _open_data = JsonConvert.DeserializeObject<Data>(File.ReadAllText(@openFileDialog.FileName));
                        NeuToolStripMenuItem_Click(sender, e);
                        i_schub.Text = Convert.ToString(_open_data.F);
                        i_brenndr.Text = Convert.ToString(_open_data.P0);
                        i_aussendr.Text = Convert.ToString(_open_data.Pa);
                        i_diabaten.Text = Convert.ToString(_open_data.Kappa);
                        i_char_laenge.Text = Convert.ToString(_open_data.L_star);
                        i_T0.Text = Convert.ToString(_open_data.T0);
                        i_Molmasse.Text = Convert.ToString(_open_data.Mm);
                        i_theta.Text = Convert.ToString(_open_data.Theta);
                }
            }
            System.Diagnostics.Debug.WriteLine(Resources.Datei_öffnen);          //MLHIDE
        }
      protected virtual void ml_UpdateControls()
      {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager ( typeof ( Form_start ) );
        B_calc.Text = resources.GetString("B_calc.Text") ;
        beendenToolStripMenuItem.Text = resources.GetString("beendenToolStripMenuItem.Text") ;
        einstellungenToolStripMenuItem.Text = resources.GetString("einstellungenToolStripMenuItem.Text") ;
        gB_Zielwerte.Text = resources.GetString("gB_Zielwerte.Text") ;
        groupBox1.Text = resources.GetString("groupBox1.Text") ;
        hilfeAnzeigenToolStripMenuItem.Text = resources.GetString("hilfeAnzeigenToolStripMenuItem.Text") ;
        hilfeToolStripMenuItem.Text = resources.GetString("hilfeToolStripMenuItem.Text") ;
        label1.Text = resources.GetString("label1.Text") ;
        label11.Text = resources.GetString("label11.Text") ;
        label12.Text = resources.GetString("label12.Text") ;
        label13.Text = resources.GetString("label13.Text") ;
        label15.Text = resources.GetString("label15.Text") ;
        label19.Text = resources.GetString("label19.Text") ;
        label2.Text = resources.GetString("label2.Text") ;
        label21.Text = resources.GetString("label21.Text") ;
        label22.Text = resources.GetString("label22.Text") ;
        label23.Text = resources.GetString("label23.Text") ;
        label24.Text = resources.GetString("label24.Text") ;
        label25.Text = resources.GetString("label25.Text") ;
        label26.Text = resources.GetString("label26.Text") ;
        label31.Text = resources.GetString("label31.Text") ;
        label37.Text = resources.GetString("label37.Text") ;
        label38.Text = resources.GetString("label38.Text") ;
        label39.Text = resources.GetString("label39.Text") ;
        label40.Text = resources.GetString("label40.Text") ;
        label45.Text = resources.GetString("label45.Text") ;
        label5.Text = resources.GetString("label5.Text") ;
        label6.Text = resources.GetString("label6.Text") ;
        label7.Text = resources.GetString("label7.Text") ;
        menu_Menu.Text = resources.GetString("menu_Menu.Text") ;
        neuToolStripMenuItem.Text = resources.GetString("neuToolStripMenuItem.Text") ;
        öffnenToolStripMenuItem.Text = resources.GetString("öffnenToolStripMenuItem.Text") ;
        problemMeldenToolStripMenuItem.Text = resources.GetString("problemMeldenToolStripMenuItem.Text") ;
        speichernToolStripMenuItem.Text = resources.GetString("speichernToolStripMenuItem.Text") ;
        toolStripMenuItem1.Text = resources.GetString("toolStripMenuItem1.Text") ;
        toolStripMenuItem2.Text = resources.GetString("toolStripMenuItem2.Text") ;
        toolStripMenuItem3.Text = resources.GetString("toolStripMenuItem3.Text") ;
        überRECalcToolStripMenuItem.Text = resources.GetString("überRECalcToolStripMenuItem.Text") ;
        vorschlagMachenToolStripMenuItem.Text = resources.GetString("vorschlagMachenToolStripMenuItem.Text") ;
      }

      public void Form_Disposed ( object sender, System.EventArgs e )
      {
        
        MLRuntime.MLRuntime.LanguageChanged -= new MLRuntime.MLRuntime.LanguageChangedDelegate ( ml_UpdateControls ) ;
      }

        private void EinstellungenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_settings f = new Form_settings();
            f.Show();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void problemMeldenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/Tecur/rocket_engine_calc/issues/new?labels=bug&template=bug_report.md"; //MLHIDE
            try
            {
                OpenUrl(url);
            }
            catch (Exception)
            {
                MessageBox.Show(Resources.Unable_to_open_link_that_was_c0);
            }
        }

        private void vorschlagMachenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/Tecur/rocket_engine_calc/issues/new?labels=feature+request&template=feature_request.md"; //MLHIDE
            try
            {
                OpenUrl(url);
            }
            catch (Exception)
            {
                MessageBox.Show(Resources.Unable_to_open_link_that_was_c0);
            }
        }

        private void OpenUrl(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                // hack because of this: https://github.com/dotnet/corefx/issues/10361
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }
    }

    internal class Form_start
    {
    }
    
    public class Data
    {
        public double F { get; set; }
        public double P0 { get; set; }
        public double Pa { get; set; }
        public double Kappa { get; set; }
        public double L_star { get; set; }
        public double T0 { get; set; }
        public double Mm { get; set; }
        public double Theta { get; set; }
    }
}
