using System;
using System.IO;
using System.Reflection;

namespace ReflectionConsoleApp.Providers.ConfigurationProviders
{
    public abstract class CustomConfigurationProvider
    {
        public abstract object LoadSettings(PropertyInfo propertyInfo);

        public abstract void SaveSettings(PropertyInfo propertyInfo, object propertyInfoValue);

        public static string GetProjectDirectoryFullPath()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            return projectDirectory;
        }
    }
}
