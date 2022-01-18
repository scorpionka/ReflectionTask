using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionConsoleApp.Providers.ConfigurationProviders
{
    public class ConfigurationProvider
    {
        public virtual void LoadSettings(string settingName, ProviderType providerType)
        {
            throw new System.NotImplementedException();
        }

        public virtual void SaveSetting(string settingName, ProviderType providerType)
        {
            throw new System.NotImplementedException();
        }
    }
}
