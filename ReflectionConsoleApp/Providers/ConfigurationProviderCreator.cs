using ReflectionConsoleApp.Attributes;
using ReflectionConsoleApp.Providers.ConfigurationProviders;
using ReflectionConsoleApp.Providers.Interfaces;
using System;
using System.Reflection;

namespace ReflectionConsoleApp.Providers
{
    public class ConfigurationProviderCreator : IConfigurationProviderCreator
    {
        public object LoadSettings(PropertyInfo propertyInfo, ConfigurationItemAttribute configurationItemAttribute)
        {
            CustomConfigurationProvider provider = CreateConfigurationProvider(configurationItemAttribute.ProviderType);
            return provider.LoadSettings(propertyInfo);
        }

        public void SaveSettings(PropertyInfo propertyInfo, object propertyInfoValue, ConfigurationItemAttribute configurationItemAttribute)
        {
            CustomConfigurationProvider provider = CreateConfigurationProvider(configurationItemAttribute.ProviderType);
            provider.SaveSettings(propertyInfo, propertyInfoValue);
        }

        private CustomConfigurationProvider CreateConfigurationProvider(ProviderType providerType) => providerType switch
        {
            ProviderType.File => new FileConfigurationProvider(),
            ProviderType.ConfigurationManager => new ConfigurationManagerConfigurationProvider(),
            _ => throw new NotImplementedException(),
        };
    }
}
