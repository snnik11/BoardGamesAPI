using BoardGamesAPI.Dtos;
using BoardGamesAPI.Model;

namespace BoardGamesAPI.Services
{
    public interface IGameService
    {
        Task<int> TestDb();

        Task<string> GetCurrentDb();
        Task<List<Games>> GetAllGames();

        Task<Games> GetGameById(int id);

        Task<Games> CreateGame(Games addGame);

        Task<Games> UpdateGame(int id, UpdateGameDto updateDto);

        Task<bool> DeleteGame(int id);

        Task<IEnumerable<Games>> AddMockData();

        Task<PagedResult<Games>> GetGamesPaginated(int pageNumber, int pageSize);
    }
}
