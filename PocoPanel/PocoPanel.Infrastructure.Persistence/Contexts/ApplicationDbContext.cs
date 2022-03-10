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
                        if (string.IsNullOrWhiteSpace(entry.Entity.CreatedBy))
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
            #region DateTime
            foreach (var entity in builder.Model.GetEntityTypes())
            {
                var dateTimeProps = entity.GetProperties()
                    .Where(p => p.PropertyInfo.PropertyType == typeof(DateTime));
                foreach (var prop in dateTimeProps)
                {
                    builder.Entity(entity.Name).Property(prop.Name).HasColumnType("datetime2");
                }

            }
            #endregion

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

            #region tblCountry
            builder.Entity<tblCountry>().HasData(
                new tblCountry() { Id = 1, Name = "Afghanistan" },
new tblCountry() { Id = 2, Name = "Åland Islands" },
new tblCountry() { Id = 3, Name = "Albania" },
new tblCountry() { Id = 4, Name = "Algeria" },
new tblCountry() { Id = 5, Name = "American Samoa" },
new tblCountry() { Id = 6, Name = "Andorra" },
new tblCountry() { Id = 7, Name = "Angola" },
new tblCountry() { Id = 8, Name = "Anguilla" },
new tblCountry() { Id = 9, Name = "Antarctica" },
new tblCountry() { Id = 10, Name = "Antigua and Barbuda" },
new tblCountry() { Id = 12, Name = "Argentina" },
new tblCountry() { Id = 13, Name = "Armenia" },
new tblCountry() { Id = 14, Name = "Aruba" },
new tblCountry() { Id = 15, Name = "Australia" },
new tblCountry() { Id = 16, Name = "Austria" },
new tblCountry() { Id = 17, Name = "Azerbaijan" },
new tblCountry() { Id = 18, Name = "Bahrain" },
new tblCountry() { Id = 19, Name = "Bahamas" },
new tblCountry() { Id = 20, Name = "Bangladesh" },
new tblCountry() { Id = 21, Name = "Barbados" },
new tblCountry() { Id = 22, Name = "Belarus" },
new tblCountry() { Id = 23, Name = "Belgium" },
new tblCountry() { Id = 24, Name = "Belize" },
new tblCountry() { Id = 25, Name = "Benin" },
new tblCountry() { Id = 26, Name = "Bermuda" },
new tblCountry() { Id = 27, Name = "Bhutan" },
new tblCountry() { Id = 28, Name = "Bolivia, Plurinational State of" },
new tblCountry() { Id = 29, Name = "Bonaire, Sint Eustatius and Saba" },
new tblCountry() { Id = 30, Name = "Bosnia and Herzegovina" },
new tblCountry() { Id = 31, Name = "Botswana" },
new tblCountry() { Id = 32, Name = "Bouvet Island" },
new tblCountry() { Id = 33, Name = "Brazil" },
new tblCountry() { Id = 34, Name = "British Indian Ocean Territory" },
new tblCountry() { Id = 35, Name = "Brunei Darussalam" },
new tblCountry() { Id = 36, Name = "Bulgaria" },
new tblCountry() { Id = 37, Name = "Burkina Faso" },
new tblCountry() { Id = 38, Name = "Burundi" },
new tblCountry() { Id = 39, Name = "Cambodia" },
new tblCountry() { Id = 40, Name = "Cameroon" },
new tblCountry() { Id = 41, Name = "Canada" },
new tblCountry() { Id = 42, Name = "Cape Verde" },
new tblCountry() { Id = 43, Name = "Cayman Islands" },
new tblCountry() { Id = 44, Name = "Central African Republic" },
new tblCountry() { Id = 45, Name = "Chad" },
new tblCountry() { Id = 46, Name = "Chile" },
new tblCountry() { Id = 47, Name = "China" },
new tblCountry() { Id = 48, Name = "Christmas Island" },
new tblCountry() { Id = 49, Name = "Cocos (Keeling) Islands" },
new tblCountry() { Id = 50, Name = "Colombia" },
new tblCountry() { Id = 51, Name = "Comoros" },
new tblCountry() { Id = 52, Name = "Congo" },
new tblCountry() { Id = 53, Name = "Congo, the Democratic Republic of the" },
new tblCountry() { Id = 54, Name = "Cook Islands" },
new tblCountry() { Id = 55, Name = "Costa Rica" },
new tblCountry() { Id = 56, Name = "Côte d'Ivoire" },
new tblCountry() { Id = 57, Name = "Croatia" },
new tblCountry() { Id = 58, Name = "Cuba" },
new tblCountry() { Id = 59, Name = "Curaçao" },
new tblCountry() { Id = 60, Name = "Cyprus" },
new tblCountry() { Id = 61, Name = "Czech Republic" },
new tblCountry() { Id = 62, Name = "Denmark" },
new tblCountry() { Id = 63, Name = "Djibouti" },
new tblCountry() { Id = 64, Name = "Dominica" },
new tblCountry() { Id = 65, Name = "Dominican Republic" },
new tblCountry() { Id = 66, Name = "Ecuador" },
new tblCountry() { Id = 67, Name = "Egypt" },
new tblCountry() { Id = 68, Name = "El Salvador" },
new tblCountry() { Id = 69, Name = "Equatorial Guinea" },
new tblCountry() { Id = 70, Name = "Eritrea" },
new tblCountry() { Id = 71, Name = "Estonia" },
new tblCountry() { Id = 72, Name = "Ethiopia" },
new tblCountry() { Id = 73, Name = "Falkland Islands (Malvinas)" },
new tblCountry() { Id = 74, Name = "Faroe Islands" },
new tblCountry() { Id = 75, Name = "Fiji" },
new tblCountry() { Id = 76, Name = "Finland" },
new tblCountry() { Id = 77, Name = "France" },
new tblCountry() { Id = 78, Name = "French Guiana" },
new tblCountry() { Id = 79, Name = "French Polynesia" },
new tblCountry() { Id = 80, Name = "French Southern Territories" },
new tblCountry() { Id = 81, Name = "Gabon" },
new tblCountry() { Id = 82, Name = "Gambia" },
new tblCountry() { Id = 83, Name = "Georgia" },
new tblCountry() { Id = 84, Name = "Germany" },
new tblCountry() { Id = 85, Name = "Ghana" },
new tblCountry() { Id = 86, Name = "Gibraltar" },
new tblCountry() { Id = 87, Name = "Greece" },
new tblCountry() { Id = 88, Name = "Greenland" },
new tblCountry() { Id = 89, Name = "Grenada" },
new tblCountry() { Id = 90, Name = "Guadeloupe" },
new tblCountry() { Id = 91, Name = "Guam" },
new tblCountry() { Id = 92, Name = "Guatemala" },
new tblCountry() { Id = 93, Name = "Guernsey" },
new tblCountry() { Id = 94, Name = "Guinea" },
new tblCountry() { Id = 95, Name = "Guinea-Bissau" },
new tblCountry() { Id = 96, Name = "Guyana" },
new tblCountry() { Id = 97, Name = "Haiti" },
new tblCountry() { Id = 98, Name = "Heard Island and McDonald Islands" },
new tblCountry() { Id = 99, Name = "Holy See (Vatican City State)" },
new tblCountry() { Id = 100, Name = "Honduras" },
new tblCountry() { Id = 101, Name = "Hong Kong" },
new tblCountry() { Id = 102, Name = "Hungary" },
new tblCountry() { Id = 103, Name = "Iceland" },
new tblCountry() { Id = 104, Name = "India" },
new tblCountry() { Id = 105, Name = "Indonesia" },
new tblCountry() { Id = 106, Name = "Iran, Islamic Republic of" },
new tblCountry() { Id = 107, Name = "Iraq" },
new tblCountry() { Id = 108, Name = "Ireland" },
new tblCountry() { Id = 109, Name = "Isle of Man" },
new tblCountry() { Id = 110, Name = "Israel" },
new tblCountry() { Id = 111, Name = "Italy" },
new tblCountry() { Id = 112, Name = "Jamaica" },
new tblCountry() { Id = 113, Name = "Japan" },
new tblCountry() { Id = 114, Name = "Jersey" },
new tblCountry() { Id = 115, Name = "Jordan" },
new tblCountry() { Id = 116, Name = "Kazakhstan" },
new tblCountry() { Id = 117, Name = "Kenya" },
new tblCountry() { Id = 118, Name = "Kiribati" },
new tblCountry() { Id = 119, Name = "Korea, Democratic People's Republic of" },
new tblCountry() { Id = 120, Name = "Korea, Republic of" },
new tblCountry() { Id = 121, Name = "Kuwait" },
new tblCountry() { Id = 122, Name = "Kyrgyzstan" },
new tblCountry() { Id = 123, Name = "Lao People's Democratic Republic" },
new tblCountry() { Id = 124, Name = "Latvia" },
new tblCountry() { Id = 125, Name = "Lebanon" },
new tblCountry() { Id = 126, Name = "Lesotho" },
new tblCountry() { Id = 127, Name = "Liberia" },
new tblCountry() { Id = 128, Name = "Libya" },
new tblCountry() { Id = 129, Name = "Liechtenstein" },
new tblCountry() { Id = 130, Name = "Lithuania" },
new tblCountry() { Id = 131, Name = "Luxembourg" },
new tblCountry() { Id = 132, Name = "Macao" },
new tblCountry() { Id = 133, Name = "Macedonia, the Former Yugoslav Republic of" },
new tblCountry() { Id = 134, Name = "Madagascar" },
new tblCountry() { Id = 135, Name = "Malawi" },
new tblCountry() { Id = 136, Name = "Malaysia" },
new tblCountry() { Id = 137, Name = "Maldives" },
new tblCountry() { Id = 138, Name = "Mali" },
new tblCountry() { Id = 139, Name = "Malta" },
new tblCountry() { Id = 140, Name = "Marshall Islands" },
new tblCountry() { Id = 141, Name = "Martinique" },
new tblCountry() { Id = 142, Name = "Mauritania" },
new tblCountry() { Id = 143, Name = "Mauritius" },
new tblCountry() { Id = 144, Name = "Mayotte" },
new tblCountry() { Id = 145, Name = "Mexico" },
new tblCountry() { Id = 146, Name = "Micronesia, Federated States of" },
new tblCountry() { Id = 147, Name = "Moldova, Republic of" },
new tblCountry() { Id = 148, Name = "Monaco" },
new tblCountry() { Id = 149, Name = "Mongolia" },
new tblCountry() { Id = 150, Name = "Montenegro" },
new tblCountry() { Id = 151, Name = "Montserrat" },
new tblCountry() { Id = 152, Name = "Morocco" },
new tblCountry() { Id = 153, Name = "Mozambique" },
new tblCountry() { Id = 154, Name = "Myanmar" },
new tblCountry() { Id = 155, Name = "Namibia" },
new tblCountry() { Id = 156, Name = "Nauru" },
new tblCountry() { Id = 157, Name = "Nepal" },
new tblCountry() { Id = 158, Name = "Netherlands" },
new tblCountry() { Id = 159, Name = "New Caledonia" },
new tblCountry() { Id = 160, Name = "New Zealand" },
new tblCountry() { Id = 161, Name = "Nicaragua" },
new tblCountry() { Id = 162, Name = "Niger" },
new tblCountry() { Id = 163, Name = "Nigeria" },
new tblCountry() { Id = 164, Name = "Niue" },
new tblCountry() { Id = 165, Name = "Norfolk Island" },
new tblCountry() { Id = 166, Name = "Northern Mariana Islands" },
new tblCountry() { Id = 167, Name = "Norway" },
new tblCountry() { Id = 168, Name = "Oman" },
new tblCountry() { Id = 169, Name = "Pakistan" },
new tblCountry() { Id = 170, Name = "Palau" },
new tblCountry() { Id = 171, Name = "Palestine, State of" },
new tblCountry() { Id = 172, Name = "Panama" },
new tblCountry() { Id = 173, Name = "Papua New Guinea" },
new tblCountry() { Id = 174, Name = "Paraguay" },
new tblCountry() { Id = 175, Name = "Peru" },
new tblCountry() { Id = 176, Name = "Philippines" },
new tblCountry() { Id = 177, Name = "Pitcairn" },
new tblCountry() { Id = 178, Name = "Poland" },
new tblCountry() { Id = 179, Name = "Portugal" },
new tblCountry() { Id = 180, Name = "Puerto Rico" },
new tblCountry() { Id = 181, Name = "Qatar" },
new tblCountry() { Id = 182, Name = "Réunion" },
new tblCountry() { Id = 183, Name = "Romania" },
new tblCountry() { Id = 184, Name = "Russian Federation" },
new tblCountry() { Id = 185, Name = "Rwanda" },
new tblCountry() { Id = 186, Name = "Saint Barthélemy" },
new tblCountry() { Id = 187, Name = "Saint Helena, Ascension and Tristan da Cunha" },
new tblCountry() { Id = 188, Name = "Saint Kitts and Nevis" },
new tblCountry() { Id = 189, Name = "Saint Lucia" },
new tblCountry() { Id = 190, Name = "Saint Martin (French part)" },
new tblCountry() { Id = 191, Name = "Saint Pierre and Miquelon" },
new tblCountry() { Id = 192, Name = "Saint Vincent and the Grenadines" },
new tblCountry() { Id = 193, Name = "Samoa" },
new tblCountry() { Id = 194, Name = "San Marino" },
new tblCountry() { Id = 195, Name = "Sao Tome and Principe" },
new tblCountry() { Id = 196, Name = "Saudi Arabia" },
new tblCountry() { Id = 197, Name = "Senegal" },
new tblCountry() { Id = 198, Name = "Serbia" },
new tblCountry() { Id = 199, Name = "Seychelles" },
new tblCountry() { Id = 200, Name = "Sierra Leone" },
new tblCountry() { Id = 201, Name = "Singapore" },
new tblCountry() { Id = 202, Name = "Sint Maarten (Dutch part)" },
new tblCountry() { Id = 203, Name = "Slovakia" },
new tblCountry() { Id = 204, Name = "Slovenia" },
new tblCountry() { Id = 205, Name = "Solomon Islands" },
new tblCountry() { Id = 206, Name = "Somalia" },
new tblCountry() { Id = 207, Name = "South Africa" },
new tblCountry() { Id = 208, Name = "South Georgia and the South Sandwich Islands" },
new tblCountry() { Id = 209, Name = "South Sudan" },
new tblCountry() { Id = 210, Name = "Spain" },
new tblCountry() { Id = 211, Name = "Sri Lanka" },
new tblCountry() { Id = 212, Name = "Sudan" },
new tblCountry() { Id = 213, Name = "Suriname" },
new tblCountry() { Id = 214, Name = "Svalbard and Jan Mayen" },
new tblCountry() { Id = 215, Name = "Swaziland" },
new tblCountry() { Id = 216, Name = "Sweden" },
new tblCountry() { Id = 217, Name = "Switzerland" },
new tblCountry() { Id = 218, Name = "Syrian Arab Republic" },
new tblCountry() { Id = 219, Name = "Taiwan, Province of China" },
new tblCountry() { Id = 220, Name = "Tajikistan" },
new tblCountry() { Id = 221, Name = "Tanzania, United Republic of" },
new tblCountry() { Id = 222, Name = "Thailand" },
new tblCountry() { Id = 223, Name = "Timor-Leste" },
new tblCountry() { Id = 224, Name = "Togo" },
new tblCountry() { Id = 225, Name = "Tokelau" },
new tblCountry() { Id = 226, Name = "Tonga" },
new tblCountry() { Id = 227, Name = "Trinidad and Tobago" },
new tblCountry() { Id = 228, Name = "Tunisia" },
new tblCountry() { Id = 229, Name = "Turkey" },
new tblCountry() { Id = 230, Name = "Turkmenistan" },
new tblCountry() { Id = 231, Name = "Turks and Caicos Islands" },
new tblCountry() { Id = 232, Name = "Tuvalu" },
new tblCountry() { Id = 233, Name = "Uganda" },
new tblCountry() { Id = 234, Name = "Ukraine" },
new tblCountry() { Id = 235, Name = "United Arab Emirates" },
new tblCountry() { Id = 236, Name = "United Kingdom" },
new tblCountry() { Id = 237, Name = "United States" },
new tblCountry() { Id = 238, Name = "United States Minor Outlying Islands" },
new tblCountry() { Id = 239, Name = "Uruguay" },
new tblCountry() { Id = 240, Name = "Uzbekistan" },
new tblCountry() { Id = 241, Name = "Vanuatu" },
new tblCountry() { Id = 242, Name = "Venezuela, Bolivarian Republic of" },
new tblCountry() { Id = 243, Name = "Viet Nam" },
new tblCountry() { Id = 244, Name = "Virgin Islands, British" },
new tblCountry() { Id = 245, Name = "Virgin Islands, U.S." },
new tblCountry() { Id = 246, Name = "Wallis and Futuna" },
new tblCountry() { Id = 247, Name = "Western Sahara" },
new tblCountry() { Id = 248, Name = "Yemen" },
new tblCountry() { Id = 249, Name = "Zambia" },
new tblCountry() { Id = 250, Name = "Zimbabwe" }
              );
            #endregion

            #region tblPriceKind
            builder.Entity<tblPriceKind>().HasData(
                new tblPriceKind() { Id = 1, Name = "Rial", tblCountryId = 106 },
                new tblPriceKind() { Id = 2, Name = "USD", tblCountryId = 237 }
                );
            #endregion

            #region tblProductKind
            builder.Entity<tblProductKind>().HasData(
                //Main Services
                new tblProductKind() { Id = 1, Name = "Telegram" },
                new tblProductKind() { Id = 2, Name = "Instagram" },
                new tblProductKind() { Id = 14, Name = "Other" },
                new tblProductKind() { Id = 16, Name = "Aparat" },
                new tblProductKind() { Id = 20, Name = "ClubHouse" },
                new tblProductKind() { Id = 21, Name = "Spotify" },
                new tblProductKind() { Id = 24, Name = "Unknown" },

                //Parent Services
                //Telegram
                new tblProductKind() { Id = 3, Name = "Member", ParentID = 1 },
                new tblProductKind() { Id = 4, Name = "Like", ParentID = 1 },
                new tblProductKind() { Id = 5, Name = "Comment", ParentID = 1 },
                new tblProductKind() { Id = 6, Name = "View", ParentID = 1 },
                //Instagram
                new tblProductKind() { Id = 7, Name = "Follower", ParentID = 2 },
                new tblProductKind() { Id = 8, Name = "Like", ParentID = 2 },
                new tblProductKind() { Id = 9, Name = "Comment", ParentID = 2 },
                new tblProductKind() { Id = 10, Name = "Story", ParentID = 2 },
                new tblProductKind() { Id = 11, Name = "Live", ParentID = 2 },
                new tblProductKind() { Id = 12, Name = "Save", ParentID = 2 },
                new tblProductKind() { Id = 13, Name = "Other", ParentID = 2 },
                //Other
                new tblProductKind() { Id = 15, Name = "Design", ParentID = 14 },
                //Aparat
                new tblProductKind() { Id = 17, Name = "View", ParentID = 16 }, 
                new tblProductKind() { Id = 18, Name = "Like", ParentID = 16 }, 
                new tblProductKind() { Id = 19, Name = "Follower", ParentID = 16 },
                //ClubHouse
                new tblProductKind() { Id = 22, Name = "Follower", ParentID = 20 },
                //Spotify
                new tblProductKind() { Id = 23, Name = "Listen", ParentID = 21 },
                //Unknown
                new tblProductKind() { Id = 25, Name = "Unknown", ParentID = 24 }
                );
            #endregion

            #region tblStatus
            builder.Entity<tblStatus>().HasData(
                new tblStatus() { Id = 1, Name = "Waiting" },
                new tblStatus() { Id = 2, Name = "Accepted" },
                new tblStatus() { Id = 3, Name = "Rejected" },
                new tblStatus() { Id = 4, Name = "Completed" },
                new tblStatus() { Id = 5, Name = "Unknown" },
                new tblStatus() { Id = 6, Name = "InProgress" },
                new tblStatus() { Id = 7, Name = "Cancled" },
                new tblStatus() { Id = 8, Name = "ReturnedMony" }
                );
            #endregion

            #region tblStatus
            builder.Entity<tblQuality>().HasData(
                new tblQuality() { Id = 1, Name = "Top" },
                new tblQuality() { Id = 2, Name = "middle" },
                new tblQuality() { Id = 3, Name = "low" }
                );
            #endregion

            #region tblProvider
            builder.Entity<tblProvider>().HasData(
                new tblProvider() { Id = 1, Code = "instatell",  Url= "https://instatell.ir/api/v1", DocumentAddress= "https://instatell.ir/api/v1", ProviderToken = "UjXn0H3iBwdj7q9T1P7UiMaB0d6RxsX5", Email = "09904955342", Password = "Pouyapouya800"}
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
        public DbSet<tblStatus> tblStatus { get; set; }
        public DbSet<tblQuality> tblQuality { get; set; }
        #endregion
    }
}
