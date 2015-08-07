namespace HireAProToday.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HireAProToday.Models.ApplicationDbContext>
    {
        private readonly bool _pendingMigrations;

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "HireAProToday.Models.ApplicationDbContext";

            var migrator = new DbMigrator(this);
            _pendingMigrations = migrator.GetPendingMigrations().Any();
        }

        protected override void Seed(HireAProToday.Models.ApplicationDbContext context)
        {
            if (!_pendingMigrations) return;

            // TODO: load the member directory and any other static database data that's needed...
            // TODO: how are we going to handle asp.net users and roles? don't want them getting re-set...maybe not a problem...

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
        }
    }
}
