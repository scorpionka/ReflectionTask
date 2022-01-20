using ReflectionConsoleApp.Configurations;
using System;
using System.IO;
using System.Reflection;

namespace ReflectionConsoleApp
{
    internal class Program
    {
        static void Main()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string path = Path.Combine(projectDirectory, "Providers.dll");

            Assembly assembly = Assembly.LoadFrom(path);

            Type typeConfigurationProviderCreator = assembly.GetType("Providers.Providers.ConfigurationProviderCreator");

            dynamic instanceConfigurationProviderCreator = Activator.CreateInstance(typeConfigurationProviderCreator);

            ConfigurationComponentBase configurationComponentBase = new(instanceConfigurationProviderCreator);

            ConfigurationSettings configurationSettings = new();

            configurationSettings.IntValue = 11;
            configurationSettings.FloatValue = 5.68F;
            configurationSettings.StringValue = "Hello, world!";
            configurationSettings.TimeSpanValue = TimeSpan.FromSeconds(1_000_000);

            configurationComponentBase.SaveSettings(configurationSettings);

            configurationComponentBase.LoadSettings(configurationSettings);

            Console.WriteLine(configurationSettings.IntValue);
            Console.WriteLine(configurationSettings.StringValue);
            Console.WriteLine(configurationSettings.FloatValue);
            Console.WriteLine(configurationSettings.TimeSpanValue);
        }
    }
}
