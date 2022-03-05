using ePerfume.Data.Entities;
using ePerfume.Data.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePerfume.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(
                new AppConfig() { Key = "HomeTitle", Value = "This is home page of ePerfume" },
                new AppConfig() { Key = "HomeKeyword", Value = "This is key word of ePerfume" },
                new AppConfig() { Key = "HomeDescription", Value = "This is desscription of ePerfume" }
            );

            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = "vi-VN", Name = "Tiếng Việt", IsDefault = true},
                new Language() { Id = "en-US", Name = "Enghlish", IsDefault = false }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category() {
                    Id = 1,
                    IsShowOnHome = true,                
                    ParentId = null,
                    SortOrder = 1,
                    Status = Status.Active,
                }
            );
            modelBuilder.Entity<Category>().HasData(
                new Category(){
                    Id = 2,
                    IsShowOnHome = true,
                    ParentId = null,
                    SortOrder = 2,
                    Status = Status.Active,
                }
            );

            modelBuilder.Entity<CategoryTranslation>().HasData(
                new CategoryTranslation()
                {
                    Id = 1,
                    CategoryId = 1,
                    Name = "Áo Nam",
                    LanguageId = "vi-VN",
                    SeoAlias = "Sản phẩm áo thời trang nam",
                    SeoDescription = "Sản phẩm áo thời trang nam"
                },
                new CategoryTranslation()
                {
                    Id = 2,
                    CategoryId = 1,
                    Name = "Men Shirt",
                    LanguageId = "en-US",
                    SeoAlias = "The Shirt products for men",
                    SeoDescription = "The Shirt products for men"
                },
                new CategoryTranslation()
                {
                    Id = 3,
                    CategoryId = 2,
                    Name = "Áo Nữ",
                    LanguageId = "vi-VN",
                    SeoAlias = "Sản phẩm áo thời trang nữ",
                    SeoDescription = "Sản phẩm áo thời trang nữ"
                },
                new CategoryTranslation()
                {
                    Id = 4,
                    CategoryId = 2,
                    Name = "Women Shirt",
                    LanguageId = "en-US",
                    SeoAlias = "The Shirt products for women",
                    SeoDescription = "The Shirt products for women"
                }
            );            

            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    OriginalPrice = 100000,
                    Price = 200000,
                    Stock = 0,
                    ViewCount = 0,
                    SeoAlias = ""
                }
            );

            modelBuilder.Entity<ProductTranslation>().HasData(
                new ProductTranslation()
                {
                    Id = 1,
                    ProductId = 1,
                    Name = "Áo sơ mi nam trắng Việt Tiến",
                    LanguageId = "vi-VN",
                    SeoAlias = "ao-so-mi-nam-trang-nam-viet-tien",
                    SeoDescription = "Áo sơ mi nam trắng Việt Tiến",
                    SeoTitle = "Áo sơ mi nam trắng Việt Tiến",
                    Details = "Áo sơ mi nam trắng Việt Tiến",
                    Description = ""
                },
                new ProductTranslation()
                {
                    Id = 2,
                    ProductId = 1,
                    Name = "Viet Tien Men T-Shirt",
                    LanguageId = "en-US",
                    SeoAlias = "Viet-Tien-Men-T-Shirt",
                    SeoDescription = "Viet Tien Men T-Shirt",
                    SeoTitle = "Viet Tien Men T-Shirt",
                    Details = "Viet Tien Men T-Shirt",
                    Description = "Viet Tien Men T-Shirt"
                }
            );

            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory() {ProductId = 1, CategoryId = 1 }
            );

            // any guid
            var ADMIN_ID = new Guid("888584D2-49CD-4D36-88A2-170751C7DCA5");
            // any guid, but nothing is against to use the same one
            var ROLE_ID = new Guid("24973248-499C-4855-9D60-D56BD75B3BA5");

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = ROLE_ID,
                Name = "admin",
                Desccription = "Administrator role",
                NormalizedName = "admin"
            });

            var hasher = new PasswordHasher<User>();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = ADMIN_ID,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "ngodaiduong116@gmail.com",
                NormalizedEmail = "ngodaiduong116@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Qwe123456$"),
                SecurityStamp = string.Empty,
                FirstName = "Duong",
                LastName =  "Ngo Dai",
                Dob = new DateTime(1999,06,11)
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });

        }
    }
}
