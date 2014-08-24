using System.Configuration;

using Mag.Business.Abstract;

namespace Mag.Business
{
    public class SettingsReader : IAccountSettings
    {
        private string GetValueByKey(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public string RegistrationAccessCode
        {
            get { return GetValueByKey("RegistrationAccessCode"); }
        }
    }
}