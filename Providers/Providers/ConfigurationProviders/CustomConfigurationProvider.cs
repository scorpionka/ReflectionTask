using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;

namespace ReflectionConsoleApp.Providers.ConfigurationProviders
{
    public abstract class CustomConfigurationProvider
    {
        public abstract object LoadSettings(PropertyInfo propertyInfo);

        public abstract void SaveSettings(PropertyInfo propertyInfo, object propertyInfoValue);

        protected static string GetProjectDirectoryFullPath()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            return projectDirectory;
        }

        protected static object Cast(object obj, Type castTo)
        {
            var converter = TypeDescriptor.GetConverter(castTo);
            return converter.CanConvertFrom(obj.GetType()) ? converter.ConvertFrom(obj) : default;
        }
    }
}
