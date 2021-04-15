using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
namespace LibraryManagement.Models
{
    public class RequestDetail
    {
     public int ID { get; set; }
     public int BookID { get; set; }
     [ForeignKey("BookID")]
     public virtual Book Book { get; set; }
     public int RequestID { get; set; }   
     [ForeignKey("RequestID")]
     public virtual BorrowingRequest BorrowingRequest { get; set; }
    }
}