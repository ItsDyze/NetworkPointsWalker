namespace NetworkPointsWalker.Server.DTO
{
    public class StationDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid OCPId { get; set; }
        public OCPDTO OCP { get; set; }
    }
}
