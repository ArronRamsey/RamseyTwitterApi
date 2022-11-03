using Core.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace Core.Services.Implementations
{
    public class SettingService : ISettingService
    {
        private readonly Settings _settings;

        public SettingService(IOptions<Settings> settings)
        {
            _settings = settings.Value;
        }

        public Settings GetSettings()
        {
            return _settings;
        }
    }
}
