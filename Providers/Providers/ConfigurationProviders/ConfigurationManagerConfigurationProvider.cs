using System;
using System.Configuration;
using System.Reflection;

namespace Providers.Providers.ConfigurationProviders
{
    public class ConfigurationManagerConfigurationProvider : CustomConfigurationProvider
    {
        private readonly Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        public override object LoadSettings(PropertyInfo propertyInfo)
        {
            Type propertyType = propertyInfo.PropertyType;
            var property = configuration.AppSettings.Settings[$"{propertyInfo.Name}"];

            if (property is null)
            {
                return null;
            }

            return Cast(property.Value, propertyType);
        }

        public override void SaveSettings(PropertyInfo propertyInfo, object propertyInfoValue)
        {
            var property = configuration.AppSettings.Settings[$"{propertyInfo.Name}"];

            if (property is null)
            {
                configuration.AppSettings.Settings.Add(propertyInfo.Name, propertyInfoValue.ToString());
            }
            else
            {
                configuration.AppSettings.Settings[$"{propertyInfo.Name}"].Value = propertyInfoValue.ToString();
            }

            configuration.Save(ConfigurationSaveMode.Minimal);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
