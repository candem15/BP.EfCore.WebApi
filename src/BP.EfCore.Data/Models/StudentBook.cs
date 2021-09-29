namespace BP.EfCore.Data.Models
{
    public class StudentBook
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}