using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobOrder1.Models
{ 
    public class Topic
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        public int ParentId { get; set; }
    }
}