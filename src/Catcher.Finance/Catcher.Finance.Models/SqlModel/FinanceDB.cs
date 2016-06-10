//namespace Catcher.Finance.Models.SqlModel
//{
//    using System;
//    using System.Data.Entity;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Linq;

//    public partial class FinanceDB : DbContext
//    {
//        public FinanceDB()
//            : base("name=FinanceDB")
//        {
//        }

//        public virtual DbSet<AdminInfo> AdminInfoes { get; set; }
//        public virtual DbSet<CategoryInfo> CategoryInfoes { get; set; }
//        public virtual DbSet<MoneyInfo> MoneyInfoes { get; set; }
//        public virtual DbSet<UserInfo> UserInfoes { get; set; }

//        protected override void OnModelCreating(DbModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<AdminInfo>()
//                .Property(e => e.AdminName)
//                .IsUnicode(false);

//            modelBuilder.Entity<AdminInfo>()
//                .Property(e => e.AdminPassword)
//                .IsUnicode(false);

//            modelBuilder.Entity<CategoryInfo>()
//                .Property(e => e.CategoryName)
//                .IsUnicode(false);

//            modelBuilder.Entity<CategoryInfo>()
//                .HasMany(e => e.MoneyInfoes)
//                .WithRequired(e => e.CategoryInfo)
//                .HasForeignKey(e => e.MoneyCategoryID)
//                .WillCascadeOnDelete(false);

//            modelBuilder.Entity<MoneyInfo>()
//                .Property(e => e.MoneyType)
//                .IsUnicode(false);

//            modelBuilder.Entity<UserInfo>()
//                .Property(e => e.UserName)
//                .IsUnicode(false);

//            modelBuilder.Entity<UserInfo>()
//                .Property(e => e.UserPassword)
//                .IsUnicode(false);

//            modelBuilder.Entity<UserInfo>()
//                .Property(e => e.UserGender)
//                .IsUnicode(false);

//            modelBuilder.Entity<UserInfo>()
//                .Property(e => e.UserEmail)
//                .IsUnicode(false);

//            modelBuilder.Entity<UserInfo>()
//                .HasMany(e => e.MoneyInfoes)
//                .WithRequired(e => e.UserInfo)
//                .HasForeignKey(e => e.MoneyUID)
//                .WillCascadeOnDelete(false);
//        }
//    }
//}
