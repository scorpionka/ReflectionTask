using ReflectionConsoleApp.Attributes;
using System;

namespace ReflectionConsoleApp.Configurations
{
    public class ConfigurationSettings
    {
        [ConfigurationItem("IntValue", Providers.ProviderType.File)]
        public int IntValue { get; set; }

        [ConfigurationItem("FloatValue", Providers.ProviderType.ConfigurationManager)]
        public float FloatValue { get; set; }

        [ConfigurationItem("StringValue", Providers.ProviderType.File)]
        public string StringValue { get; set; }

        [ConfigurationItem("TimeSpanValue", Providers.ProviderType.ConfigurationManager)]
        public TimeSpan TimeSpanValue { get; set; }
    }
}
