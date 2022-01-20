using System.Reflection;

namespace ReflectionConsoleApp.Providers.ConfigurationProviders
{
    public class CustomConfigurationProvider
    {
        public virtual object LoadSettings(PropertyInfo propertyInfo)
        {
            throw new System.NotImplementedException();
        }

        public virtual void SaveSettings(PropertyInfo propertyInfo, object propertyInfoValue)
        {
            throw new System.NotImplementedException();
        }
    }
}
