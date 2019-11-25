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
        public Form_Drawboard(Calculator calculator)
        {
            InitializeComponent();
            this._C = calculator;
        }

        private void Form_Drawboard_Load(object sender, EventArgs e)
        {
            Drawer objDraw = new Drawer(Color.Red, 2,this);
            objDraw.DrawChamberContour(_C.Get_Dt(dig),_C.Get_Dc(dig),_C.Get_De(dig),_C.Get_Lc(dig),_C.Get_Lc(dig)*0.5); //Ln to change
        }
    }
}
