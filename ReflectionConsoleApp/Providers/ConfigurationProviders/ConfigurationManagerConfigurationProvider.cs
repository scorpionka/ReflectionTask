using ReflectionConsoleApp.Providers.ConfigurationProviders;
using System;

namespace ReflectionConsoleApp.Providers
{
    public class ConfigurationManagerConfigurationProvider<T> : ConfigurationProvider<T>
    {
        public override T LoadSettings(string settingName, ProviderType providerType)
        {
            Console.WriteLine(settingName);
            Console.WriteLine(providerType);
            return default(T);
        }

        public override void SaveSettings(string settingName, ProviderType providerType, T value)
        {
            Console.WriteLine(settingName);
            Console.WriteLine(providerType);
        }
    }
}
