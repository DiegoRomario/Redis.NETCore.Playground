using Redis.NETCore.Entities;
using ServiceStack.Redis;
using System;

namespace Redis.NETCore
{
    class Program
    {
        static void Main()
        {
            string hostServer = "127.0.0.1:6379";
            Seed(hostServer);
            Console.ReadKey();

        }

        private static void Seed(string hostServer)
        {
            Category category1 = new Category("Book");
            Category category2 = new Category("Games");
            Product product1 = new Product("Clean Code", 100.99, category1);
            Product product2 = new Product("Rainbow Six Siege", 79.99, category2);

            using (var redisClient = new RedisClient(hostServer))
            {
                redisClient.Set<Category>($"category:{category1.Id.ToString()}", category1);
                redisClient.Set<Category>($"category:{category2.Id.ToString()}", category2);
                redisClient.Set<Product>($"product:{product1.Id.ToString()}", product1);
                redisClient.Set<Product>($"product:{product2.Id.ToString()}", product2);
            }
        }
    }
}
