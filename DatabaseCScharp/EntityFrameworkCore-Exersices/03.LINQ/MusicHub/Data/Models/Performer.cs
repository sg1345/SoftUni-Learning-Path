using System;
using System.Collections.Generic;



namespace MusicHub.Data.Models
{

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Common.EntityValidation.Performer;
    public class Performer
    {

        /* 

•	NetWorth – decimal (required)
•	PerformerSongs – a collection of type SongPerformer         
         */
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(FirstNameLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(LastNameLength)]
        public string LastName { get; set; } = null!;

        [Required]
        public int Age { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal NetWorth { get; set; }

        public virtual ICollection<SongPerformer> PerformerSongs { get; set; }
            = new HashSet<SongPerformer>();
    }
}
