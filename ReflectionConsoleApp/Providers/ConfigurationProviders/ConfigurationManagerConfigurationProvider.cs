using ReflectionConsoleApp.Providers.ConfigurationProviders;
using System;

namespace ReflectionConsoleApp.Providers
{
    public class ConfigurationManagerConfigurationProvider : ConfigurationProvider
    {
        public override void LoadSettings(string settingName, ProviderType providerType)
        {
            Console.WriteLine(settingName);
            Console.WriteLine(providerType);
        }

        public override void SaveSetting(string settingName, ProviderType providerType)
        {
            Console.WriteLine(settingName);
            Console.WriteLine(providerType);
        }
    }
}
