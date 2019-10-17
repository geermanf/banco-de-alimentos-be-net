using System;

namespace Farmacity.Infrastructure.Web
{
    public interface IInjectableScope : IServiceProvider
    {
        IInjectableScope Inject<T>(T value);

        IInjectableScope Inject(Type type, object value);
    }
}
