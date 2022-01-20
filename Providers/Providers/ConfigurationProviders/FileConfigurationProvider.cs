using ReflectionConsoleApp.Providers.ConfigurationProviders;
using System;
using System.IO;
using System.Reflection;
using System.Xml.Linq;

namespace ReflectionConsoleApp.Providers
{
    public class FileConfigurationProvider : CustomConfigurationProvider
    {
        const string configurationSettingsFileName = "ConfigurationSettings.xml";

        public override object LoadSettings(PropertyInfo propertyInfo)
        {
            string path = Path.Combine(GetProjectDirectoryFullPath(), configurationSettingsFileName);

            Type propertyType = propertyInfo.PropertyType;

            XElement xmlTree = XElement.Load(path);
            XElement childElement = xmlTree.Element(propertyInfo.Name);

            if (childElement is null)
            {
                return null;
            }

            return Cast(childElement.Value, propertyType);
        }

        public override void SaveSettings(PropertyInfo propertyInfo, object propertyInfoValue)
        {
            string path = Path.Combine(GetProjectDirectoryFullPath(), configurationSettingsFileName);

            XElement xmlTree = XElement.Load(path);
            XElement childElement = xmlTree.Element(propertyInfo.Name);

            if (childElement is null)
            {
                xmlTree.Add(new XElement(propertyInfo.Name, propertyInfoValue));
            }
            else
            {
                childElement.ReplaceWith(new XElement(propertyInfo.Name, propertyInfoValue));
            }

            xmlTree.Save(path);
        }
    }
}
