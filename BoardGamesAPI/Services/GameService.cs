using BoardGamesAPI.Data;
using BoardGamesAPI.Dtos;
using BoardGamesAPI.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace BoardGamesAPI.Services
{

    //services talk to the model mainly not DTOs
    public class GameService : IGameService
    {
        private readonly GameDbContext _db;

        public GameService(GameDbContext db)
        {
            _db = db;
        }

        public async Task<int> TestDb()
        {
            return await _db.Games.CountAsync();            
        }

        public async Task<string> GetCurrentDb()
        {
            return _db.Database.GetDbConnection().Database;

        }

        public async Task<IEnumerable<Games>> AddMockData()
        {
            for(int i =0; i<=10;i++)
            {
                _db.Games.Add(new Games { Name = "Game "+ i, Price = 10.0 * i});
            }

            await _db.SaveChangesAsync();
            return await _db.Games.ToListAsync();
        }

        //public  Task<IEnumerable<Games>> AddPagination(int page = 1, int pageSize = 5)
        //{
        //    var totalCount =  _db.Games.Count();
           

        //    var total =  (int)Math.Ceiling((decimal)totalCount / pageSize);

        //    var productPerPage =  _db.Games.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        //    return  productPerPage;

        //}

        public async Task<List<Games>> GetAllGames()
        {
            return await _db.Games.AsNoTracking().ToListAsync();
          
        }

        public async Task<PagedResult<Games>> GetGamesPaginated(int pageNumber, int pageSize)
        {
            var totalCount = await _db.Games.CountAsync();

            var games = await _db.Games.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();


            return new PagedResult<Games>
            {
                Data = games,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling((double)totalCount / pageSize)

            };
        }

        //fetch data from the db
        public async Task<Games> GetGameById(int gameid)
        {
            return await _db.Games.AsNoTracking().FirstOrDefaultAsync(x => x.GameId == gameid);
        }


        //add game to the db
        public async Task<Games> CreateGame(Games addGame)
        {
            var newGame = new Games()
            {             
                Name = addGame.Name,
                Price = addGame.Price
            };

            _db.Games.Add(newGame);

            var saveChangesToDB = await _db.SaveChangesAsync();


            //return newGame object including auto-generated id, name and price
            //this is returned if the affected rows were updated in the db else returns null
            return saveChangesToDB >= 0 ? newGame : null;
        }
            

        public async Task<Games> UpdateGame(int id, UpdateGameDto updateDto)
        {
            //check if id exists
            var checkId = await _db.Games.FirstOrDefaultAsync(x => x.GameId == id);

            if(checkId != null)
            {
                if(!string.IsNullOrEmpty(updateDto.Name))
                {
                    checkId.Name = updateDto.Name;
                }
                
                if(updateDto.Price.HasValue && updateDto.Price.Value >0)
                {
                    checkId.Price = updateDto.Price.Value; //to retain double 
                }
              

                var saveChangesToDb = await _db.SaveChangesAsync();


                //returns id which got updated if the db successfully saves the changes
                //res - affected no. of rows
                //else returns null to avoid throwing exceptions
                return saveChangesToDb >= 0 ? checkId : null ;
            }
            return null;

        }

        public async Task<bool> DeleteGame(int gameid)
        {
            var checkId = await _db.Games.FirstOrDefaultAsync(x => x.GameId == gameid);

            if(checkId != null)
            {
                //remove game info from Db
                _db.Games.Remove(checkId);

                //it will return 1 as in 1 row affected
                var saveChangesToDb = await _db.SaveChangesAsync();

                //returns true
                return saveChangesToDb > 0;
            }
            return false;
        }

    }
}
