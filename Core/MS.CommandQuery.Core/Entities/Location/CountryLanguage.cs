using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MS.CommandQuery.Core.Entities.Common;

namespace MS.CommandQuery.Core.Entities.Location
{
    [Table("TblCountryLanguage")]
    public partial class CountryLanguage
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CountryId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LanguageId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public virtual Country Country { get; set; }

        public virtual Language Language { get; set; }
    }
}
