using Common.Database.DataAccess;
using Common.Database.DataAccess.Implementation;
using Common.Services;
using Common.Services.Implementation;
using SimpleInjector;

namespace Common
{
    public class CommonLibrary
    {
        public static void RegisterDependencyInjection(Container container)
        {
            container.Register<IPatientService, PatientService>(Lifestyle.Singleton);
            container.Register<IYourHelthDataAccess, YourHelthContext>(Lifestyle.Singleton);
            container.Register<IConquestService, ConquestService>(Lifestyle.Singleton);
            container.Register<IQuestsService, QuestsService>(Lifestyle.Singleton);
        }
    }
}