using ReflectionConsoleApp.Attributes;
using ReflectionConsoleApp.Providers.Interfaces;
using System;
using System.Reflection;

namespace ReflectionConsoleApp.Configurations
{
    public class ConfigurationComponentBase
    {
        private readonly IConfigurationProviderCreator configurationProvider;

        public ConfigurationComponentBase(IConfigurationProviderCreator configurationProvider)
        {
            this.configurationProvider = configurationProvider;
        }

        public void LoadSettings(ConfigurationSettings configurationSettings)
        {
            foreach (var propertyInfo in GetConfigurationSettingsPropertiesInfo())
            {
                ConfigurationItemAttribute configurationItemAttribute = (ConfigurationItemAttribute)Attribute.GetCustomAttribute(propertyInfo, typeof(ConfigurationItemAttribute));

                if (configurationItemAttribute != null)
                {
                    propertyInfo.SetValue(configurationSettings, this.configurationProvider.LoadSettings(propertyInfo, configurationItemAttribute.ProviderType));
                }
            }
        }

        public void SaveSettings(ConfigurationSettings configurationSettings)
        {
            foreach (var propertyInfo in GetConfigurationSettingsPropertiesInfo())
            {
                ConfigurationItemAttribute configurationItemAttribute = (ConfigurationItemAttribute)Attribute.GetCustomAttribute(propertyInfo, typeof(ConfigurationItemAttribute));

                if (configurationItemAttribute != null)
                {
                    this.configurationProvider.SaveSettings(propertyInfo, propertyInfo.GetValue(configurationSettings), configurationItemAttribute.ProviderType);
                }
            }
        }

        private static PropertyInfo[] GetConfigurationSettingsPropertiesInfo()
        {
            PropertyInfo[] propertiesInfo = typeof(ConfigurationSettings).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            if (propertiesInfo is null)
            {
                throw new ArgumentNullException(nameof(propertiesInfo));
            }

            return propertiesInfo;
        }
    }
}
