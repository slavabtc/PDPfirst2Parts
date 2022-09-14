using System;

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
}