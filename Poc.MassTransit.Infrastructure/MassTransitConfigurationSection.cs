using System;
using System.Configuration;

namespace Poc.MassTransit.Infrastructure
{
    public class MassTransitConfigurationSection : ConfigurationSection
    {
        private const string HOST = "host";
        private const string PASSWORD = "password";
        private const string USERNAME = "username";

        [ConfigurationProperty(HOST, IsRequired = true)]
        public string Host
        {
            get { return this[HOST].ToString(); }
        }

        [ConfigurationProperty(PASSWORD, IsRequired = true)]
        public string Password
        {
            get { return this[PASSWORD].ToString(); }
        }

        [ConfigurationProperty(USERNAME, IsRequired = true)]
        public string Username
        {
            get { return this[USERNAME].ToString(); }
        }

    }
}
