using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MS.CommandQuery.Core.Entities.Common;

namespace MS.CommandQuery.Core.Entities.Location
{
    [Table("TblCityLanguage")]
    public partial class CityLanguage
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CityId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LanguageId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public virtual City City { get; set; }

        public virtual Language Language { get; set; }
    }
}
