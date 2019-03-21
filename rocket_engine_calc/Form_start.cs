﻿using Newtonsoft.Json;
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

namespace rocket_engine_calc
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }

        private void B_calc_Click(object sender, EventArgs e)
        {
            //Einlesen der Start-/Zielwerte
            double F = Convert.ToDouble(i_schub.Text);
            double p0 = Convert.ToDouble(i_brenndr.Text);
            double pa = Convert.ToDouble(i_aussendr.Text);
            double kappa = Convert.ToDouble(i_diabaten.Text);
            double l_star = Convert.ToDouble(i_char_laenge.Text);
            //double Isp = Convert.ToDouble(i_isp.Text);
            double T0 = Convert.ToDouble(i_T0.Text);
            double Mm = Convert.ToDouble(i_Molmasse.Text);
            double theta = Convert.ToDouble(i_theta.Text);
            double R_star = 8314.4598;
            double pe = pa; //angepasste Düse
            double g = 9.81;
            //Mae
            double Ma_e = Get_Ma_e(p0, pa, kappa);
            //Epsilon Ae/At
            double epsilon = Get_epsilon(pe, p0, kappa, Ma_e);
            //Gamma
            double Gamma = Get_Gamma(kappa);
            //Spez. Impuls
            double Isp = Get_Isp(g, kappa, R_star, Mm, T0, pe, p0);
            //Mass flow rate
            double massflow = Get_massflow(F, Isp, g);
            //pt
            double pt = Get_pt(p0, kappa);
            //Tt
            double Tt = Get_Tt(kappa, T0);
            //At (in m^2)
            double At = Get_At(kappa, Mm, R_star, massflow, pt, Tt);
            //Ae (in m^2)
            double Ae = Get_Ae(kappa, Ma_e, At);
            //Dt (in cm)
            double Dt = 2 * Math.Sqrt(At*10000 / Math.PI);
            //De (in cm)
            double De = 2 * Math.Sqrt(Ae*10000 / Math.PI);
            //Vc (in cm^3)
            double Vc = At * 10000 * l_star;
            //Lc (in cm)
            //Näherung zweiter Ordnung (mit Vorsicht zu betrachten, lieber eigene Erfahrungswerte nutzen)
            double Lc = Math.Exp(0.029*Math.Pow(Math.Log(Dt),2) +0.47*Math.Log(Dt) +1.94);
            //Dc (in cm)
            //Finden durch Iteration
            double Dc = 0;
            for(int i = 0; i < 4; i++) {
                Dc = Math.Sqrt((Math.Pow(Dt, 3) + (24 / Math.PI) * Math.Tan(((Math.PI / 180) * theta)) * Vc) / (Dc + 6 * Math.Tan(((Math.PI / 180) * theta)) * Lc));
            }
            //Ergebnisse anzeigen
            o_mae.Text = Convert.ToString(Ma_e);
            System.Diagnostics.Debug.WriteLine("Ma_e = " + Convert.ToString(Ma_e) + " [-]");
            o_epsilon.Text = Convert.ToString(epsilon);
            System.Diagnostics.Debug.WriteLine("ε = " + Convert.ToString(epsilon) + " [-]");
            o_gamma.Text = Convert.ToString(Gamma);
            System.Diagnostics.Debug.WriteLine("Γ = " + Convert.ToString(Gamma) + " [-]");
            o_isp.Text = Convert.ToString(Isp);
            System.Diagnostics.Debug.WriteLine("Isp = " + Convert.ToString(Isp) + " [s]");
            o_mdot.Text = Convert.ToString(massflow);
            System.Diagnostics.Debug.WriteLine("m. = " + Convert.ToString(massflow) + " [kg/s]");
            o_pt.Text = Convert.ToString(pt);
            System.Diagnostics.Debug.WriteLine("pt = " + Convert.ToString(pt) + " [Pa]");
            o_Tt.Text = Convert.ToString(Tt);
            System.Diagnostics.Debug.WriteLine("Tt = " + Convert.ToString(Tt) + " [K]");
            o_At.Text = Convert.ToString((At*10000));
            System.Diagnostics.Debug.WriteLine("At = " + Convert.ToString((At*10000)) + " [cm²]");
            o_Ae.Text = Convert.ToString((Ae*10000));
            System.Diagnostics.Debug.WriteLine("Ae = " + Convert.ToString((Ae*10000)) + " [cm²]");
            o_Dt.Text = Convert.ToString(Dt);
            System.Diagnostics.Debug.WriteLine("Dt = " + Convert.ToString(Dt) + " [cm]");
            o_De.Text = Convert.ToString(De);
            System.Diagnostics.Debug.WriteLine("De = " + Convert.ToString(De) + " [cm]");
            o_Dc.Text = Convert.ToString(Dc);
            System.Diagnostics.Debug.WriteLine("Dc = " + Convert.ToString(Dc) + " [cm]");
            o_Vc.Text = Convert.ToString(Vc);
            System.Diagnostics.Debug.WriteLine("Vc = " + Convert.ToString(Vc) + " [cm³]");
            o_Lc.Text = Convert.ToString(Lc);
            System.Diagnostics.Debug.WriteLine("Lc = " + Convert.ToString(Lc) + " [cm]");
        }

        private static double Get_Ae(double kappa, double Ma_e, double At)
        {
            return At / Ma_e * Math.Pow((1 + ((kappa - 1) / 2 * Math.Pow(Ma_e, 2))) / ((kappa + 1) / 2), (kappa + 1) / (2 * (kappa - 1)));
        }

        private static double Get_At(double kappa, double Mm, double R_star, double massflow, double pt, double Tt)
        {
            return (massflow / pt) * Math.Sqrt((R_star * Tt) / (Mm * kappa));
        }

        private static double Get_Tt(double kappa, double T0)
        {
            return T0 / (1 + ((kappa - 1) / 2));
        }

        private static double Get_pt(double p0, double kappa)
        {
            return p0 * Math.Pow(1 + ((kappa - 1) / 2), -kappa / (kappa - 1));
        }

        private static double Get_Isp(double g, double kappa, double R_star, double Mm, double T0, double pe, double p0)
        {
            return 1 / g * Math.Sqrt(2 * kappa / (kappa - 1)) * Math.Sqrt(R_star / Mm * T0) * Math.Sqrt(1 - Math.Pow(pe / p0, (kappa - 1) / kappa));
        }

        private static double Get_massflow(double F, double Isp, double g)
        {
            return F / (Isp * g);
        }

        private static double Get_Gamma(double kappa)
        {
            return Math.Sqrt(kappa * Math.Pow(2 / (kappa + 1), (kappa + 1) / (kappa - 1)));
        }

        private static double Get_epsilon(double pe, double p0, double kappa, double Ma_e)
        {
            return (1/Ma_e)*Math.Pow((2/(kappa+1))*(1+((kappa-1)/2)*Math.Pow(Ma_e,2)),(kappa+1)/(2*(kappa-1)));
        }

        private static double Get_Ma_e(double p0, double pa, double kappa)
        {
            return Math.Sqrt(2 / (kappa - 1) * (Math.Pow(p0 / pa, (kappa - 1) / kappa) - 1));
        }

        private void NeuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Neu
            i_schub.Text = "0";
            i_brenndr.Text = "0";
            i_aussendr.Text = "0";
            i_diabaten.Text = "0";
            i_char_laenge.Text = "0";
            i_T0.Text = "0";
            i_Molmasse.Text = "0";
            i_theta.Text = "0";

            o_mae.Text = "---";
            o_Ae .Text = "---";
            o_At.Text = "---";
            o_Dc.Text = "---";
            o_De.Text = "---";
            o_Dt.Text = "---";
            o_epsilon.Text = "---";
            o_gamma.Text = "---";
            o_Lc.Text = "---";
            o_isp.Text = "---";
            o_mdot.Text = "---";
            o_pt.Text = "---";
            o_Tt.Text = "---";
            o_Vc.Text = "---";


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
                FileName = "unknown.recp",
                Filter = "RE Calc Project|*.recp",
                Title = "Speichern unter",
                //InitialDirectory = @"C:\",
                RestoreDirectory = true,
                DefaultExt = "recp"
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
                    System.Diagnostics.Debug.WriteLine("Saving File to: " + saveFileDialog1.FileName);

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
                openFileDialog.Filter = "RE Calc Project|*.recp";
                openFileDialog.Title = "Öffnen";
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
            System.Diagnostics.Debug.WriteLine("Open file");
        }
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