using FrameworkAbstractions.Interfaces;

namespace FrameworkAbstractions.Implementations
{
    public class GuidService : IGuidService
    {
        public Guid GetGuid()
        {
            return Guid.NewGuid();
        }
    }
}
