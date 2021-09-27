using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedAsync(ApplicationDbContext dbContext)
        {
            if (await dbContext.Categories.AnyAsync() || await dbContext.Brands.AnyAsync() || await dbContext.Products.AnyAsync()) return;

            var cat1 = new Category() { CategoryName = "Mens" };
            var cat2 = new Category() { CategoryName = "Ladies" };
            var cat3 = new Category() { CategoryName = "Unisex" };
            dbContext.AddRange(cat1, cat2, cat3);
             
            var brand1 = new Brand() { BrandName = "Olivia Burton"};
            var brand2 = new Brand() { BrandName = "Swatch"};
            var brand3 = new Brand() { BrandName = "Gucci"};
            var brand4 = new Brand() { BrandName = "Raymond Weil"};
            dbContext.AddRange(brand1, brand2, brand3, brand4);

            var p1 = new Product() { ProductName = "OLIVIA BURTON ICE QUEEN WATCH OB16IQ01", Description = "Swarovski Cosmic Rock Bangle 5376080 is an amazing and eye-catching Ladies watch.Material of the case is Silver Plated and the Off white dial gives the watch that unique look. ", Price = 69.00m, PicturePath = "1.jpg", Category = cat2, Brand = brand1 };
            var p2 = new Product() { ProductName = "SWATCH ONCE AGAIN WATCH", Description = "This ever popular Swatch Once Again watch proves that simple is always effective.", Price = 46.00m, PicturePath = "2.jpg", Category = cat3, Brand = brand2 };
            var p3 = new Product() { ProductName = "LADIES SWATCH GREENBELLE WATCH LG129", Description = "Swatch Greenbelle LG129 is an incredibly attractive Ladies watch from Original Lady collection.", Price = 46.00m, PicturePath = "3.jpg", Category = cat2, Brand = brand2 };
            var p4 = new Product() { ProductName = "SWATCH BLACK-ONE WATCH SUSB416", Description = "Sporty BLACK-ONE (SUSB416) goes the extra mile with chronograph functions. The pushers, crown and sub - dials are colored in blue, red and yellow.", Price = 99.00m, PicturePath = "4.jpg", Category = cat1, Brand = brand2 };
            var p5 = new Product() { ProductName = "GUCCI WATCH YA1264094", Description = "Gucci G-Timeless Slim YA1264094 is an amazing and attractive Ladies watch from G-Timeless Slim collection.", Price = 1720.00m, PicturePath = "5.jpg", Category = cat2, Brand = brand3 };
            var p6 = new Product() { ProductName = "GUCCI WATCH YA1264086", Description = "Material of the case is Stainless Steel, which stands for a high quality of the item and the Black mother of pearl dial gives the watch that unique look.", Price = 1513.00m, PicturePath = "6.jpg", Category = cat2, Brand = brand3 };
            var p7 = new Product() { ProductName = "MENS GUCCI G-TIMELESS SLIM MOONPHASE WATCH YA126327", Description = "Material of the case is Stainless Steel and the Black dial gives the watch that unique look. The features of the watch include(among others) a date function. ", Price = 1595.00m, PicturePath = "7.jpg", Category = cat1, Brand = brand3 };
            var p8 = new Product() { ProductName = "GUCCI WATCH YA126338", Description = "Gucci Eyrx YA126338 is a functional and attractive Gents watch from Eyrx collection.", Price = 1260.00m, PicturePath = "8.jpg", Category = cat1, Brand = brand3 };
            var p9 = new Product() { ProductName = "RAYMOND WEIL WATCH 8160-ST-00508", Description = "Raymond Weil Toccata 8160-ST-00508 is a functional and attractive Gents watch.", Price = 1356.00m, PicturePath = "9.jpg", Category = cat1, Brand = brand4 };
            var p10 = new Product() { ProductName = "MENS RAYMOND WEIL TOCCATA WATCH 5488-ST-20001", Description = "Material of the case is Stainless Steel, which stands for a high quality of the item and the Black dial gives the watch that unique look. ", Price = 895.00m, PicturePath = "10.jpg", Category = cat1, Brand = brand4 };
            var p11 = new Product() { ProductName = "LADIES RAYMOND WEIL TANGO DIAMOND WATCH 5960-STS-00995", Description = "Raymond Weil Tango 5960-STS-00995 is a beautiful and attractive Ladies watch. ", Price = 695.00m, PicturePath = "11.jpg", Category = cat2, Brand = brand4 };
            var p12 = new Product() { ProductName = "RAYMOND WEIL WATCH 5985-ST-50081", Description = "Raymond Weil 5985-ST-50081is a beautiful and attractive Ladies watch. ", Price = 795.00m, PicturePath = "12.jpg", Category = cat2, Brand = brand4 };
            dbContext.AddRange(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12);

            await dbContext.SaveChangesAsync();
        }
    }
}
