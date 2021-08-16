using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MS.CommandQuery.Core.Entities.CMS
{
    [Table("TblTextType")]
    public partial class TextType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TextType()
        {
            TextAndTextTypes = new HashSet<TextAndTextTypes>();
        }

        [Key]
        public int IdTextType { get; set; }

        public int? IdPage { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TextAndTextTypes> TextAndTextTypes { get; set; }
    }
}
