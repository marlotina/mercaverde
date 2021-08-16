using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MS.CommandQuery.Core.Entities.Common;

namespace MS.CommandQuery.Core.Entities.CMS
{
    [Table("TblTextLanguage")]
    public partial class TextLanguage
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TextId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LanguageId { get; set; }

        public string Translation { get; set; }

        public virtual Language Language { get; set; }

        public virtual Text Text { get; set; }
    }
}
