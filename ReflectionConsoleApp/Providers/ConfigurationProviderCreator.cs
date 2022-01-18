using ReflectionConsoleApp.Providers.ConfigurationProviders;
using ReflectionConsoleApp.Providers.Interfaces;
using System;

namespace ReflectionConsoleApp.Providers
{
    public class ConfigurationProviderCreator : IConfigurationProviderCreator
    {
        public ConfigurationProviderCreator()
        {
        }

        public void LoadSettings(string settingName, ProviderType providerType)
        {
            ConfigurationProvider provider = CreateConfigurationProvider(providerType);
            provider.LoadSettings(settingName, providerType);
        }

        public void SaveSetting(string settingName, ProviderType providerType)
        {
            ConfigurationProvider provider = CreateConfigurationProvider(providerType);
        }

        private ConfigurationProvider CreateConfigurationProvider(ProviderType providerType) => providerType switch
        {
            ProviderType.File => new FileConfigurationProvider(),
            ProviderType.ConfigurationManager => new ConfigurationManagerConfigurationProvider(),
            _ => throw new NotImplementedException(),
        };
    }
}
