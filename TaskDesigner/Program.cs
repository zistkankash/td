﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Basics
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new COGLABnewUI());
			//try
			//{
			//	Application.Run(new COGLABnewUI());
			//}
			//catch(Exception)
			//{
			//	MessageBox.Show("System Error!");
			//}
        }
    }
}
