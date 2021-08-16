using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MS.CommandQuery.Core.Entities.Common;

namespace MS.CommandQuery.Core.Entities.CMS
{
    [Table("TblMailTemplateLanguage")]
    public partial class MailTemplateLanguage
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MailTemplateId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LanguageId { get; set; }

        public string Text { get; set; }

        [StringLength(250)]
        public string Subject { get; set; }

        public virtual Language Language { get; set; }

        public virtual MailTemplate MailTemplate { get; set; }
    }
}