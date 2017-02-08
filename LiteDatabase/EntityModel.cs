using System.Data.Entity;

namespace LiteDatabase
{
    public partial class EntityModel : DbContext
    {
        public EntityModel()
            : base("name=EntityModel")
        {
        }

        public virtual DbSet<Filepath> Filepaths { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<ProgressNode> ProgressNodes { get; set; }
        public virtual DbSet<Song> Songs { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }

        public virtual DbSet<rProgressNodeSong> RProgressNodeSongs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>()
                .HasMany(t => t.Groups)
                .WithMany(t => t.Songs)
                .Map(m =>
                {
                    m.ToTable("rGroupSong");
                    m.MapLeftKey("SongId");
                    m.MapRightKey("GroupId");
                });
        }
    }
}