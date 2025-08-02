using BoardGamesAPI.Model;
using BoardGamesAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BoardGamesAPI.Controllers
{
    [Route("api/[controller]")]
    [Ap]
    public class GameController : Controller
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var getAllGames = await _gameService.GetAllGames();

            return Ok(getAllGames);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var getGame = _gameService.GetGameById(id);
            if(getGame == null)
            {
                return NotFound();
            }

            return Ok(getGame);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Games addGame)
        {
            var createGame = _gameService.CreateGame(addGame);

            if(createGame == null)
            {
                return BadRequest();
            }
            return Ok( new
                {
                //anonymous object creation
                    message = "new game created in the database",
                //to do : need to fix the id - it is automatically generating random number
                id = createGame!.Id
                }
            );
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] Games g)
        {
            var gameToUpdate = await _gameService.UpdateGame(id, g);

            if(gameToUpdate == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Updated the info correctly",
                id = gameToUpdate!.GameId
            });
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteGame = _gameService.DeleteGame(id);

            if(deleteGame == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Game delete successfully",
                GameId = id
            });
        }




    }
}
