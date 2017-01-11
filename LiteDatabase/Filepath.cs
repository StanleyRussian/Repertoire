namespace LiteDatabase
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Filepath
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string Path { get; set; }

        [Required]
        public long SongId { get; set; }
        [ForeignKey("SongId")]
        public Song Song { get; set; }

    }
}