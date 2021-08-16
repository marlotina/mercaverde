using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MS.CommandQuery.Core.Entities.Common;
using MS.CommandQuery.Core.Entities.Location;
using MS.CommandQuery.Core.Entities.Users;

namespace MS.CommandQuery.Core.Entities.Product
{
    [Table("TblStore")]
    public partial class Store
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Store()
        {
            StoreComments = new HashSet<StoreComment>();
            StoreDescriptions = new HashSet<StoreDescription>();
            StoreImages = new HashSet<StoreImage>();
            Categories = new HashSet<Category>();
            Labels = new HashSet<Label>();
        }

        [Key]
        public int IdStore { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string PrefixPhone { get; set; }

        public string MobilePhone { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? PublishDate { get; set; }

        public DateTime? RevisedDate { get; set; }

        [StringLength(250)]
        public string UrlWebSite { get; set; }

        public bool Validate { get; set; }

        public DateTime LastActivity { get; set; }

        public string Street { get; set; }

        public string StreetComplete { get; set; }

        public string PostalCode { get; set; }

        public string Number { get; set; }

        public int? CityId { get; set; }

        public int? DistrictId { get; set; }

        [StringLength(150)]
        public string TimeTable { get; set; }

        public int UserId { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public bool IsPublished { get; set; }

        public bool IsRevised { get; set; }

        public bool Deleted { get; set; }

        [StringLength(150)]
        public string Neighborhood { get; set; }

        public virtual City City { get; set; }

        public virtual District District { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StoreComment> StoreComments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StoreDescription> StoreDescriptions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StoreImage> StoreImages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Category> Categories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Label> Labels { get; set; }
    }
}
