using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TELTAS300Emulator
{
    static class Program
    {
        public static Emulation emulation;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            emulation = new Emulation();
            Task.Run(() => { emulation.Start(); });
            var mainForm = new Form1();
            mainForm.FormClosing += (x,y) => { emulation.Stop = true; };
            Application.Run(mainForm);
        }
    }
}
