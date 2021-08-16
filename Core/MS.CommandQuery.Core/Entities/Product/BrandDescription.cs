using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MS.CommandQuery.Core.Entities.Common;

namespace MS.CommandQuery.Core.Entities.Product
{
    [Table("TblBrandDescription")]
    public partial class BrandDescription
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BrandId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LanguageId { get; set; }

        public string Description { get; set; }

        [StringLength(150)]
        public string Title { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual Language Language { get; set; }
    }
}
