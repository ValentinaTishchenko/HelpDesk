using System;
using System.Windows.Forms;
using HelpDesk.Common;
using HelpDesk.Common.Application;
using HelpDesk.Common.System;

namespace HelpDeskWinFormsApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var controller = new ApplicationDIController();
            controller.Start();

            var userProvider = SystemManager.Get<IUserProvider>();
            var ticketProvider = SystemManager.Get<ITroubleTicketProvider>();

            Application.Run(new MainForm(controller, userProvider, ticketProvider));
        }
    }
}