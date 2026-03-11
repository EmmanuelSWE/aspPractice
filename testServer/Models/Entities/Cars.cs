namespace testServer.Models.Entities
{
    public class Cars
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int OwnerId { get; set; }
    }
}