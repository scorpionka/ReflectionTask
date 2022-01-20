using System;

namespace ReflectionConsoleApp.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public class ConfigurationItemAttribute : Attribute
    {
        private readonly string settingName;
        private readonly Providers.Providers.ProviderType providerType;

        public ConfigurationItemAttribute(string settingName, Providers.Providers.ProviderType providerType)
        {
            this.settingName = settingName;
            this.providerType = providerType;
        }

        public string SettingName => this.settingName;
        public Providers.Providers.ProviderType ProviderType => this.providerType;
    }
}
