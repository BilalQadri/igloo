using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobOrder1.Models
{
    public class Statuse
    {
        public int Id { get; set; }
        [Required]
        public int CurrentTopic { get; set; }
        public int CurrentSession { get; set; }

    }
}