using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace musicServiceCore.Models
{
    public class MusicContext : DbContext
    {
        public const string DbConnectionString = "Data Source=DESKTOP-QE3HU57;Initial Catalog = MusicService; Integrated Security = True";
        public MusicContext(DbContextOptions<MusicContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserFavorite>().HasKey(uf => new { uf.UserId, uf.TrackId });
            builder.Entity<UserListened>().HasKey(ul => new { ul.UserId, ul.TrackId });
            builder.Entity<MusicianGenres>().HasKey(mg => new { mg.MusicianId, mg.GenreId });
            builder.Entity<UsersLike>().HasKey(ul => new { ul.UserId, ul.TrackId });
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MusicianGenres> MusicianGenres { get; set; }
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserFavorite> UserFavorite { get; set; }
        public DbSet<UserListened> UserListened { get; set; }
        public DbSet<UsersLike> UsersLikes { get; set; }
    }
}
