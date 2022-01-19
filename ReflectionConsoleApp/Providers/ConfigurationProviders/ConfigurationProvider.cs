namespace ReflectionConsoleApp.Providers.ConfigurationProviders
{
    public class ConfigurationProvider<T>
    {
        public virtual T LoadSettings(string settingName, ProviderType providerType)
        {
            throw new System.NotImplementedException();
        }

        public virtual void SaveSettings(string settingName, ProviderType providerType, T value)
        {
            throw new System.NotImplementedException();
        }
    }
}
