namespace NetworkPointsWalker.Server.Entities
{
    public class OCP
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string GPS { get; set; }

        // simplifying
        public string LineNames { get; set; }

        public bool IsChangePoint { get; set; }
    }
}