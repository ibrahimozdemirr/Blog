using Microsoft.Extensions.Localization;
using System.Reflection;

namespace Blog.Methods
{
    public class SharedResource
    {

    }
    public class LanguageService
    {
        private readonly IStringLocalizer _Localizer;

        public LanguageService(IStringLocalizerFactory factory)
        {
            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _Localizer = factory.Create(nameof(SharedResource), assemblyName.Name);
        }
        public LocalizedString GetKey(string key)
        {
            return _Localizer[key];
        }
    }
}
