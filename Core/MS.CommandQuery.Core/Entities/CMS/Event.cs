using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MS.CommandQuery.Core.Entities.Common;
using MS.CommandQuery.Core.Entities.Users;

namespace MS.CommandQuery.Core.Entities.CMS
{
    [Table("TblEvent")]
    public partial class Event
    {
        [Key]
        public int IdEvent { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }

        public int UserId { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public int LanguageId { get; set; }

        public bool HasRevised { get; set; }

        public bool IsPublished { get; set; }

        public bool Deleted { get; set; }

        public DateTime? PublishDate { get; set; }

        public virtual Language Language { get; set; }

        public virtual User User { get; set; }
    }
}
