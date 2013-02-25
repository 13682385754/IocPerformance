﻿using System.Linq;
using System.Xml.Linq;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace IocPerformance.Adapters
{
    public sealed class WindsorContainerAdapter : IContainerAdapter
    {
        private WindsorContainer container;

        public string Version
        {
            get
            {
                return XDocument
                    .Load("packages.config")
                    .Root
                    .Elements()
                    .First(e => e.Attribute("id").Value == "Castle.Windsor")
                    .Attribute("version").Value;
            }
        }

        public void Prepare()
        {
            this.container = new WindsorContainer();

            this.container.Register(Component.For<ISingleton>().ImplementedBy<Singleton>());
            this.container.Register(Component.For<ITransient>().ImplementedBy<Transient>().LifeStyle.Transient);
            this.container.Register(Component.For<ICombined>().ImplementedBy<Combined>().LifeStyle.Transient);
        }

        public T Resolve<T>() where T : class
        {
            return this.container.Resolve<T>();
        }

        public void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
        }
    }
}