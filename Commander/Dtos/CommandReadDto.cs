namespace Commander.Dtos
{
    using System.ComponentModel.DataAnnotations;

    public class CommandReadDto
    {
        public int Id { get; set; }

        public string HowTo { get; set; }

        public string Line { get; set; }
    }
}
