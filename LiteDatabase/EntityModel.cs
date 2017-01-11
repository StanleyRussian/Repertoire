namespace LiteDatabase
{
    using System.Data.Entity;

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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>()
                .HasMany(t => t.Groups)
                .WithMany(t => t.Songs)
                .Map(m =>
                {
                    m.ToTable("r_GroupSong");
                    m.MapLeftKey("SongId");
                    m.MapRightKey("GroupId");
                });

            modelBuilder.Entity<Song>()
                .HasMany(t => t.ProgressNodes)
                .WithMany(t => t.Songs)
                .Map(m =>
                {
                    m.ToTable("r_ProgressNodeSong");
                    m.MapLeftKey("SongId");
                    m.MapRightKey("ProgressNodeId");
                });
        }
    }
}