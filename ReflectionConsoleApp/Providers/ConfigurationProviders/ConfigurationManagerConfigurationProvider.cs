using ReflectionConsoleApp.Providers.ConfigurationProviders;
using ReflectionConsoleApp.Providers.Interfaces;
using System;

namespace ReflectionConsoleApp.Providers
{
    public class ConfigurationManagerConfigurationProvider : ConfigurationProvider
    {
        public override void LoadSettings(string settingName, ProviderType providerType)
        {
            Console.WriteLine(settingName + providerType);
        }

        public override void SaveSetting(string settingName, ProviderType providerType)
        {
            Console.WriteLine(settingName + providerType);
        }
    }
}
