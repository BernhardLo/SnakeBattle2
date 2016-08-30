using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeBattle2
{
    static class Program
    {
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);


        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        static IntPtr h;

        public static void ShowConsole()
        {
            ShowWindow(h, 1);
        }

        public static void HideConsole()
        {
            ShowWindow(h, 0);
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Console.Title = "Snake Battle 2 Console";

            h = FindWindow(null, "Snake Battle 2 Console");
            ShowWindow(h, 0);


            //Form f = new Form();

            //f.ShowDialog();

            //ShowWindow(h, 1); // 1 = show


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SnakeBattle2());
        }
    }
}
