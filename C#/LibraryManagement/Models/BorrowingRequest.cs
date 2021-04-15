using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
namespace LibraryManagement.Models
{
    public class BorrowingRequest
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual User User { get; set; }
        public DateTime RequestAt { get; set; }
        public int Status { get; set; }
        public virtual ICollection<RequestDetail> RequestDetails { get; set; }
    }
}
