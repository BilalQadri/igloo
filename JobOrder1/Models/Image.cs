using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobOrder1.Models
{
    public class Image
    {
        public int Id { get; set; }
        [Required]
        public string Src { get; set; }

        // foreign key
        public int SessionId { get; set; }

        // navigation property

        public Session Session { get; set; }
    }
}