using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MS.CommandQuery.Core.Entities.Common;
using MS.CommandQuery.Core.Entities.Users;

namespace MS.CommandQuery.Core.Entities.Product
{

    [Table("TblBrandComment")]
    public partial class BrandComment
    {
        [Key]
        public int IdBrandComment { get; set; }

        [Required]
        [StringLength(500)]
        public string Text { get; set; }

        public int UserId { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? ModificationDate { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        public int BrandId { get; set; }

        public int LanguageId { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual Language Language { get; set; }

        public virtual User User { get; set; }
    }
}
