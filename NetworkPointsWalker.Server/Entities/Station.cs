namespace NetworkPointsWalker.Server.Entities
{
    public class Station
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid OCPId { get; set; }
        public OCP OCP { get; set; }   
    }
}