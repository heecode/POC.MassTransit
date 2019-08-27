using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Poc.MassTransit.Infrastructure
{
    public partial class Settings
    {
        //  private static object syncRoot = new Object();
        private static Settings _current;

        public static Settings Current
        {
            get
            {

                if (_current == null)
                {
                    _current = new Settings();
                }

                return _current;
            }
        }



        /// <summary>
        /// Standardized way to extract key value pair from appsettings
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetSettingValue<T>(string key)
        {
            var value = string.Empty;

            if (ConfigurationManager.AppSettings[key] != null)
                value = ConfigurationManager.AppSettings.Get(key);

            // send default T
            if (string.IsNullOrWhiteSpace(value))
                return default(T);
            else
                return (T)Convert.ChangeType(value, typeof(T));
        }

        /// <summary>
        /// Standardized way to extract key value pair from appsettings
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetSectionSettingValue<T>(string key)
        {
            object value = null;

            if (ConfigurationManager.GetSection(key) != null)
                value = ConfigurationManager.GetSection(key);

            // send default T
            if (value == null)
                return default(T);
            else
                return (T)Convert.ChangeType(value, typeof(T));
        }


    }
}
