using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rocket_engine_calc
{
    public class Drawer
    {
        //Attribute
        private Color _Contour_color = Color.Red;
        private float _Contour_width = 1;
        private int _Padding = 30;
        //Konstruktor
        public Drawer(Color contour_color,float contour_width)
        {
            this._Contour_color = contour_color;
            this._Contour_width = contour_width;
        }

        //Methoden
        private int Get_NozzlePart_x(int l_chamber, int x)
        {
            return _Padding + l_chamber + x;
        }

        private int Get_NozzlePart_y(int d_max, int y)
        {
            return _Padding + (d_max / 2) + y;
        }

        public void DrawChamberContour(Graphics g, double d_throat, double d_chamber, double d_exit, double l_chamber, double l_nozzle)
        {
            Pen contour = new Pen(this._Contour_color, this._Contour_width);
            //double middle_x = (l_chamber + l_nozzle) / 2;
            //double middle_y = Math.Max(d_chamber, d_exit) / 2;

            double d_max = Math.Max(d_chamber, d_exit);
            double r_chamber_throat = 1.5 * (d_throat / 2);
            double r_nozzle_throat = 0.382 * (d_throat / 2);
            int phi = 30;           //To Change
            int init_angle = 25;    //To Change
            
            //Arc Rectangles
            Rectangle rec_nozzle_throat = new Rectangle(Get_NozzlePart_x(Convert.ToInt32(l_chamber), Convert.ToInt32(-r_nozzle_throat)), Get_NozzlePart_y(Convert.ToInt32(d_max), Convert.ToInt32(-(d_throat / 2) - (2 * r_nozzle_throat))), Convert.ToInt32(2 * r_nozzle_throat), Convert.ToInt32(2 * r_nozzle_throat));
            Rectangle rec_chamber_throat = new Rectangle(Get_NozzlePart_x(Convert.ToInt32(l_chamber), Convert.ToInt32(-r_chamber_throat)),Get_NozzlePart_y(Convert.ToInt32(d_max),Convert.ToInt32(-(d_throat / 2) - (2 * r_chamber_throat))), Convert.ToInt32(2 * r_chamber_throat), Convert.ToInt32(2 * r_chamber_throat));

            //Draw Arc
            g.DrawArc(contour,rec_nozzle_throat,90,-init_angle);
            g.DrawArc(contour, rec_chamber_throat, 90, phi);
        }
    }
}
