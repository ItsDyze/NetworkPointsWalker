namespace NetworkPointsWalker.Server.Models
{
    public class StationModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid OCPId { get; set; }
        public OCPModel OCP { get; set; }
    }
}
