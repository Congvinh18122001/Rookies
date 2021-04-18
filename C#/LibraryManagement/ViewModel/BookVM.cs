using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
namespace LibraryManagement.Models
{
    public class BookVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int CategoryID { get; set; }
    }
}