using System;
using System.Collections.Generic;
using System.Text;

namespace Poc.MassTransit.Infrastructure
{
   public class MassTransitConfigurationManager
    {
        private const string SectionName = "MassTransitConfiguration";

        public static MassTransitConfigurationSection Config
        {
            get
            {
                               
                return Settings.Current.GetSectionSettingValue<MassTransitConfigurationSection>(SectionName);


            }
        }


    }
}
