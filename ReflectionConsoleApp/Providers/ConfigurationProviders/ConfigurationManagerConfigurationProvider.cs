using ReflectionConsoleApp.Providers.ConfigurationProviders;
using System;
using System.Reflection;

namespace ReflectionConsoleApp.Providers
{
    public class ConfigurationManagerConfigurationProvider : CustomConfigurationProvider
    {
        public override object LoadSettings(PropertyInfo propertyInfo)
        {
            return null;
        }

        public override void SaveSettings(PropertyInfo propertyInfo, object propertyInfoValue)
        {
        }
    }
}
