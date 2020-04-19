using eShopSolution.Data.Entities;
using eShopSolution.Data.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(
                new AppConfig() { Key = "HomeTitle", Value = "This's HomePage" },
                new AppConfig() { Key = "HomeTitle1", Value = "This's HomePage1" },
                new AppConfig() { Key = "HomeTitle2", Value = "This's HomePage2" }
                );

            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = 1,Name = "vi-VN", IsDefault = true },
                new Language() { Id= 2 ,Name = "en-US", IsDefault = true }
                );


            modelBuilder.Entity<Category>().HasData(
               new Category()
               {
                   Id = 1,
                   SortOrder = 1,
                   IsShowOnHome = true,
                   ParentId = null,
                   Status = Status.Active,
                   
               },
                new Category()
                {
                    Id=2,
                    SortOrder = 2,
                    IsShowOnHome = true,
                    ParentId = null,
                    Status = Status.Active,
                   
                }
                ) ;

            modelBuilder.Entity<CategoryTranslation>().HasData(
                 new List<CategoryTranslation>() {
                                    new CategoryTranslation() {
                                        Id= 1,
                                        CategoryId=1,
                                        Name = "Áo nam",
                                        LanguageId = 1,
                                        SeoAlias = "ao-nam",
                                        SeoDescription = "Sản phẩm áo thời trang nam",
                                        SeoTitle = "Sản phẩm áo thời trang nam" },
                                    new CategoryTranslation() {
                                        Id=2,
                                        CategoryId=1,
                                        Name = "Men-Shỉt",
                                        LanguageId = 2,
                                        SeoAlias = "Menshirt",
                                        SeoDescription = "Shirt for men",
                                        SeoTitle = "Shirt for men" },
                                   
                                    new CategoryTranslation() {
                                        Id=3,
                                        CategoryId=2,
                                        Name = "Áo nữ",
                                        LanguageId = 1,
                                        SeoAlias = "ao-nu",
                                        SeoDescription = "Sản phẩm áo thời trang nữ",
                                        SeoTitle = "Sản phẩm áo thời trang nũ" },
                                    new CategoryTranslation() {
                                        Id=4,
                                        CategoryId=2,
                                        Name = "Women shirt",
                                        LanguageId = 2,
                                        SeoAlias = "women-shirt",
                                        SeoDescription = "Shirt for Women",
                                        SeoTitle = "Shirt for Women" }
                                   }

                );

            modelBuilder.Entity<Product>().HasData(
               new Product()
               {
                   Id=1,
                   DateCreated = DateTime.Now,
                   OriginalPrice = 1000000,
                   Price = 1200000,
                   Stock = 0,
                   ViewCount = 0,
                 
                 
               }
                );

            modelBuilder.Entity<ProductTranslation>().HasData(
                 new ProductTranslation()
                 {
                     Id=1,
                     ProductId =1,
                     Name = "Áo nam sơ mitrắng Việt Tiến",
                     LanguageId = 1,
                     SeoAlias = "ao-nam",
                     SeoDescription = "Áo nam sơ mitrắng Việt Tiến",
                     SeoTitle = "Áo nam sơ mitrắng Việt Tiến",
                     Details = "Áo nam sơ mitrắng Việt Tiến"
                        ,
                     Description = "Áo nam sơ mitrắng Việt Tiến"
                 },
                    new ProductTranslation()
                    {
                        Id=2,
                        ProductId=1,
                        Name = "Viet Tien Men T-Shỉt",
                        LanguageId = 2,
                        SeoAlias = "viet-tien-Menshirt",
                        SeoDescription = "Viet Tien Men T-Shỉt",
                        SeoTitle = "Viet Tien Men T-Shỉt",
                        Details = "Viet Tien Men T-Shỉt",
                        Description = "Viet Tien Men T-Shỉt"
                    }
                );

            modelBuilder.Entity<ProductInCategory>().HasData(
                 new ProductInCategory()
                 {
                     ProductId =1,
                     CategoryId = 1
                 }
                );
            // any guid
            var Admin_Id = new Guid("50E6A4F2-D964-46B0-8AE3-2C944F2E20F8");
            var Role_Id = new Guid("1AD298BD-670E-4C66-B6EE-96B41698FC1E");

            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = Role_Id,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator Role"
            });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = Admin_Id,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "some-admin-email@nonce.fake",
                NormalizedEmail = "some-admin-email@nonce.fake",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "A123456@"),
                SecurityStamp = string.Empty,
                FirstName = "Minh",
                LastName = "Giang",
                Dob = new DateTime(2020,01,01)
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = Role_Id,
                UserId = Admin_Id
            });
        }
    }
}
