using ReflectionConsoleApp.Attributes;
using ReflectionConsoleApp.Providers;
using ReflectionConsoleApp.Providers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionConsoleApp.Configurations
{
    public class ConfigurationComponentBase<T>
    {
        private readonly IConfigurationProviderCreator configurationProvider;

        public ConfigurationComponentBase(IConfigurationProviderCreator configurationProvider)
        {
            this.configurationProvider = configurationProvider;
        }

        [ConfigurationItem("Value", Providers.ProviderType.File)]
        public virtual T Value { get; set; }

        public void LoadSettings()
        {
            var valueInfo = GetProperty(nameof(this.Value));

            this.configurationProvider.LoadSettings(valueInfo.Value.Item1, valueInfo.Value.Item2);
        }

        public void SaveSettings()
        {
            var valueInfo = GetProperty(nameof(this.Value));

            this.configurationProvider.SaveSetting(valueInfo.Value.Item1, valueInfo.Value.Item2);
        }

        public static (string, Providers.ProviderType)? GetProperty(string propertyName)
        {
            PropertyInfo propertyInfo = typeof(ConfigurationComponentBase<T>).GetProperty(propertyName);
            ConfigurationItemAttribute configurationItemAttribute = (ConfigurationItemAttribute)Attribute.GetCustomAttribute(propertyInfo, typeof(ConfigurationItemAttribute));

            if (configurationItemAttribute != null)
            {
                return (configurationItemAttribute.SettingName, configurationItemAttribute.ProviderType);
            }

            return null;
        }
    }
}
