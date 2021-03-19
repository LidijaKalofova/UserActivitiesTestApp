using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UserActivitiesTestApp.Domain.Entities;

namespace UserActivitiesTestApp.DAL
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Activity>()
                .HasOne(act => act.User)
                .WithMany(us => us.Activity);

            builder.Entity<Activity>()
                .Property(x => x.Id).HasDefaultValueSql("NewSequentialId()");
        }
    }
}
