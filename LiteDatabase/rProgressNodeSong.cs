using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiteDatabase
{
    [Table("rProgressNodeSong")]
    public partial class rProgressNodeSong
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public long Id { get; set; }

        [Required]
        public long SongId { get; set; }
        public Song Song { get; set; }

        [Required]
        public long ProgressNodeId { get; set; }
        public ProgressNode ProgressNode { get; set; }

        public long? GroupId { get; set; }
        public Group Group { get; set; }
    }
}