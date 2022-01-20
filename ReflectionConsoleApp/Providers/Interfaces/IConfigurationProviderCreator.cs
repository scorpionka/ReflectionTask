using ReflectionConsoleApp.Attributes;
using System.Reflection;

namespace ReflectionConsoleApp.Providers.Interfaces
{
    public interface IConfigurationProviderCreator
    {
        object LoadSettings(PropertyInfo propertyInfo, ConfigurationItemAttribute configurationItemAttribute);
        void SaveSettings(PropertyInfo propertyInfo, object propertyInfoValue, ConfigurationItemAttribute configurationItemAttribute);
    }
}
