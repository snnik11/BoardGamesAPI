using BoardGamesAPI.Dtos;
using BoardGamesAPI.Model;
using BoardGamesAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BoardGamesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : Controller
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        //[HttpGet("mock-data")]
        //public async Task<IEnumerable<Games>> GetData()
        //{
        //    var gameData = await _gameService.AddMockData();
        //    return gameData;
        //}

        //[HttpGet("paginated")]

        //public async Task<IEnumerable<Games>> GetPagination()
        //{
        //    var gameP = await _gameService.A
        //}



        [HttpGet("test-db")]
        public async Task<IActionResult> TestDb()
        {
            var checkDb = await _gameService.TestDb();
            return Ok(checkDb);
        }

        [HttpGet("current-db")]
        public async Task<IActionResult> CurrentDb()
        {
            var cDb = await _gameService.GetCurrentDb();

            return Ok($"Db name {cDb}");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var getAllGames = await _gameService.GetAllGames();

            return Ok(getAllGames);
        }


        [HttpGet("games")]
        public async Task<IActionResult> GetGames([FromQuery] PageParameters pP)
        {
            var pagedGames = await _gameService.GetGamesPaginated(pP.PageNumber, pP.PageSize);
                       
            return Ok(pagedGames);
        }

        [HttpGet("{gameId}")]
        public async Task<IActionResult> GetProductById(int gameId)
        {
            var getGame = await _gameService.GetGameById(gameId);
            if(getGame == null)
            {
                return NotFound();
            }

            return Ok(getGame);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Games addGame)
        {
            var createGame = await _gameService.CreateGame(addGame);

            if(createGame == null)
            {
                return BadRequest();
            }
            return Ok( new
                {
                //anonymous object creation
                    message = "new game created in the database",
                //to do : need to fix the id - it is automatically generating random number
                id = createGame!.GameId
                }
            );
        }


        [HttpPut]
        [Route("{gameId}")]
        public async Task<IActionResult> Put([FromRoute] int gameId, [FromBody] UpdateGameDto updateDto)
        {
            var gameToUpdate = await _gameService.UpdateGame(gameId, updateDto);

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
        [Route("{gameId}")]
        public async Task<IActionResult> Delete([FromRoute] int gameId)
        {
            var deleteGame = await _gameService.DeleteGame(gameId);

            if(deleteGame == false)
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Game delete successfully",
                GameId = gameId
            });
        }




    }
}
