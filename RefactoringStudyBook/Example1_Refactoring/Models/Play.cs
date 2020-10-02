namespace Example1_Refactoring.Models
{
    public class Play
    {
        public string Id { get; set; }
        public PlayDetails Details { get; set; }


    }

    public class PlayDetails
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
