using System;

namespace Common.Lib.Infrastructure
{
    public interface IDependencyContainer
    {
        void Register<Tin, Tout>() where Tout : class, Tin, new();

        void Register<Tin, Tout>(Func<object[], object> constructor) where Tout : class, Tin;

        Tin Resolve<Tin>();

        Tin Resolve<Tin>(object[] parameters = default);
    }
}
