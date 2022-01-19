using ReflectionConsoleApp.Providers.ConfigurationProviders;
using ReflectionConsoleApp.Providers.Interfaces;
using System;

namespace ReflectionConsoleApp.Providers
{
    public class ConfigurationProviderCreator<T> : IConfigurationProviderCreator<T>
    {
        public ConfigurationProviderCreator()
        {
        }

        public T LoadSettings(string settingName, ProviderType providerType)
        {
            ConfigurationProvider<T> provider = CreateConfigurationProvider(providerType);
            return provider.LoadSettings(settingName, providerType);
        }

        public void SaveSettings(string settingName, ProviderType providerType, T value)
        {
            ConfigurationProvider<T> provider = CreateConfigurationProvider(providerType);
            provider.SaveSettings(settingName, providerType, value);
        }

        private ConfigurationProvider<T> CreateConfigurationProvider(ProviderType providerType) => providerType switch
        {
            ProviderType.File => new FileConfigurationProvider<T>(),
            ProviderType.ConfigurationManager => new ConfigurationManagerConfigurationProvider<T>(),
            _ => throw new NotImplementedException(),
        };
    }
}
