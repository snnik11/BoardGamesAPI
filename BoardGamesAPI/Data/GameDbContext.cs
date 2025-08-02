using BoardGamesAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace BoardGamesAPI.Data
{
    public class GameDbContext : DbContext
    {

        //DBContext talks to model
        //added constructor to accept EF option and send to DbContext
        public GameDbContext(DbContextOptions<GameDbContext> opt) : base(opt)
        {

        }

        //registered DB Model Games in this class 
        public DbSet<Games> Games { get; set; }


        //configured Games model and added sample data
        protected override void OnModelCreating(ModelBuilder modBuilder)
        {
            //setting primary key
            modBuilder.Entity<Games>().HasKey(x=> x.GameId);

            //insert records
            modBuilder.Entity<Games>().HasData
                (
                    new Games
                    {
                        GameId = 1,
                        Name = "Catan",
                        Price = 49.9
                    },
                    new Games
                    {
                        GameId = 2,
                        Name = "Sushi GO",
                        Price = 35.6
                    },
                    new Games
                    {
                        GameId = 3,
                        Name = "Monopoly",
                        Price = 40
                    }


                );
        }



    }
}
