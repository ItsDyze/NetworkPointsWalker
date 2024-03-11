using NetworkPointsWalker.Server.Entities;

namespace NetworkPointsWalker.Server.ViewModel
{
    public class CrawledPathViewModel
    {
        public List<OCPViewModel> OCPs { get; set; }
        public double Distance { get; set; }

        public CrawledPathViewModel(List<OCPViewModel> oCPs, double distance)
        {
            OCPs = oCPs;
            Distance = distance;
        }
    }
}
