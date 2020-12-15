using System.ComponentModel.DataAnnotations;

namespace CICD_API.Entity
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
    }
}