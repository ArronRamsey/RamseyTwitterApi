using FrameworkAbstractions.Interfaces;

namespace FrameworkAbstractions.Implementations
{
    public class GuidService : IGuid
    {
        public Guid GetGuid()
        {
            return Guid.NewGuid();
        }
    }
}
