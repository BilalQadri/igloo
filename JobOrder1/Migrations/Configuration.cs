namespace JobOrder1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using JobOrder1.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<JobOrder1.Models.JobOrder1Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(JobOrder1.Models.JobOrder1Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Topics.AddOrUpdate(t => t.Id,
                new Topic () { Id=1, Name= "TOP Level", ParentId=0}
                );
            context.Sessions.AddOrUpdate(t => t.Id,
                new Session () { Id=1, Name= "sessionId01", TopicId=1 }
                );
            context.Notes.AddOrUpdate(t => t.Id,
                new Note () { Id=1, Data="My first Note.", SessionId=1}
                );
        }
    }
}
