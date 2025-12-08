using HelpDesk.Common.System;

namespace HelpDesk.Common.Application
{
    public class ApplicationDIController
    {
        public void Start()
        {            
            RegisterSystems();                       
        }

        private void RegisterSystems()
        {          
            SystemManager.Register(this);
            var jsonStorage = new JsonStorage();

            SystemManager.Register<IUserProvider>(jsonStorage);
            SystemManager.Register<ITroubleTicketProvider>(jsonStorage);
        }
    }
}
