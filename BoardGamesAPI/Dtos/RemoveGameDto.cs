using System.ComponentModel.DataAnnotations;

namespace BoardGamesAPI.Dtos
{
    public class RemoveGameDto
    {

        // client -> API
        //only need id and name for reference for removing the game
        [Required]
        public int GameId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
