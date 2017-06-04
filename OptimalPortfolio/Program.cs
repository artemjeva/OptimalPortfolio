using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OptimalPortfolio
{
    static class Program
    {
        public static Form1 form;
        public static string path;
       // public static Form3_graph form3;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            path = Application.StartupPath + "\\assets\\";
            System.IO.Directory.CreateDirectory(path);
            System.IO.Directory.CreateDirectory(path + "vol\\");
            System.IO.Directory.CreateDirectory(path + "cor\\");
            System.IO.Directory.CreateDirectory(path + "liq\\");
            System.IO.Directory.CreateDirectory(path + "test\\");

            form = new Form1();
            
            try
            {
                Application.Run(form);
            }
            catch(Exception ex) { 
                MessageBox.Show(ex.Message + "\n" + ex.InnerException, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Restart();
            }
           
        }
    }
}
