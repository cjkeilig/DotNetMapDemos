using MapsPlayground.Data.Repositories;
using MapsPlayground.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace GMapWinForm
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

            var container = BuildContainer();

            Application.Run(new Form1(container.Resolve<ObjectToPlotSampleRepository>()));
        }

        private static IUnityContainer BuildContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IObjectToPlotRepository, ObjectToPlotSampleRepository>();

            return container;
        }
    }
}
