using FrameworkAbstractions.Interfaces;

namespace FrameworkAbstractions.Implementations
{
    internal class GuidService : IGuid
    {
        public Guid GetGuid()
        {
            return Guid.NewGuid();
        }
    }
}
