using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Resort.Domain.Entities
{
    public partial class ResortSiteDbContext : DbContext
    {
        public ResortSiteDbContext()
        {
        }

        public ResortSiteDbContext(DbContextOptions<ResortSiteDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accessibility> Accessibility { get; set; }
        public virtual DbSet<AccessibilityName> AccessibilityName { get; set; }
        public virtual DbSet<Accommodation> Accommodation { get; set; }
        public virtual DbSet<AccommodationAmenity> AccommodationAmenity { get; set; }
        public virtual DbSet<AccommodationHouseRule> AccommodationHouseRule { get; set; }
        public virtual DbSet<AccommodationImage> AccommodationImage { get; set; }
        public virtual DbSet<AccommodationType> AccommodationType { get; set; }
        public virtual DbSet<Amenity> Amenity { get; set; }
        public virtual DbSet<CardType> CardType { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<ExtraInformation> ExtraInformation { get; set; }
        public virtual DbSet<Feature> Feature { get; set; }
        public virtual DbSet<HouseRule> HouseRule { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<LoginHistory> LoginHistory { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethod { get; set; }
        public virtual DbSet<PhoneNumber> PhoneNumber { get; set; }
        public virtual DbSet<Rating> Rating { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<SocialMedia> SocialMedia { get; set; }
        public virtual DbSet<Type> Type { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=178.128.61.230;Database=ResortSite;Username=resortsite;Password=P@$$w0rdE");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Accessibility>(entity =>
            {
                entity.HasKey(e => e.AccommodationId)
                    .HasName("Accessibility_pkey");

                entity.ToTable("Accessibility", "accommodation");

                entity.Property(e => e.AccommodationId)
                    .HasColumnName("AccommodationID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccessibilityNameId).HasColumnName("AccessibilityNameID");

                entity.Property(e => e.Description).HasColumnType("character varying");

                entity.HasOne(d => d.AccessibilityName)
                    .WithMany(p => p.Accessibility)
                    .HasForeignKey(d => d.AccessibilityNameId)
                    .HasConstraintName("Accessibility_AccessibilityNameID_fkey");

                entity.HasOne(d => d.Accommodation)
                    .WithOne(p => p.Accessibility)
                    .HasForeignKey<Accessibility>(d => d.AccommodationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Accessibility_AccommodationID_fkey");
            });

            modelBuilder.Entity<AccessibilityName>(entity =>
            {
                entity.ToTable("AccessibilityName", "accommodation");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('accommodation.\"AccessibilityName_ID_seq\"'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Accommodation>(entity =>
            {
                entity.ToTable("Accommodation", "accommodation");

                entity.HasIndex(e => e.CategoryId)
                    .HasName("Accommodation_CategoryID_key")
                    .IsUnique();

                entity.HasIndex(e => e.LocationId)
                    .HasName("Accommodation_LocationID_key")
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .HasName("Accommodation_Name_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('accommodation.\"Accommodation_ID_seq\"'::regclass)");

                entity.Property(e => e.AccessibilitySizeDescription).HasColumnType("character varying");

                entity.Property(e => e.AccommodationTypeId).HasColumnName("AccommodationTypeID");

                entity.Property(e => e.CancellationPolicy).HasColumnType("character varying");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.DateAdded).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Description).HasColumnType("character varying");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.Name).HasColumnType("character varying");

                entity.Property(e => e.PricePerNight).HasColumnType("numeric");

                entity.HasOne(d => d.AccommodationType)
                    .WithMany(p => p.Accommodation)
                    .HasForeignKey(d => d.AccommodationTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Accommodation_AccommodationTypeID_fkey");

                entity.HasOne(d => d.Category)
                    .WithOne(p => p.Accommodation)
                    .HasForeignKey<Accommodation>(d => d.CategoryId)
                    .HasConstraintName("Accommodation_CategoryID_fkey");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Accommodation)
                    .HasForeignKey<Accommodation>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Accommodation_ID_fkey");

                entity.HasOne(d => d.Location)
                    .WithOne(p => p.Accommodation)
                    .HasForeignKey<Accommodation>(d => d.LocationId)
                    .HasConstraintName("Accommodation_LocationID_fkey");
            });

            modelBuilder.Entity<AccommodationAmenity>(entity =>
            {
                entity.HasKey(e => e.AccommodationId)
                    .HasName("AccommodationAmenity_pkey");

                entity.ToTable("AccommodationAmenity", "accommodation");

                entity.Property(e => e.AccommodationId)
                    .HasColumnName("AccommodationID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AmenityId).HasColumnName("AmenityID");

                entity.HasOne(d => d.Accommodation)
                    .WithOne(p => p.AccommodationAmenity)
                    .HasForeignKey<AccommodationAmenity>(d => d.AccommodationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("AccommodationAmenity_AccommodationID_fkey");

                entity.HasOne(d => d.Amenity)
                    .WithMany(p => p.AccommodationAmenity)
                    .HasForeignKey(d => d.AmenityId)
                    .HasConstraintName("AccommodationAmenity_AmenityID_fkey");
            });

            modelBuilder.Entity<AccommodationHouseRule>(entity =>
            {
                entity.HasKey(e => e.AccommodationId)
                    .HasName("AccommodationHouseRule_pkey");

                entity.ToTable("AccommodationHouseRule", "accommodation");

                entity.Property(e => e.AccommodationId)
                    .HasColumnName("AccommodationID")
                    .ValueGeneratedNever();

                entity.Property(e => e.HouseRuleDescription).HasColumnType("character varying");

                entity.Property(e => e.HouseRuleId).HasColumnName("HouseRuleID");

                entity.HasOne(d => d.Accommodation)
                    .WithOne(p => p.AccommodationHouseRule)
                    .HasForeignKey<AccommodationHouseRule>(d => d.AccommodationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("AccommodationHouseRule_AccommodationID_fkey");

                entity.HasOne(d => d.HouseRule)
                    .WithMany(p => p.AccommodationHouseRule)
                    .HasForeignKey(d => d.HouseRuleId)
                    .HasConstraintName("AccommodationHouseRule_HouseRuleID_fkey");
            });

            modelBuilder.Entity<AccommodationImage>(entity =>
            {
                entity.HasKey(e => e.AccommodationId)
                    .HasName("AccommodationImage_pkey");

                entity.ToTable("AccommodationImage", "accommodation");

                entity.Property(e => e.AccommodationId)
                    .HasColumnName("AccommodationID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Images).HasColumnType("character varying");
            });

            modelBuilder.Entity<AccommodationType>(entity =>
            {
                entity.ToTable("AccommodationType", "accommodation");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('accommodation.\"AccommodationType_ID_seq\"'::regclass)");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Amenity>(entity =>
            {
                entity.ToTable("Amenity", "accommodation");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('accommodation.\"Amenity_ID_seq\"'::regclass)");

                entity.Property(e => e.Description).HasColumnType("character varying");

                entity.Property(e => e.Images).HasColumnType("character varying");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<CardType>(entity =>
            {
                entity.ToTable("CardType", "customer");

                entity.HasIndex(e => e.Type)
                    .HasName("CardType_Type_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('customer.\"CardType_ID_seq\"'::regclass)");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category", "category");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('category.\"Category_ID_seq\"'::regclass)");

                entity.Property(e => e.Created).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Description).HasColumnType("character varying");

                entity.Property(e => e.Modify).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Name).HasColumnType("character varying");

                entity.Property(e => e.Status).HasColumnType("character varying");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer", "customer");

                entity.HasIndex(e => e.Email)
                    .HasName("Customer_Email_key")
                    .IsUnique();

                entity.HasIndex(e => e.Password)
                    .HasName("Customer_Password_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('customer.\"Customer_ID_seq\"'::regclass)");

                entity.Property(e => e.About).HasColumnType("character varying");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.LastSeen).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.ProfilePhoto).HasColumnType("character varying");

                entity.Property(e => e.RegisteredDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.Property(e => e.VerificationStatus)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Customer_TypeID_fkey");
            });

            modelBuilder.Entity<ExtraInformation>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("ExtraInformation_pkey");

                entity.ToTable("ExtraInformation", "customer");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("CustomerID")
                    .ValueGeneratedNever();

                entity.Property(e => e.EmergencyContact).HasColumnType("character varying");

                entity.Property(e => e.Occupation).HasColumnType("character varying");

                entity.Property(e => e.School).HasColumnType("character varying");

                entity.Property(e => e.TimeZone).HasColumnType("character varying");

                entity.Property(e => e.Work).HasColumnType("character varying");

                entity.HasOne(d => d.Customer)
                    .WithOne(p => p.ExtraInformation)
                    .HasForeignKey<ExtraInformation>(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ExtraInformation_CustomerID_fkey");
            });

            modelBuilder.Entity<Feature>(entity =>
            {
                entity.ToTable("Feature", "accommodation");

                entity.HasIndex(e => e.AccommodationId)
                    .HasName("Feature_AccommodationID_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('accommodation.\"Feature_ID_seq\"'::regclass)");

                entity.Property(e => e.AccommodationId).HasColumnName("AccommodationID");

                entity.Property(e => e.CoverImage).HasColumnType("character varying");

                entity.Property(e => e.Description).HasColumnType("character varying");

                entity.Property(e => e.Image).HasColumnType("character varying");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.HasOne(d => d.Accommodation)
                    .WithOne(p => p.Feature)
                    .HasForeignKey<Feature>(d => d.AccommodationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Feature_AccommodationID_fkey");
            });

            modelBuilder.Entity<HouseRule>(entity =>
            {
                entity.ToTable("HouseRule", "accommodation");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('accommodation.\"HouseRule_ID_seq\"'::regclass)");

                entity.Property(e => e.Name).HasColumnType("character varying");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location", "accommodation");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('accommodation.\"Location_ID_seq\"'::regclass)");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.Description).HasColumnType("character varying");

                entity.Property(e => e.Distance).HasColumnType("character varying");

                entity.Property(e => e.DistanceDescription).HasColumnType("character varying");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<LoginHistory>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("LoginHistory_pkey");

                entity.ToTable("LoginHistory", "customer");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("CustomerID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Browser).HasColumnType("character varying");

                entity.Property(e => e.Date).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Device).HasColumnType("character varying");

                entity.Property(e => e.Ip)
                    .HasColumnName("IP")
                    .HasColumnType("character varying");

                entity.Property(e => e.RecentActivity).HasColumnType("character varying");

                entity.HasOne(d => d.Customer)
                    .WithOne(p => p.LoginHistory)
                    .HasForeignKey<LoginHistory>(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("LoginHistory_CustomerID_fkey");
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PaymentMethod_pkey");

                entity.ToTable("PaymentMethod", "customer");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("CustomerID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CardHolderName)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.CardTypeId).HasColumnName("CardTypeID");

                entity.Property(e => e.IssuingBank)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.HasOne(d => d.CardType)
                    .WithMany(p => p.PaymentMethod)
                    .HasForeignKey(d => d.CardTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PaymentMethod_CardTypeID_fkey");

                entity.HasOne(d => d.Customer)
                    .WithOne(p => p.PaymentMethod)
                    .HasForeignKey<PaymentMethod>(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PaymentMethod_CustomerID_fkey");
            });

            modelBuilder.Entity<PhoneNumber>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PhoneNumber_pkey");

                entity.ToTable("PhoneNumber", "customer");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("CustomerID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Phone).HasColumnType("character varying");

                entity.HasOne(d => d.Customer)
                    .WithOne(p => p.PhoneNumber)
                    .HasForeignKey<PhoneNumber>(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PhoneNumber_CustomerID_fkey");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.HasKey(e => e.AccommodationId)
                    .HasName("Rating_pkey");

                entity.ToTable("Rating", "accommodation");

                entity.Property(e => e.AccommodationId)
                    .HasColumnName("AccommodationID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Comment).HasColumnType("character varying");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Date).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Modified).HasColumnType("timestamp with time zone");

                entity.HasOne(d => d.Accommodation)
                    .WithOne(p => p.Rating)
                    .HasForeignKey<Rating>(d => d.AccommodationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Rating_AccommodationID_fkey");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Rating)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Rating_CustomerID_fkey");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.ToTable("Reservation", "accommodation");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('accommodation.\"Reservation_ID_seq\"'::regclass)");

                entity.Property(e => e.AccommodationId).HasColumnName("AccommodationID");

                entity.Property(e => e.AmountPaid).HasColumnType("numeric");

                entity.Property(e => e.CheckIn).HasColumnType("date");

                entity.Property(e => e.CheckOut).HasColumnType("date");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.RefundPaid).HasColumnType("numeric");

                entity.Property(e => e.Status).HasColumnType("character varying");

                entity.HasOne(d => d.Accommodation)
                    .WithMany(p => p.Reservation)
                    .HasForeignKey(d => d.AccommodationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Reservation_AccommodationID_fkey");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Reservation)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Reservation_CustomerID_fkey");
            });

            modelBuilder.Entity<SocialMedia>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("SocialMedia_pkey");

                entity.ToTable("SocialMedia", "customer");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("CustomerID")
                    .ValueGeneratedNever();

                entity.Property(e => e.FacebookId).HasColumnName("FacebookID");

                entity.Property(e => e.InstagramId).HasColumnName("InstagramID");

                entity.Property(e => e.PinterestId).HasColumnName("PinterestID");

                entity.Property(e => e.SnapchatId).HasColumnName("SnapchatID");

                entity.Property(e => e.TwitterId).HasColumnName("TwitterID");

                entity.HasOne(d => d.Customer)
                    .WithOne(p => p.SocialMedia)
                    .HasForeignKey<SocialMedia>(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SocialMedia_CustomerID_fkey");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.ToTable("Type", "customer");

                entity.HasIndex(e => e.Type1)
                    .HasName("Type_Type_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('customer.\"Type_ID_seq\"'::regclass)");

                entity.Property(e => e.Type1)
                    .IsRequired()
                    .HasColumnName("Type")
                    .HasColumnType("character varying");
            });

            modelBuilder.HasSequence("AccessibilityName_ID_seq");

            modelBuilder.HasSequence("Accommodation_ID_seq");

            modelBuilder.HasSequence("AccommodationType_ID_seq");

            modelBuilder.HasSequence("Amenity_ID_seq");

            modelBuilder.HasSequence("Feature_ID_seq");

            modelBuilder.HasSequence("HouseRule_ID_seq");

            modelBuilder.HasSequence("Location_ID_seq");

            modelBuilder.HasSequence("Reservation_ID_seq");

            modelBuilder.HasSequence("Category_ID_seq");

            modelBuilder.HasSequence("CardType_ID_seq");

            modelBuilder.HasSequence("Customer_ID_seq");

            modelBuilder.HasSequence("Type_ID_seq");
        }
    }
}
