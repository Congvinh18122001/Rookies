using System;
using System.Collections.Generic;
namespace LibraryManagement.Models
{
    public class Borrowing
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public List<Book> Books { get; set; }
    }
}