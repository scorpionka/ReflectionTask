using Microsoft.Extensions.Configuration;
using ReflectionConsoleApp.Providers.ConfigurationProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace ReflectionConsoleApp.Providers
{
    public class FileConfigurationProvider : CustomConfigurationProvider
    {
        const string path = "ConfigurationSettings.xml";

        public override object LoadSettings(PropertyInfo propertyInfo)
        {
            return null;
        }

        public override void SaveSettings(PropertyInfo propertyInfo, object propertyInfoValue)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            XElement xmlTree = XElement.Load(Path.Combine(projectDirectory, path));
            XElement child = xmlTree.Element(propertyInfo.Name);
            if (child is null)
            {
                xmlTree.Add(new XElement(propertyInfo.Name, propertyInfoValue));
            }
            else
            {
                child.ReplaceWith(new XElement(propertyInfo.Name, propertyInfoValue));
            }
            
            xmlTree.Save(Path.Combine(projectDirectory, path));
        }
    }
}
