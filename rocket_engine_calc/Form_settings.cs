using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rocket_engine_calc
{
    public partial class Form_settings : System.Windows.Forms.Form
    {
        public Form_settings()
        {
            InitializeComponent();
           
          MLRuntime.MLRuntime.LanguageChanged += new MLRuntime.MLRuntime.LanguageChangedDelegate ( ml_UpdateControls ) ;
          this.Disposed += new System.EventHandler ( this.Form_settings_Disposed );
        }


        private void Button1_Click(object sender, EventArgs e)
        {

        }

      protected virtual void ml_UpdateControls()
      {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager ( typeof ( Form_settings ) );
        this.Text = resources.GetString("$this.Text") ;
      }

      public void Form_settings_Disposed ( object sender, System.EventArgs e )
      {
        MLRuntime.MLRuntime.LanguageChanged -= new MLRuntime.MLRuntime.LanguageChangedDelegate ( ml_UpdateControls ) ;
      }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
