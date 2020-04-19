using Redis.NETCore.Entities;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Redis.NETCore
{
    class Program
    {
        static void Main()
        {
            const string hostServer = "127.0.0.1:6379";
            Seed(hostServer);
            Console.WriteLine("Hello!\nWhat do you want to look for?\n1-Products \n2-Categories  ");
            int categoryOption = short.Parse(Console.ReadLine());
            string pattern = "*";
            switch (categoryOption)
            {
                case 1:
                    pattern = "product: *";
                    ReadData<Product>(hostServer, pattern);
                    break;
                case 2:
                    pattern = "category: *";

                    ReadData<Category>(hostServer, pattern);
                    break;
                default:
                    throw new Exception("Invalid option!");
            }

            Console.ReadKey();
        }

        private static List<string> ReadData<T>(string hostServer, string pattern)
        {
            List<string> keys;
            using (var redisClient = new RedisClient(hostServer))
            {
                keys = redisClient.GetKeysByPattern(pattern).ToList();

                foreach (var item in keys)
                {
                    T data = redisClient.Get<T>(item);
                    Console.WriteLine(data.ToString());
                }
            }
            return keys;
        }

        private static void Seed(string hostServer)
        {
            using var redisClient = new RedisClient(hostServer);
            if (!redisClient.GetKeysByPattern("category: *").Any())
            {
                Category category1 = new Category("Books");
                Category category2 = new Category("Games");
                Product product1 = new Product("Clean Code", 100.99, category1);
                Product product2 = new Product("Rainbow Six Siege", 79.99, category2);
                redisClient.Set<Category>($"category: {category1.Id}", category1);
                redisClient.Set<Category>($"category: {category2.Id}", category2);
                redisClient.Set<Product>($"product: {product1.Id}", product1);
                redisClient.Set<Product>($"product: {product2.Id}", product2);
            }
        }
    }
}
