namespace Flash.Club13.Data.Migrations
{
    using Flash.Club13.Models;
    using Flash.Club13.Models.Enums;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<MainDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(MainDbContext context)
        {
            var userStore = new UserStore<User>(context);
            var userManager = new UserManager<User>(userStore);

            if (!context.Users.Any(x => x.UserName == "admin@admin.com"))
            {
                var user = new User { UserName = "admin@admin.com", Email = "admin@admin.com" };
                userManager.Create(user, "123456");

                var member = new Member();
                member.FirstName = "Pesho";
                member.LastName = "Peshov";
                member.Gender = Gender.Male;
                member.UserId = user.Id;

                context.Members.Add(member);
                context.SaveChanges();

                var role = new IdentityRole { Name = "Admin" };
                var roleTwo = new IdentityRole { Name = "User" };

                context.Roles.AddOrUpdate(x => x.Name, role);
                context.Roles.AddOrUpdate(x => x.Name, roleTwo);
                context.SaveChanges();

                userManager.AddToRole(user.Id, "Admin");
            }
        }
    }
}
