using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rocket_engine_calc
{
    public class Calculator
    {
        private double F, p0, pa, kappa, l_star, T0, Mm, theta, pe, Ma_e, epsilon, Gamma, Isp, massflow, pt, Tt, At, Ae, Dt, De, Vc, Lc, Dc;
        public readonly double R_star = 8314.462618;
        public readonly double grav = 9.807232;

        //Konstruktor
        public Calculator(double _F, double _p0, double _pa, double _kappa, double _l_star, double _T0, double _Mm, double _theta)
        {
            this.F = _F;
            this.p0 = _p0;
            this.pa = _pa;
            this.kappa = _kappa;
            this.l_star = _l_star;
            this.T0 = _T0;
            this.Mm = _Mm;
            this.theta = _theta;

            this.pe = this.pa; //angepasste Düse
        }

        //Methoden

        //Berechnungen
        public void Calculate()
        {
            this.Ma_e = Calc_Ma_e(this.p0, this.pa, this.kappa);
            this.epsilon = Calc_epsilon(this.pe, this.p0, this.kappa, this.Ma_e);
            this.Gamma = Calc_Gamma(this.kappa);
            this.Isp = Calc_Isp(this.kappa, this.Mm, this.T0, this.pe, this.p0);
            this.massflow = Calc_massflow(this.F, this.Isp);
            this.pt = Calc_pt(this.p0, this.kappa);
            this.Tt = Calc_Tt(this.kappa, this.T0);
            this.At = Calc_At(this.kappa, this.Mm, this.massflow, this.pt, this.Tt);
            this.Ae = Calc_Ae(this.kappa, this.Ma_e, this.At);
            this.Dt = Calc_Dt(this.At);
            this.De = Calc_De(this.Ae);
            this.Vc = Calc_Vc(this.At, this.l_star);
            this.Lc = Calc_Lc(this.Dt);
            this.Dc = Calc_Dc(this.Dt, this.theta, this.Vc, this.Lc, 10);
        }
        
        private double Calc_Ae(double _kappa, double _Ma_e, double _At)
        {
            return _At / _Ma_e * Math.Pow((1 + ((_kappa - 1) / 2 * Math.Pow(_Ma_e, 2))) / ((_kappa + 1) / 2), (_kappa + 1) / (2 * (_kappa - 1)));  //in m^2
        }
        private double Calc_At(double _kappa, double _Mm, double _massflow, double _pt, double _Tt)
        {
            return (_massflow / _pt) * Math.Sqrt((this.R_star * _Tt) / (_Mm * _kappa));   //in m^2
        }
        private double Calc_Tt(double _kappa, double _T0)
        {
            return _T0 / (1 + ((_kappa - 1) / 2));
        }
        private double Calc_pt(double _p0, double _kappa)
        {
            return _p0 * Math.Pow(1 + ((_kappa - 1) / 2), -_kappa / (_kappa - 1));
        }
        private double Calc_Isp(double _kappa, double _Mm, double _T0, double _pe, double _p0)
        {
            return 1 / this.grav * Math.Sqrt(2 * _kappa / (_kappa - 1)) * Math.Sqrt(this.R_star / _Mm * _T0) * Math.Sqrt(1 - Math.Pow(_pe / _p0, (_kappa - 1) / _kappa));
        }
        private double Calc_massflow(double _F, double _Isp)
        {
            return _F / (_Isp * this.grav);
        }
        private double Calc_Gamma(double _kappa)
        {
            return Math.Sqrt(_kappa * Math.Pow(2 / (_kappa + 1), (_kappa + 1) / (_kappa - 1)));
        }
        private double Calc_epsilon(double _pe, double _p0, double _kappa, double _Ma_e)
        {
            return (1 / _Ma_e) * Math.Pow((2 / (_kappa + 1)) * (1 + ((_kappa - 1) / 2) * Math.Pow(_Ma_e, 2)), (_kappa + 1) / (2 * (_kappa - 1)));
        }
        private double Calc_Ma_e(double _p0, double _pa, double _kappa)
        {
            return Math.Sqrt(2 / (_kappa - 1) * (Math.Pow(_p0 / _pa, (_kappa - 1) / _kappa) - 1));
        }
        private double Calc_Dt(double _At)
        {
            return 2 * Math.Sqrt(_At * 10000 / Math.PI);    //in cm
        }
        private double Calc_De(double _Ae)
        {
            return 2 * Math.Sqrt(_Ae * 10000 / Math.PI);    //in cm
        }
        private double Calc_Vc(double _At, double _l_star)
        {
            return _At * 10000 * _l_star;    //in cm^3
        }
        private double Calc_Lc(double _Dt)
        {
            //Näherung zweiter Ordnung (mit Vorsicht zu betrachten, lieber eigene Erfahrungswerte nutzen)
            return Math.Exp(0.029 * Math.Pow(Math.Log(_Dt), 2) + 0.47 * Math.Log(_Dt) + 1.94);   //in cm
        }
        private double Calc_Dc(double _Dt, double _theta, double _Vc, double _Lc, int iterations)
        {
            //Finden durch Iteration
            double __dc = 0;
            for (int i = 0; i < iterations; i++)
            {
                __dc = Math.Sqrt((Math.Pow(_Dt, 3) + (24 / Math.PI) * Math.Tan(((Math.PI / 180) * _theta)) * _Vc) / (__dc + 6 * Math.Tan(((Math.PI / 180) * _theta)) * _Lc));
            }
            return __dc; //in cm
        }

        //Getter
        public double Get_Ma_e(int digits)
        {
            return Math.Round(this.Ma_e, digits);
        }
        public double Get_epsilon(int digits)
        {
            return Math.Round(this.epsilon, digits);
        }
        public double Get_Gamma(int digits)
        {
            return Math.Round(this.Gamma, digits);
        }
        public double Get_Isp(int digits)
        {
            return Math.Round(this.Isp, digits);
        }
        public double Get_massflow(int digits)
        {
            return Math.Round(this.massflow, digits);
        }
        public double Get_pt(int digits)
        {
            return Math.Round(this.pt, digits);
        }
        public double Get_Tt(int digits)
        {
            return Math.Round(this.Tt, digits);
        }
        public double Get_At(int digits)
        {
            return Math.Round(this.At, digits);
        }
        public double Get_Ae(int digits)
        {
            return Math.Round(this.Ae, digits);
        }
        public double Get_Dt(int digits)
        {
            return Math.Round(this.Dt, digits);
        }
        public double Get_De(int digits)
        {
            return Math.Round(this.De, digits);
        }
        public double Get_Vc(int digits)
        {
            return Math.Round(this.Vc, digits);
        }
        public double Get_Lc(int digits)
        {
            return Math.Round(this.Lc, digits);
        }
        public double Get_Dc(int digits)
        {
            return Math.Round(this.Dc, digits);
        }
    }
}
