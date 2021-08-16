using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MS.CommandQuery.Core.Entities.Common;
using MS.CommandQuery.Core.Entities.Users;

namespace MS.CommandQuery.Core.Entities.CMS
{
    [Table("TblNews")]
    public partial class NewsItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NewsItem()
        {
            NewsComment = new HashSet<NewsComment>();
        }

        [Key]
        public int IdNews { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }

        public int UserId { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }

        public int LanguageId { get; set; }

        public bool HasRevised { get; set; }

        public bool IsPublished { get; set; }

        public bool Deleted { get; set; }

        public DateTime? PublishDate { get; set; }

        public virtual Language Language { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NewsComment> NewsComment { get; set; }
    }
}
