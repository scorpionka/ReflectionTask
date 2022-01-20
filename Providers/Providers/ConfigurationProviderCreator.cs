using ReflectionConsoleApp.Providers.ConfigurationProviders;
using ReflectionConsoleApp.Providers.Interfaces;
using System;
using System.Reflection;

namespace ReflectionConsoleApp.Providers
{
    public class ConfigurationProviderCreator : IConfigurationProviderCreator
    {
        public object LoadSettings(PropertyInfo propertyInfo, ProviderType providerType)
        {
            CustomConfigurationProvider provider = CreateConfigurationProvider(providerType);
            return provider.LoadSettings(propertyInfo);
        }

        public void SaveSettings(PropertyInfo propertyInfo, object propertyInfoValue, ProviderType providerType)
        {
            CustomConfigurationProvider provider = CreateConfigurationProvider(providerType);
            provider.SaveSettings(propertyInfo, propertyInfoValue);
        }

        private static CustomConfigurationProvider CreateConfigurationProvider(ProviderType providerType) => providerType switch
        {
            ProviderType.File => new FileConfigurationProvider(),
            ProviderType.ConfigurationManager => new ConfigurationManagerConfigurationProvider(),
            _ => throw new NotImplementedException(),
        };
    }
}
