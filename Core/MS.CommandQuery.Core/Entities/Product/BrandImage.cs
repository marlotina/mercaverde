using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MS.CommandQuery.Core.Entities.Product
{
    [Table("TblBrandImage")]
    public partial class BrandImage
    {
        [Key]
        public int IdBrandImage { get; set; }

        public int BrandId { get; set; }

        [Required]
        [StringLength(50)]
        public string Url { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public int Order { get; set; }

        public virtual Brand Brand { get; set; }
    }
}
