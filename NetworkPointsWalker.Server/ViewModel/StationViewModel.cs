namespace NetworkPointsWalker.Server.ViewModel
{
    public class StationViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid OCPId { get; set; }
        public OCPViewModel OCP { get; set; }
    }
}
