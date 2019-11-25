using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rocket_engine_calc
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

      //Sprachauswahl-Formular anzeigen
      MultiLang.SelectLanguage frmLang = new MultiLang.SelectLanguage() ;
      frmLang.LoadSettingsAndShow() ;
      frmLang.Dispose() ;
      frmLang = null ;


            Form start_form = new Form();
            Application.Run(start_form);
        }
    }
}
