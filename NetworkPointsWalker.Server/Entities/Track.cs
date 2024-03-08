namespace NetworkPointsWalker.Server.Entities
{
    public class Track
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string OCPFromName { get; set; }
        public Guid OCPFromId { get; set; }
        public OCP OCPFrom { get; set; }

        public string OCPToName { get; set; }
        public Guid OCPToId { get; set; }
        public OCP OCPTo { get; set; }
    }
}