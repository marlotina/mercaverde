using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MS.CommandQuery.Core.Entities.Users;

namespace MS.CommandQuery.Core.Entities.Tasks
{
    [Table("TblTaskProcess")]
    public partial class TaskProcess
    {
        [Key]
        public int IdTaskProcess { get; set; }

        public int TaskProcessType { get; set; }

        public int Status { get; set; }

        public int? UserId { get; set; }

        public virtual User User { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public int Attempts { get; set; }
    }
}