namespace LiteDatabase
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Song
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string Title { get; set; }

        [Required]
        public long ArtistId { get; set; }
        [ForeignKey("ArtistId")]
        public virtual Artist Artist { get; set; }

        [Required]
        public long GenreId { get; set; }
        [ForeignKey("GenreId")]
        public virtual Genre Genre { get; set; }

        [Required]
        public long StatusId { get; set; }
        [ForeignKey("StatusId")]
        public virtual Status Status { get; set; }

        public virtual ICollection<Filepath> Filepaths { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<ProgressNode> ProgressNodes { get; set; }
    }
}
