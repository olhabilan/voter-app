using Microsoft.EntityFrameworkCore;
using ScoreApp.Models;
using ScoreApp.Models.DataModels;

namespace ScoreApp.DataAccess
{
    public class DatabaseContext : DbContext
    {
        private readonly string _connectionString;

        public DatabaseContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        public DbSet<Code> Codes { get; set; }
        public DbSet<Supermarket> Supermarkets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(_connectionString);
        }
    }
}
