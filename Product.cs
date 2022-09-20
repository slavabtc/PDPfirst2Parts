using System;
using baseProg;
namespace baseProg {
public class Product
{
    public string Name {get;set;}
    public string Sku {get;set;}
    public string Price {get;set;}
    public string Type {get;set;}
    public string Descr {get;set;} 
    public string? Weight {get;set;} 
    public string? Country {get;set;}
    public string? Length {get;set;}

    public Product (string name , string sku, string price, string type, string descr, string? weight, string? country, string? length )
    {
        Name = name;
        Sku = sku;
        Price = price;
        Descr = descr;
        Weight = weight;
        Country = country;
        Length = length;
        Type = type;
    }

    public static void printProductInfo (Product product)
        {
            Console.WriteLine($"{ product.Name}  { product.Sku}  { product.Price}   { product.Type}  {product.Descr} {product.Weight} {product.Country} {product.Length} \n");
        }

    public static void theMinSku (List<Product> products) 
        {
            List<Product> sortedList = products.OrderBy(Product=>Product.Sku).ToList();
            Console.WriteLine("The item with the min SKU is : \n");
            Console.WriteLine(sortedList[0].Name +  " " +  sortedList[0].Sku);
        }
    public Product () {}
}

}