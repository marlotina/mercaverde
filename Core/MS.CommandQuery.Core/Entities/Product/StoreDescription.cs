using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MS.CommandQuery.Core.Entities.Common;

namespace MS.CommandQuery.Core.Entities.Product
{
    [Table("TblStoreDescription")]
    public partial class StoreDescription
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StoreId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LanguageId { get; set; }

        public string Description { get; set; }

        public string ShortDescription { get; set; }

        public string Title { get; set; }

        public virtual Language Language { get; set; }

        public virtual Store Store { get; set; }
    }
}
