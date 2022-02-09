using Microsoft.EntityFrameworkCore;
using PocoPanel.Application.Interfaces;
using PocoPanel.Domain.Common;
using PocoPanel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PocoPanel.Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IDateTimeService _dateTime;
        private readonly IAuthenticatedUserService _authenticatedUser;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTimeService dateTime, IAuthenticatedUserService authenticatedUser) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dateTime = dateTime;
            _authenticatedUser = authenticatedUser;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = _dateTime.NowUtc;
                        entry.Entity.CreatedBy = _authenticatedUser.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = _dateTime.NowUtc;
                        entry.Entity.LastModifiedBy = _authenticatedUser.UserId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region decimal
            //All Decimals will have 18,6 Range
            foreach (var property in builder.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(18,6)");
            }
            #endregion

            builder.Entity<tblPriceKind>()
            .Property(et => et.Id)
            .ValueGeneratedNever();

            builder.Entity<tblProductKind>()
            .Property(et => et.Id)
            .ValueGeneratedNever();

            builder.Entity<tblStatus>()
            .Property(et => et.Id)
            .ValueGeneratedNever();

            builder.Entity<tblProduct>()
            .Property(et => et.IsDelete)
            .HasDefaultValue(false);

            #region Seed Data

            #region tblPriceKind
            builder.Entity<tblPriceKind>().HasData(
                new tblPriceKind() { Id = 1, Name = "Rial" },
                new tblPriceKind() { Id = 2, Name = "USD" }
                );
            #endregion

            #region tblPriceKind
            builder.Entity<tblProductKind>().HasData(
                //Main Services
                new tblProductKind() { Id = 1, Name = "Telegram" },
                new tblProductKind() { Id = 2, Name = "Instagram" },

                //Parent Services
                 //Telegram
                new tblProductKind() { Id = 3, Name = "Member", ParentID = 1 },
                new tblProductKind() { Id = 4, Name = "Like", ParentID = 1 },
                new tblProductKind() { Id = 5, Name = "Comment", ParentID = 1 },
                new tblProductKind() { Id = 6, Name = "View", ParentID = 1 },
                 //Instagram
                new tblProductKind() { Id = 7, Name = "Follower", ParentID = 2 },
                new tblProductKind() { Id = 8, Name = "Like", ParentID = 2 },
                new tblProductKind() { Id = 9, Name = "Comment", ParentID = 2 }
                );
            #endregion

             #region tblStatus
            builder.Entity<tblStatus>().HasData(
                new tblStatus() { Id = 1, Name = "Waiting" },
                new tblStatus() { Id = 2, Name = "Accepted" },
                new tblStatus() { Id = 3, Name = "Rejected" },
                new tblStatus() { Id = 4, Name = "Completed" },
                new tblStatus() { Id = 5, Name = "Unknown" }
                );
            #endregion

            #endregion

            #region Query Filter
            builder.Entity<tblProduct>().HasQueryFilter(p => !p.IsDelete);
            #endregion

            base.OnModelCreating(builder);
        }

        #region Tables
        public DbSet<tblProduct> tblProduct { get; set; }
        public DbSet<tblProductKind> tblProductKind { get; set; }
        public DbSet<tblCountry> tblCountry { get; set; }
        public DbSet<tblDiscount> tblDiscount { get; set; }
        public DbSet<tblOrder> tblOrder { get; set; }
        public DbSet<tblOrderDetail> tblOrderDetail { get; set; }
        public DbSet<tblPriceKind> tblPriceKind { get; set; }
        public DbSet<tblProductPriceKind> tblProductPriceKind { get; set; }
        public DbSet<tblProvider> tblProvider { get; set; }
        public DbSet<tblStatus> tblStatus {get; set;}
        #endregion
    }
}
