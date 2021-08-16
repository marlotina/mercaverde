using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MS.CommandQuery.Core.Entities.Common;
using MS.CommandQuery.Core.Entities.Location;
using MS.CommandQuery.Core.Entities.Users;

namespace MS.CommandQuery.Core.Entities.Product
{
    [Table("Brand")]
    public partial class Brand
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Brand()
        {
            BrandComments = new HashSet<BrandComment>();
            BrandDescriptions = new HashSet<BrandDescription>();
            BrandImages = new HashSet<BrandImage>();
            Categories = new HashSet<Category>();
            Labels = new HashSet<Label>();
        }

        [Key]
        public int IdBrand { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string PrefixPhone { get; set; }

        public DateTime CreationDate { get; set; }

        public bool Published { get; set; }

        public bool Validate { get; set; }

        public DateTime LastActivity { get; set; }

        public string Street { get; set; }

        public string PostalCode { get; set; }

        public string Number { get; set; }

        [StringLength(250)]
        public string UrlWebSite { get; set; }

        public int? CityId { get; set; }

        public int? DistrictId { get; set; }

        public int UserId { get; set; }

        public virtual City City { get; set; }

        public virtual District District { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BrandComment> BrandComments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BrandDescription> BrandDescriptions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BrandImage> BrandImages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Category> Categories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Label> Labels { get; set; }
    }
}
