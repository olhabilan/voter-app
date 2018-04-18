using Microsoft.EntityFrameworkCore;
using ScoreApp.Models;

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
        //public DbSet<Substitution> Substitutions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(_connectionString);
        }
    }
}
