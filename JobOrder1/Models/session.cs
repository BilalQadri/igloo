using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobOrder1.Models
{
    public class Session
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        // foreign key
        public int TopicId { get; set; }

        // navigation property
        public Topic Topic { get; set; }
    }
}