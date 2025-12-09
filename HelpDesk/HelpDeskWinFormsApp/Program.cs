using System;
using System.IO;
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

           CheckAndEncryptOldFiles();

            var controller = new ApplicationDIController();
            controller.Start();          

            var userProvider = SystemManager.Get<IUserProvider>();
            var ticketProvider = SystemManager.Get<ITroubleTicketProvider>();

            Application.Run(new MainForm(controller, userProvider, ticketProvider));
        }
        static void CheckAndEncryptOldFiles()
        {
            string[] files = { "users.json", "troubleTicket.json" };

            foreach (var file in files)
            {
                if (File.Exists(file))
                {
                    try
                    {
                        string content = File.ReadAllText(file);
                        
                        if (content.Trim().StartsWith("[") || content.Trim().StartsWith("{"))
                        {                           
                            File.Copy(file, file + ".backup", true);
                            
                            FileProvider.Put(file, content);
                        }
                    }
                    catch
                    {
                        
                    }
                }
            }
        }
    }
}