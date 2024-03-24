using NetworkPointsWalker.Server.Entities;

namespace NetworkPointsWalker.Server.DTO
{
    public class CrawledPathDTO
    {
        public IList<OCPDTO> OCPs { get; set; }

        public bool IsValid { get; set; }
    }
}
