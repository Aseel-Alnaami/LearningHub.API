using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LearningHub.Core.Data
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Categoryy> Categoryys { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Login> Logins { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductCustomer> ProductCustomers { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Role1> Roles1 { get; set; } = null!;
        public virtual DbSet<Stdcourse> Stdcourses { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<UserLogin> UserLogins { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=DESKTOP-6PHK2D8)(PORT=1521))(CONNECT_DATA=(SID=xe)));User Id=C##Asil; Password=711;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("C##ASIL")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Idcat)
                    .HasName("SYS_C008388");

                entity.ToTable("CATEGORY");

                entity.Property(e => e.Idcat)
                    .HasColumnType("NUMBER")
                    .HasColumnName("IDCAT")
                    .HasDefaultValueSql("\"C##ASIL\".\"CATEGORY_SEQ\".\"NEXTVAL\"");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORY_NAME");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE_PATH");
            });

            modelBuilder.Entity<Categoryy>(entity =>
            {
                entity.HasKey(e => e.Categoryid)
                    .HasName("SYS_C008510");

                entity.ToTable("CATEGORYY");

                entity.Property(e => e.Categoryid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CATEGORYID");

                entity.Property(e => e.Categoryname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORYNAME");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("COURSE");

                entity.Property(e => e.Courseid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("COURSEID");

                entity.Property(e => e.Categoryid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CATEGORYID");

                entity.Property(e => e.Coursename)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("COURSENAME");

                entity.Property(e => e.Enddate)
                    .HasColumnType("DATE")
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.Imagename)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IMAGENAME");

                entity.Property(e => e.Price)
                    .HasColumnType("NUMBER(10,2)")
                    .HasColumnName("PRICE");

                entity.Property(e => e.Startdate)
                    .HasColumnType("DATE")
                    .HasColumnName("STARTDATE");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.Categoryid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CATEGORYID");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Idcos)
                    .HasName("SYS_C008384");

                entity.ToTable("CUSTOMER");

                entity.Property(e => e.Idcos)
                    .HasColumnType("NUMBER")
                    .HasColumnName("IDCOS")
                    .HasDefaultValueSql("\"C##ASIL\".\"CUSTOMER_SEQ\".\"NEXTVAL\"");

                entity.Property(e => e.Fname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FNAME");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE_PATH");

                entity.Property(e => e.Lname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LNAME");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("LOGIN");

                entity.Property(e => e.Loginid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("LOGINID");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Studentid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("STUDENTID");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.Roleid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ROLEID");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.Studentid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_STUDENTID");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Idpro)
                    .HasName("SYS_C008389");

                entity.ToTable("PRODUCT");

                entity.Property(e => e.Idpro)
                    .HasColumnType("NUMBER")
                    .HasColumnName("IDPRO")
                    .HasDefaultValueSql("\"C##ASIL\".\"PRODUCT_SEQ\".\"NEXTVAL\"");

                entity.Property(e => e.CategoryId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CATEGORY_ID");

                entity.Property(e => e.Namee)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAMEE");

                entity.Property(e => e.Price)
                    .HasColumnType("FLOAT")
                    .HasColumnName("PRICE");

                entity.Property(e => e.Sale)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SALE");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008390");
            });

            modelBuilder.Entity<ProductCustomer>(entity =>
            {
                entity.ToTable("PRODUCT_CUSTOMER");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ID")
                    .HasDefaultValueSql("\"C##ASIL\".\"PRODUCT_CUSTOMER_SEQ\".\"NEXTVAL\"");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("DATE")
                    .HasColumnName("DATE_FROM");

                entity.Property(e => e.DateTo)
                    .HasColumnType("DATE")
                    .HasColumnName("DATE_TO");

                entity.Property(e => e.ProductId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PRODUCT_ID");

                entity.Property(e => e.Quantity)
                    .HasColumnType("NUMBER")
                    .HasColumnName("QUANTITY");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ProductCustomers)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008393");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductCustomers)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008392");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Idrol)
                    .HasName("SYS_C008387");

                entity.ToTable("ROLES");

                entity.Property(e => e.Idrol)
                    .HasColumnType("NUMBER")
                    .HasColumnName("IDROL")
                    .HasDefaultValueSql("\"C##ASIL\".\"ROLES_SEQ\".\"NEXTVAL\"");

                entity.Property(e => e.Rolename)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ROLENAME");
            });

            modelBuilder.Entity<Role1>(entity =>
            {
                entity.HasKey(e => e.Roleid)
                    .HasName("SYS_C008497");

                entity.ToTable("ROLE");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Rolename)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ROLENAME");
            });

            modelBuilder.Entity<Stdcourse>(entity =>
            {
                entity.ToTable("STDCOURSE");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Courseid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COURSEID");

                entity.Property(e => e.Dateofregister)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEOFREGISTER");

                entity.Property(e => e.Markofstd)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MARKOFSTD");

                entity.Property(e => e.Stid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("STID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Stdcourses)
                    .HasForeignKey(d => d.Courseid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_STDCOURSE");

                entity.HasOne(d => d.St)
                    .WithMany(p => p.Stdcourses)
                    .HasForeignKey(d => d.Stid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_STD");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("STUDENT");

                entity.Property(e => e.Studentid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("STUDENTID");

                entity.Property(e => e.Dateofbirth)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEOFBIRTH");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FIRSTNAME");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LASTNAME");

                entity.Property(e => e.Marks)
                    .HasColumnType("NUMBER(10,2)")
                    .HasColumnName("MARKS");
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.HasKey(e => e.Iduser)
                    .HasName("SYS_C008385");

                entity.ToTable("USER_LOGIN");

                entity.Property(e => e.Iduser)
                    .HasColumnType("NUMBER")
                    .HasColumnName("IDUSER")
                    .HasDefaultValueSql("\"C##ASIL\".\"USER_LOGIN_SEQ\".\"NEXTVAL\"");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.RoleId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ROLE_ID");

                entity.Property(e => e.UserName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("USER_NAME");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.UserLogins)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008386");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserLogins)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ROLE_ID");
            });

            modelBuilder.HasSequence("CATEGORY_SEQ");

            modelBuilder.HasSequence("CUSTOMER_SEQ");

            modelBuilder.HasSequence("PRODUCT_CUSTOMER_SEQ");

            modelBuilder.HasSequence("PRODUCT_SEQ");

            modelBuilder.HasSequence("ROLES_SEQ");

            modelBuilder.HasSequence("USER_LOGIN_SEQ");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
