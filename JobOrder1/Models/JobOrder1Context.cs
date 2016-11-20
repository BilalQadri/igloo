using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JobOrder1.Models
{
    public class JobOrder1Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public JobOrder1Context() : base("name=JobOrder1Context")
        {
            // New code:
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public System.Data.Entity.DbSet<JobOrder1.Models.Author> Authors { get; set; }

        public System.Data.Entity.DbSet<JobOrder1.Models.Book> Books { get; set; }

        public System.Data.Entity.DbSet<JobOrder1.Models.Topic> Topics { get; set; }

        public System.Data.Entity.DbSet<JobOrder1.Models.Session> Sessions { get; set; }

        public System.Data.Entity.DbSet<JobOrder1.Models.Note> Notes { get; set; }

        public System.Data.Entity.DbSet<JobOrder1.Models.Link> Links { get; set; }

        public System.Data.Entity.DbSet<JobOrder1.Models.Image> Images { get; set; }

        public System.Data.Entity.DbSet<JobOrder1.Models.Text> Texts { get; set; }

        public System.Data.Entity.DbSet<JobOrder1.Models.History> Histories { get; set; }

        public System.Data.Entity.DbSet<JobOrder1.Models.Statuse> Statuses { get; set; }
    }
}
