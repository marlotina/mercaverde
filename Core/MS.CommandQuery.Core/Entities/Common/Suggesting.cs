using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MS.CommandQuery.Core.Entities.Users;

namespace MS.CommandQuery.Core.Entities.Common
{
    [Table("TblSuggestingClients")]
    public partial class Suggesting
    {
        [Key]
        public int IdSuggesting { get; set; }

        public string Email { get; set; }

        public string Subject { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? ResponseDate { get; set; }

        public bool Revised { get; set; }

        public int? UserId { get; set; }

        public virtual User User { get; set; }

        public string Text { get; set; }

    }
}
