using ReflectionConsoleApp.Providers.ConfigurationProviders;
using ReflectionConsoleApp.Providers.Interfaces;
using System;

namespace ReflectionConsoleApp.Providers
{
    public class FileConfigurationProvider : ConfigurationProvider
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
