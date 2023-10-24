using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vehicle_Info.controllers;
using Vehicle_Info.models;

namespace Vehicle_Info
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

            //new instance
            HomeView homeView = new HomeView();
            HomeModel homeModel = new HomeModel();

            HomeController controller = new HomeController(homeModel, homeView);
            Application.Run(homeView);
        }
    }
}
