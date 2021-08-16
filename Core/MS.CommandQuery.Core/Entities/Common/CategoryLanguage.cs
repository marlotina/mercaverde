using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MS.CommandQuery.Core.Entities.Common
{
    [Table("TblCategoryLanguage")]
    public partial class CategoryLanguage
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CategoryId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LanguageId { get; set; }

        [StringLength(150)]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual Category Category { get; set; }

        public virtual Language Language { get; set; }
    }
}
