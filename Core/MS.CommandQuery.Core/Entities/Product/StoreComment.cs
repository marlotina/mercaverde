using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MS.CommandQuery.Core.Entities.Users;

namespace MS.CommandQuery.Core.Entities.Product
{
    [Table("TblStoreComment")]
    public partial class StoreComment
    {
        [Key]
        public int IdStoreComment { get; set; }

        [Required]
        [StringLength(500)]
        public string Text { get; set; }

        public int UserId { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? ModificationDate { get; set; }

        public int Order { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        public int StoreId { get; set; }

        public virtual Store Store { get; set; }

        public virtual User User { get; set; }
    }
}
