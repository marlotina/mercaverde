using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MS.CommandQuery.Core.Entities.CMS
{
    [Table("TblText")]
    public partial class Text
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Text()
        {
            TextLanguage = new HashSet<TextLanguage>();
        }

        [Key]
        public int IdText { get; set; }

        [StringLength(300)]
        public string Name { get; set; }

        [StringLength(300)]
        public string Label { get; set; }

        [StringLength(100)]
        public string String { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TextLanguage> TextLanguage { get; set; }
    }
}
