using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
namespace LibraryManagement.Models
{
    public enum StatusRequest
    {
        Pending,
        Approved,
        Rejected
    }
    public class Borrowing
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public List<int> ListBookID { get; set; }
        public StatusRequest Status { get; set; } = 0;

    }
}