using Common.Database.DataAccess;
using Common.Database.DataAccess.Implementation;
using SimpleInjector;

namespace Common
{
    public class CommonLibrary
    {
        public static void RegisterDependencyInjection(Container container)
        {
            container.Register<IUserDataAccess, UserDataAccess>(Lifestyle.Singleton);
        }
    }
}