using System;

namespace ReflectionConsoleApp.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class ConfigurationItemAttribute : Attribute
    {
        private readonly string settingName;
        private readonly Providers.ProviderType providerType;

        public ConfigurationItemAttribute(string settingName, Providers.ProviderType providerType)
        {
            this.settingName = settingName;
            this.providerType = providerType;
        }

        public string SettingName => this.settingName;
        public Providers.ProviderType ProviderType => this.providerType;
    }
}
