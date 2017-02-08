using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiteDatabase
{
    public partial class Song
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string Title { get; set; }

        [StringLength(2147483647)]
        public string LastPlayedDate { get; set; }

        [Required]
        public long ArtistId { get; set; }
        public virtual Artist Artist { get; set; }

        public long? GenreId { get; set; }
        public virtual Genre Genre { get; set; }

        public long? StatusId { get; set; }
        public virtual Status Status { get; set; }

        public virtual ICollection<Filepath> Filepaths { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<rProgressNodeSong> rProgressNodeSongs { get; set; }
    }
}