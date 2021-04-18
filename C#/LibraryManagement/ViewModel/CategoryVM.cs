using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
namespace LibraryManagement.Models
{
    public class CategoryVM
    {
        public int ID { get; set; }
        public string Name { get; set; }

    }
}