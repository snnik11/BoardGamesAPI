using System.ComponentModel.DataAnnotations;

namespace BoardGamesAPI.Dtos
{
    public class UpdateGameDto
    {

        // client(PUT/PATCH) will send data to API that needs to be updated
        [Required]
        public int GameId { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }
    }
}
