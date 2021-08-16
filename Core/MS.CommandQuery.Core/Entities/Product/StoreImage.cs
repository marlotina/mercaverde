using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MS.CommandQuery.Core.Entities.Product
{
    [Table("TblStoreImage")]
    public partial class StoreImage
    {
        [Key]
        public int IdStoreImage { get; set; }

        public int StoreId { get; set; }

        [Required]
        [StringLength(500)]
        public string Url { get; set; }

        public int Order { get; set; }

        public bool IsMain { get; set; } 

        public virtual Store Store { get; set; }
    }
}
