using System.ComponentModel.DataAnnotations;

namespace BoardGamesAPI.Dtos
{
    public class CreateGameDto
    {
        //doesnt need Id as it will generated automatically 


        //client(POST) to API 
        //client will send data in JSON format through DTO to be created in the server 

        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
