using ReflectionConsoleApp.Configurations;
using ReflectionConsoleApp.Providers;
using System;

namespace ReflectionConsoleApp
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello World!");

            ConfigurationComponentBase configurationComponentBase = new(new ConfigurationProviderCreator());

            ConfigurationSettings configurationSettings = new();

            //configurationSettings.IntValue = 5;
            //configurationSettings.FloatValue = 1.25F;
            //configurationSettings.StringValue = "value";
            //configurationSettings.TimeSpanValue = TimeSpan.FromSeconds(1);

            //configurationComponentBase.SaveSettings(configurationSettings);

            configurationComponentBase.LoadSettings(configurationSettings);

            Console.WriteLine(configurationSettings.IntValue);
            Console.WriteLine(configurationSettings.StringValue);
            Console.WriteLine(configurationSettings.FloatValue);
            Console.WriteLine(configurationSettings.TimeSpanValue);
        }
    }
}
