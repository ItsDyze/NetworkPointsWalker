using NetworkPointsWalker.Server.Entities;

namespace NetworkPointsWalker.Server.DTO
{
    public class CrawledPathDTO
    {
        public List<OCPDTO> OCPs { get; set; }

        public CrawledPathDTO(List<OCPDTO> oCPs)
        {
            OCPs = oCPs;
        }
    }
}
