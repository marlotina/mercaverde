using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MS.CommandQuery.Core.Entities.CMS;
using MS.CommandQuery.Core.Entities.Location;
using MS.CommandQuery.Core.Entities.Product;
using MS.CommandQuery.Core.Entities.Users;

namespace MS.CommandQuery.Core.Entities.Common
{
    [Table("TblLanguage")]
    public partial class Language
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Language()
        {
            //BrandComments = new HashSet<BrandComment>();
            //BrandDescriptions = new HashSet<BrandDescription>();
            CategoryLanguages = new HashSet<CategoryLanguage>();
            CityLanguages = new HashSet<CityLanguage>();
            CountryLanguages = new HashSet<CountryLanguage>();
            LabelLanguages = new HashSet<LabelLanguage>();
            Posts = new HashSet<Post>();
            StoreDescriptions = new HashSet<StoreDescription>();
            TextLanguages = new HashSet<TextLanguage>();
            Users = new HashSet<User>();
            Event = new HashSet<Event>();
            News = new HashSet<NewsItem>();
            MailTemplateLanguages = new HashSet<MailTemplateLanguage>();
        }

        [Key]
        public int IdLanguage { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public bool? Published { get; set; }

        [StringLength(100)]
        public string Icon { get; set; }

        [StringLength(50)]
        public string URL { get; set; }

        [StringLength(50)]
        public string Charset { get; set; }

        public short? Order { get; set; }

        [StringLength(10)]
        public string URLFolder { get; set; }

        [StringLength(50)]
        public string Domain { get; set; }

        [StringLength(50)]
        public string CultureName { get; set; }

        [StringLength(10)]
        public string Folder { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<BrandComment> BrandComments { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<BrandDescription> BrandDescriptions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CategoryLanguage> CategoryLanguages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CityLanguage> CityLanguages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CountryLanguage> CountryLanguages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LabelLanguage> LabelLanguages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Post> Posts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StoreDescription> StoreDescriptions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TextLanguage> TextLanguages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Event> Event { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NewsItem> News { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MailTemplateLanguage> MailTemplateLanguages { get; set; }
    }
}
