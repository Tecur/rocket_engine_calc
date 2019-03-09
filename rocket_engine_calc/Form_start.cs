using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            double Isp = Convert.ToDouble(i_isp.Text);
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
            l_ergebnis.Text = "";
            l_ergebnis.Text += "Ma_e = " + Convert.ToString(Ma_e) + " [-]" + Environment.NewLine;
            System.Diagnostics.Debug.WriteLine("Ma_e = " + Convert.ToString(Ma_e) + " [-]");
            l_ergebnis.Text += "ε = " + Convert.ToString(epsilon) + " [-]" + Environment.NewLine;
            System.Diagnostics.Debug.WriteLine("ε = " + Convert.ToString(epsilon) + " [-]");
            l_ergebnis.Text += "Γ = " + Convert.ToString(Gamma) + " [-]" + Environment.NewLine;
            System.Diagnostics.Debug.WriteLine("Γ = " + Convert.ToString(Gamma) + " [-]");
            l_ergebnis.Text += "m. = " + Convert.ToString(massflow) + " [kg/s]" + Environment.NewLine;
            System.Diagnostics.Debug.WriteLine("m. = " + Convert.ToString(massflow) + " [kg/s]");
            l_ergebnis.Text += "pt = " + Convert.ToString(pt) + " [Pa]" + Environment.NewLine;
            System.Diagnostics.Debug.WriteLine("pt = " + Convert.ToString(pt) + " [Pa]");
            l_ergebnis.Text += "Tt = " + Convert.ToString(Tt) + " [K]" + Environment.NewLine;
            System.Diagnostics.Debug.WriteLine("Tt = " + Convert.ToString(Tt) + " [K]");
            l_ergebnis.Text += "At = " + Convert.ToString((At*10000)) + " [cm²]" + Environment.NewLine;
            System.Diagnostics.Debug.WriteLine("At = " + Convert.ToString((At*10000)) + " [cm²]");
            l_ergebnis.Text += "Ae = " + Convert.ToString((Ae*10000)) + " [cm²]" + Environment.NewLine;
            System.Diagnostics.Debug.WriteLine("Ae = " + Convert.ToString((Ae*10000)) + " [cm²]");
            l_ergebnis.Text += "Dt = " + Convert.ToString(Dt) + " [cm]" + Environment.NewLine;
            System.Diagnostics.Debug.WriteLine("Dt = " + Convert.ToString(Dt) + " [cm]");
            l_ergebnis.Text += "De = " + Convert.ToString(De) + " [cm]" + Environment.NewLine;
            System.Diagnostics.Debug.WriteLine("De = " + Convert.ToString(De) + " [cm]");
            l_ergebnis.Text += "Dc = " + Convert.ToString(Dc) + " [cm]" + Environment.NewLine;
            System.Diagnostics.Debug.WriteLine("Dc = " + Convert.ToString(Dc) + " [cm]");
            l_ergebnis.Text += "Vc = " + Convert.ToString(Vc) + " [cm³]" + Environment.NewLine;
            System.Diagnostics.Debug.WriteLine("Vc = " + Convert.ToString(Vc) + " [cm³]");
            l_ergebnis.Text += "Lc = " + Convert.ToString(Lc) + " [cm]" + Environment.NewLine;
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
            i_isp.Text = "0";
            i_T0.Text = "0";
            i_Molmasse.Text = "0";
            i_theta.Text = "0";

            l_ergebnis.Text = "-Berechnen drücken-";
        }

        private void BeendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Beenden
            Application.Exit();
        }

        private void überRECalcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Über
            Form_about f = new Form_about();
            f.Show();
        }
    }
}
