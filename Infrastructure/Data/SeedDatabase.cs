using Core.Entities;
using Infrastructue.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class SeedDatabase
    {
        public static async Task SeedingDb(StoreContext storeContext)
        {

            if (!await storeContext.ProductTypes.AnyAsync())
            {
                var typesJson = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                var types = JsonConvert.DeserializeObject<List<ProductType>>(typesJson);

                await storeContext.ProductTypes.AddRangeAsync(types);
            }
            if (!await storeContext.ProductBrands.AnyAsync())
            {
                var brandsJson = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                var brands = JsonConvert.DeserializeObject<List<ProductBrand>>(brandsJson);

                await storeContext.ProductBrands.AddRangeAsync(brands);
            }

            if (!await storeContext.Products.AnyAsync())
            {
                var productJson = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                var products = JsonConvert.DeserializeObject<List<Product>>(productJson);

                await storeContext.Products.AddRangeAsync(products);
            }
            if (storeContext.ChangeTracker.HasChanges())
            {
                await storeContext.SaveChangesAsync();
            }

        }
    }
}
