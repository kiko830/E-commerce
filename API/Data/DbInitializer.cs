using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DbInitializer
{
    public static async Task InitDb(WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<StoreContext>()
            ?? throw new InvalidOperationException("Failed to retrieve store context");
        
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>()
            ?? throw new InvalidOperationException("Failed to retrieve user manager");

         await SeedData(context, userManager);

    }
        private static async Task SeedData(StoreContext context, UserManager<User> userManager)
    {
        context.Database.Migrate();

        if (!userManager.Users.Any())
        {
            var user = new User
            {
                UserName = "bob@test.com",
                Email = "bob@test.com"
            };

            await userManager.CreateAsync(user, "Pa$$w0rd");
            await userManager.AddToRoleAsync(user, "User");

            var admin = new User
            {
                UserName = "admin@test.com",
                Email = "admin@test.com"
            };

            await userManager.CreateAsync(admin, "Pa$$w0rd");
            await userManager.AddToRolesAsync(admin,["User", "Admin"]);
        }

        if (context.Products.Any()) return;

        var products = new List<Product>
        {
            new() {
            Name = "Fjallraven - Foldsack No. 1 Backpack, Fits 15 Laptops",
            Description = "Your perfect pack for everyday use and walks in the forest. Stash your laptop (up to 15 inches) in the padded sleeve, your everyday",
            Price = 10995,
            PictureUrl = "https://fakestoreapi.com/img/81fPKd-2AYL._AC_SL1500_t.png",
            Brand = "Fjallraven",
            Type = "men's clothing",
            QuantityInStock = 120
        },
        new() {
            Name = "Mens Casual Premium Slim Fit T-Shirts",
            Description = "Slim-fitting style, contrast raglan long sleeve, three-button henley placket, light weight & soft fabric for breathable and comfortable wearing. And Solid stitched shirts with round neck made for durability and a great fit for casual fashion wear and diehard baseball fans. The Henley style round neckline includes a three-button placket.",
            Price = 2230,
            PictureUrl = "https://fakestoreapi.com/img/71-3HjGNDUL._AC_SY879._SX._UX._SY._UY_t.png",
            Brand = "Premium",
            Type = "men's clothing",
            QuantityInStock = 259
        },
        new() {
            Name = "Mens Cotton Jacket",
            Description = "great outerwear jackets for Spring/Autumn/Winter, suitable for many occasions, such as working, hiking, camping, mountain/rock climbing, cycling, traveling or other outdoors. Good gift choice for you or your family member. A warm hearted love to Father, husband or son in this thanksgiving or Christmas Day.",
            Price = 5599,
            PictureUrl = "https://fakestoreapi.com/img/71li-ujtlUL._AC_UX679_t.png",
            Brand = "Cotton Jacket",
            Type = "men's clothing",
            QuantityInStock = 500
        },
        new() {
            Name = "Mens Casual Slim Fit",
            Description = "The color could be slightly different between on the screen and in practice. / Please note that body builds vary by person, therefore, detailed size information should be reviewed below on the product description.",
            Price = 1599,
            PictureUrl = "https://fakestoreapi.com/img/71YXzeOuslL._AC_UY879_t.png",
            Brand = "Casual",
            Type = "men's clothing",
            QuantityInStock = 430
        },
        new() {
            Name = "John Hardy Women's Legends Naga Gold & Silver Dragon Station Chain Bracelet",
            Description = "From our Legends Collection, the Naga was inspired by the mythical water dragon that protects the ocean's pearl. Wear facing inward to be bestowed with love and abundance, or outward for protection.",
            Price = 69500,
            PictureUrl = "https://fakestoreapi.com/img/71pWzhdJNwL._AC_UL640_QL65_ML3_t.png",
            Brand = "John Hardy",
            Type = "jewelery",
            QuantityInStock = 400
        },
        new() {
            Name = "Solid Gold Petite Micropave",
            Description = "Satisfaction Guaranteed. Return or exchange any order within 30 days.Designed and sold by Hafeez Center in the United States. Satisfaction Guaranteed. Return or exchange any order within 30 days.",
            Price = 16800,
            PictureUrl = "https://fakestoreapi.com/img/61sbMiUnoGL._AC_UL640_QL65_ML3_t.png",
            Brand = "Hafeez Center",
            Type = "jewelery",
            QuantityInStock = 70
        },
        new() {
            Name = "White Gold Plated Princess",
            Description = "Classic Created Wedding Engagement Solitaire Diamond Promise Ring for Her. Gifts to spoil your love more for Engagement, Wedding, Anniversary, Valentine's Day...",
            Price = 999,
            PictureUrl = "https://fakestoreapi.com/img/71YAIFU48IL._AC_UL640_QL65_ML3_t.png",
            Brand = "Princess",
            Type = "jewelery",
            QuantityInStock = 400
        },
        new() {
            Name = "Pierced Owl Rose Gold Plated Stainless Steel Double",
            Description = "Rose Gold Plated Double Flared Tunnel Plug Earrings. Made of 316L Stainless Steel",
            Price = 1099,
            PictureUrl = "https://fakestoreapi.com/img/51UDEzMJVpL._AC_UL640_QL65_ML3_t.png",
            Brand = "Pierced Owl",
            Type = "jewelery",
            QuantityInStock = 100
        },
        new() {
            Name = "WD 2TB Elements Portable External Hard Drive - USB 3.0",
            Description = "USB 3.0 and USB 2.0 Compatibility Fast data transfers Improve PC Performance High Capacity; Compatibility Formatted NTFS for Windows 10, Windows 8.1, Windows 7; Reformatting may be required for other operating systems; Compatibility may vary depending on user’s hardware configuration and operating system",
            Price = 6400,
            PictureUrl = "https://fakestoreapi.com/img/61IBBVJvSDL._AC_SY879_t.png",
            Brand = "WD",
            Type = "electronics",
            QuantityInStock = 203
        },
        new() {
            Name = "SanDisk SSD PLUS 1TB Internal SSD - SATA III 6 Gb/s",
            Description = "Easy upgrade for faster boot up, shutdown, application load and response (As compared to 5400 RPM SATA 2.5” hard drive; Based on published specifications and internal benchmarking tests using PCMark vantage scores) Boosts burst write performance, making it ideal for typical PC workloads The perfect balance of performance and reliability Read/write speeds of up to 535MB/s/450MB/s (Based on internal testing; Performance may vary depending upon drive capacity, host device, OS and application.)",
            Price = 10900,
            PictureUrl = "https://fakestoreapi.com/img/61U7T1koQqL._AC_SX679_t.png",
            Brand = "SanDisk",
            Type = "electronics",
            QuantityInStock = 470
        },
        new() {
            Name = "Silicon Power 256GB SSD 3D NAND A55 SLC Cache Performance Boost SATA III 2.5",
            Description = "3D NAND flash are applied to deliver high transfer speeds Remarkable transfer speeds that enable faster bootup and improved overall system performance. The advanced SLC Cache Technology allows performance boost and longer lifespan 7mm slim design suitable for Ultrabooks and Ultra-slim notebooks. Supports TRIM command, Garbage Collection technology, RAID, and ECC (Error Checking & Correction) to provide the optimized performance and enhanced reliability.",
            Price = 10900,
            PictureUrl = "https://fakestoreapi.com/img/71kWymZ+c+L._AC_SX679_t.png",
            Brand = "Silicon Power",
            Type = "electronics",
            QuantityInStock = 319
        },
        new() {
            Name = "WD 4TB Gaming Drive Works with Playstation 4 Portable External Hard Drive",
            Description = "Expand your PS4 gaming experience, Play anywhere Fast and easy, setup Sleek design with high capacity, 3-year manufacturer's limited warranty",
            Price = 11400,
            PictureUrl = "https://fakestoreapi.com/img/61mtL65D4cL._AC_SX679_t.png",
            Brand = "WD",
            Type = "electronics",
            QuantityInStock = 400
        },
        new() {
            Name = "Acer SB220Q bi 21.5 inches Full HD (1920 x 1080) IPS Ultra-Thin",
            Description = "21.5 inches Full HD (1920 x 1080) widescreen IPS display And Radeon free Sync technology. No compatibility for VESA Mount Refresh Rate: 75Hz - Using HDMI port Zero-frame design | ultra-thin | 4ms response time | IPS panel Aspect ratio - 16:9. Color Supported - 16.7 million colors. Brightness - 250 nit Tilt angle -5 degree to 15 degree. Horizontal viewing angle-178 degree. Vertical viewing angle-178 degree 75 hertz",
            Price = 59900,
            PictureUrl = "https://fakestoreapi.com/img/81QpkIctqPL._AC_SX679_t.png",
            Brand = "Acer",
            Type = "electronics",
            QuantityInStock = 250
        },
        new() {
            Name = "Samsung 49-Inch CHG90 144Hz Curved Gaming Monitor (LC49HG90DMNXZA) – Super Ultrawide Screen QLED",
            Description = "49 INCH SUPER ULTRAWIDE 32:9 CURVED GAMING MONITOR with dual 27 inch screen side by side QUANTUM DOT (QLED) TECHNOLOGY, HDR support and factory calibration provides stunningly realistic and accurate color and contrast 144HZ HIGH REFRESH RATE and 1ms ultra fast response time work to eliminate motion blur, ghosting, and reduce input lag",
            Price = 99999,
            PictureUrl = "https://fakestoreapi.com/img/81Zt42ioCgL._AC_SX679_t.png",
            Brand = "Samsung",
            Type = "electronics",
            QuantityInStock = 140
        },
        new() {
            Name = "BIYLACLESEN Women's 3-in-1 Snowboard Jacket Winter Coats",
            Description = "Note:The Jackets is US standard size, Please choose size as your usual wear Material: 100% Polyester; Detachable Liner Fabric: Warm Fleece. Detachable Functional Liner: Skin Friendly, Lightweigt and Warm.Stand Collar Liner jacket, keep you warm in cold weather. Zippered Pockets: 2 Zippered Hand Pockets, 2 Zippered Pockets on Chest (enough to keep cards or keys)and 1 Hidden Pocket Inside.Zippered Hand Pockets and Hidden Pocket keep your things secure. Humanized Design: Adjustable and Detachable Hood and Adjustable cuff to prevent the wind and water,for a comfortable fit. 3 in 1 Detachable Design provide more convenience, you can separate the coat and inner as needed, or wear it together. It is suitable for different season and help you adapt to different climates",
            Price = 5699,
            PictureUrl = "https://fakestoreapi.com/img/51Y5NI-I5jL._AC_UX679_t.png",
            Brand = "BIYLACLESEN",
            Type = "women's clothing",
            QuantityInStock = 235
        },
        new() {
            Name = "Lock and Love Women's Removable Hooded Faux Leather Moto Biker Jacket",
            Description = "100% POLYURETHANE(shell) 100% POLYESTER(lining) 75% POLYESTER 25% COTTON (SWEATER), Faux leather material for style and comfort / 2 pockets of front, 2-For-One Hooded denim style faux leather jacket, Button detail on waist / Detail stitching at sides, HAND WASH ONLY / DO NOT BLEACH / LINE DRY / DO NOT IRON",
            Price = 2995,
            PictureUrl = "https://fakestoreapi.com/img/81XH0e8fefL._AC_UY879_t.png",
            Brand = "Lock and Love",
            Type = "women's clothing",
            QuantityInStock = 340
        },
        new() {
            Name = "Rain Jacket Women Windbreaker Striped Climbing Raincoats",
            Description = "Lightweight perfet for trip or casual wear---Long sleeve with hooded, adjustable drawstring waist design. Button and zipper front closure raincoat, fully stripes Lined and The Raincoat has 2 side pockets are a good size to hold all kinds of things, it covers the hips, and the hood is generous but doesn't overdo it.Attached Cotton Lined Hood with Adjustable Drawstrings give it a real styled look.",
            Price = 3999,
            PictureUrl = "https://fakestoreapi.com/img/71HblAHs5xL._AC_UY879_-2t.png",
            Brand = "Windbreaker",
            Type = "women's clothing",
            QuantityInStock = 679
        },
        new() {
            Name = "MBJ Women's Solid Short Sleeve Boat Neck V",
            Description = "95% RAYON 5% SPANDEX, Made in USA or Imported, Do Not Bleach, Lightweight fabric with great stretch for comfort, Ribbed on sleeves and neckline / Double stitching on bottom hem",
            Price = 985,
            PictureUrl = "https://fakestoreapi.com/img/71z3kpMAYsL._AC_UY879_t.png",
            Brand = "MBJ",
            Type = "women's clothing",
            QuantityInStock = 130
        },
        new() {
            Name = "Opna Women's Short Sleeve Moisture",
            Description = "100% Polyester, Machine wash, 100% cationic polyester interlock, Machine Wash & Pre Shrunk for a Great Fit, Lightweight, roomy and highly breathable with moisture wicking fabric which helps to keep moisture away, Soft Lightweight Fabric with comfortable V-neck collar and a slimmer fit, delivers a sleek, more feminine silhouette and Added Comfort",
            Price = 795,
            PictureUrl = "https://fakestoreapi.com/img/51eg55uWmdL._AC_UX679_t.png",
            Brand = "Opna",
            Type = "women's clothing",
            QuantityInStock = 146
        },
        new() {
            Name = "DANVOUY Womens T Shirt Casual Cotton Short",
            Description = "95%Cotton,5%Spandex, Features: Casual, Short Sleeve, Letter Print,V-Neck,Fashion Tees, The fabric is soft and has some stretch., Occasion: Casual/Office/Beach/School/Home/Street. Season: Spring,Summer,Autumn,Winter.",
            Price = 1299,
            PictureUrl = "https://fakestoreapi.com/img/61pHAEJ4NML._AC_UX679_t.png",
            Brand = "DANVOUY",
            Type = "women's clothing",
            QuantityInStock = 145
        },
        };

        context.Products.AddRange(products);

        context.SaveChanges();
    }
}
