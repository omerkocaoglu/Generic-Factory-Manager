using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GenericFactoryManager
{
    public static class FactoryManager<TAbstract, TConcrete>
            where TAbstract : class
            where TConcrete : class, new()
    {
        private static TAbstract _instance;
        private static Lazy<TConcrete> _lazyInstance;

        public static TAbstract Create()
        {
            if (_instance == null)
            {
                _instance = Activator.CreateInstance<TConcrete>() as TAbstract;
            }

            return _instance;
        }

        public static TAbstract Create(params object[] parameters)
        {
            if (_instance == null)
            {
                _instance = Activator.CreateInstance(typeof(TConcrete), parameters) as TAbstract;
            }

            return _instance;
        }

        public static Lazy<TConcrete> CreateLazy()
        {
            if (_lazyInstance == null)
            {
                _lazyInstance = new Lazy<TConcrete>(LazyThreadSafetyMode.ExecutionAndPublication);
            }

            return _lazyInstance;
        }

        public static Lazy<TConcrete> CreateLazy(params object[] parameters)
        {
            if (_lazyInstance == null)
            {
                _lazyInstance = new Lazy<TConcrete>(() => (TConcrete)Activator.CreateInstance(typeof(TConcrete), parameters), LazyThreadSafetyMode.ExecutionAndPublication);
            }

            return _lazyInstance;
        }
    }
}
