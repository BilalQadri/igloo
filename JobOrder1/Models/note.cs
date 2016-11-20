using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobOrder1.Models
{
    public class Note
    {
        public int Id { get; set; }
        [Required]
        public string Data { get; set; }

        // foreign keys
        public int SessionId { get; set; }

        // naviagtion properties
        public Session Session { get; set; }
    }
}