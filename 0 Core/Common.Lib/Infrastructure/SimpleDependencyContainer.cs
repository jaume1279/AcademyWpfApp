using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Lib.Infrastructure
{
    public class SimpleDependencyContainer : IDependencyContainer
    {
        private static Dictionary<Type, Func<object>> Constructors { get; set; } = new Dictionary<Type, Func<object>>();

        private static Dictionary<Type, Func<object[], object>> ConstructorsWithParams { get; set; } = new Dictionary<Type, Func<object[], object>>();

        public void Register<Tin, Tout>() where Tout : class, Tin, new()
        {
            var typeIn = typeof(Tin);
            var typeOut = typeof(Tout);

            var func = new Func<object>(() =>
            {
                return Activator.CreateInstance(typeOut);
            });

            if (Constructors.ContainsKey(typeIn))
                Constructors[typeIn] = func;
            else
                Constructors.Add(typeIn, func);
        }

        public void Register<Tin, Tout>(Func<object[], object> constructor) where Tout : class, Tin
        {
            var typeIn = typeof(Tin);
            var typeOut = typeof(Tout);                       

            if (ConstructorsWithParams.ContainsKey(typeIn))
                ConstructorsWithParams[typeIn] = constructor;
            else
                ConstructorsWithParams.Add(typeIn, constructor);
        }

        public Tin Resolve<Tin>()
        {
            var typeIn = typeof(Tin);

            if (!Constructors.ContainsKey(typeIn))
            {
                return Resolve<Tin>(null);
            }
            else
            {
                var constructor = Constructors[typeIn];
                return (Tin)constructor();
            }
        }

        public Tin Resolve<Tin>(object[] parameters = default)
        {
            var typeIn = typeof(Tin);

            if (!ConstructorsWithParams.ContainsKey(typeIn))
                throw new NotImplementedException();

            var constructor = ConstructorsWithParams[typeIn];
            return (Tin)constructor(parameters);
        }
    }
}
