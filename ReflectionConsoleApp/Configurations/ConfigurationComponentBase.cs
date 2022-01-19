using ReflectionConsoleApp.Attributes;
using ReflectionConsoleApp.Providers.Interfaces;
using System;
using System.Reflection;

namespace ReflectionConsoleApp.Configurations
{
    public class ConfigurationComponentBase<T>
    {
        private readonly IConfigurationProviderCreator<T> configurationProvider;

        public ConfigurationComponentBase(IConfigurationProviderCreator<T> configurationProvider)
        {
            this.configurationProvider = configurationProvider;
        }

        public T LoadSettings(string propertyName)
        {
            var valueInfo = GetProperty(propertyName);

            return this.configurationProvider.LoadSettings(valueInfo.Value.Item1, valueInfo.Value.Item2);
        }

        public void SaveSettings(string propertyName, T value)
        {
            var valueInfo = GetProperty(propertyName);

            this.configurationProvider.SaveSettings(valueInfo.Value.Item1, valueInfo.Value.Item2, value);
        }

        private static (string, Providers.ProviderType)? GetProperty(string propertyName)
        {
            PropertyInfo propertyInfo = typeof(Configuration).GetProperty(propertyName);
            ConfigurationItemAttribute configurationItemAttribute = (ConfigurationItemAttribute)Attribute.GetCustomAttribute(propertyInfo, typeof(ConfigurationItemAttribute));

            if (configurationItemAttribute != null)
            {
                return (configurationItemAttribute.SettingName, configurationItemAttribute.ProviderType);
            }

            return null;
        }
    }
}
