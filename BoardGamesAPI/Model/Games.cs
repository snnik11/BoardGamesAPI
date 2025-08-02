using System.ComponentModel.DataAnnotations;

namespace BoardGamesAPI.Model
{
    public class Games
    {

        [Key]
        [Required]
        public int GameId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

    }
}
