namespace Todo.API.Models
{
    public class Todos
    {
        public int Id { get; set; }
        public string Todo { get; set; }
        public string Priority { get; set; }
        public string Deadline { get; set; }  
    }
}
