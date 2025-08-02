using System.ComponentModel.DataAnnotations;

namespace BoardGamesAPI.Dtos
{
    public class GetGamesDto
    {
        //need all fields to provide full info about the game

        //API will send data to client(READ)
        public int GameId { get;set; }

         public string Name { get; set; }

        public double Price { get; set; }
    }
}
