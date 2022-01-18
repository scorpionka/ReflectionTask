using ReflectionConsoleApp.Configurations;
using ReflectionConsoleApp.Providers;
using System;

namespace ReflectionConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ConfigurationComponentIntValue configurationComponentIntValue = new(new ConfigurationProviderCreator());

            configurationComponentIntValue.LoadSettings();
        }
    }
}
