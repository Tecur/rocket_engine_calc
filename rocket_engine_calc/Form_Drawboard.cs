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
    public partial class Form_Drawboard : System.Windows.Forms.Form
    {
        private Calculator _C;
        private int dig = 3;
        private Drawer objDraw;
        public Form_Drawboard(Calculator calculator)
        {
            InitializeComponent();
            this._C = calculator;
            this.objDraw = new Drawer(Color.Red, 1);
            this.Paint += new System.Windows.Forms.PaintEventHandler(Form_Drawboard_Paint);
        }

        private void Form_Drawboard_Paint(object sender, PaintEventArgs e)
        {
            objDraw.DrawChamberContour(e.Graphics, _C.Get_Dt(dig), _C.Get_Dc(dig), _C.Get_De(dig), _C.Get_Lc(dig), _C.Get_Lc(dig) * 0.5); //Ln to change
        }
    }
}
