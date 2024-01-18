namespace test.Models
{
    public class ProductSampleData
    {
        List<Product> products;
        public ProductSampleData() { 
        products = new List<Product>();
            products.Add(new Product { Id = 1, Name = "iphone", Price = 10000, Image = "download.jpg", Description = "phone" });
            products.Add(new Product { Id = 2, Name = "iphone", Price = 10000, Image = "PhotoScan.jpg", Description = "phone" });
            products.Add(new Product { Id = 3, Name = "iphone", Price = 10000, Image = "1.jpg", Description = "phone" });
            products.Add(new Product { Id = 4, Name = "iphone", Price = 10000, Image = "1.jpg", Description = "phone" });
            products.Add(new Product { Id = 5, Name = "iphone", Price = 10000, Image = "1.jpg", Description = "phone" });

        }
        public List<Product> GetAll() { 
        return products;
        
        }
        public Product GetById(int id)
        {
            return products.FirstOrDefault(p=>p.Id==id);
        }

    }
}
