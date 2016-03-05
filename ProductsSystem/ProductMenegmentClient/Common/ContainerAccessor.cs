using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;
using System.ComponentModel;

namespace ProductMenegmentClient
{
    public class ContainerAccessor
    {
        private static UnityContainer _container;
        
        public ContainerAccessor()
        {
            if (_container == null)
            {
                _container = new UnityContainer();

                //---Runtime Type binding - Read the Type mappings from unity container section from configuration file.
                UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");

                section.Containers.Default.Configure(_container);
            }
        }

        public UnityContainer GetContainer()
        {
            return _container;
        }
    }
}
