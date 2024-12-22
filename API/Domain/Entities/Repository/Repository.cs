namespace Domain.Entities.Repository
{
    public class Repository
    {
        public int id { get; set; }
        public string node_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTimeOffset created_at { get; set; }
    }
}
