using BoardGamesAPI.Model;

namespace BoardGamesAPI.Services
{
    public interface IGameService
    {
        Task<List<Games>> GetAllGames();

        Task<Games> GetGameById(int id);

        Task<Games> CreateGame(Games addGame);

        Task<Games> UpdateGame(int id, Games g);

        Task<bool> DeleteGame(int id);

        Task<IEnumerable<Games>> AddMockData();
    }
}
