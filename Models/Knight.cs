using System.ComponentModel.DataAnnotations;



namespace castle.Models
{
    public class Knight
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int NumberOfSwords { get; set; }
        public int NumberOfDragonsKilled { get; set; }


    }
}