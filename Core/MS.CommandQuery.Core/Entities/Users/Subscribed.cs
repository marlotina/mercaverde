using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MS.CommandQuery.Core.Entities.Users
{
    [Table("TblSubscribed")]
    public partial class Subscribed
    {
        [Key]
        [StringLength(150)]
        public string Email { get; set; }

        public int Type { get; set; }

        public int LanguageId { get; set; }

        public bool Active { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? ModificationDate { get; set; }

        public int? UserId { get; set; }

        public virtual User User { get; set; }
    }
}
