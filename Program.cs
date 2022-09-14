using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

    public class Program 
    
    {  

    
    public static void Main(string[] args) 
    {  
        string filePath = @"/Users/aeternitas/Projects/StorePDP/StorePDP/data.txt";

        List<Product> products = new List<Product>();
        List<string> lines = File.ReadAllLines(filePath).ToList();


        foreach ( var line in lines)
        {
            string [] entries = line.Split(',');
            Product newProduct =  new Product(entries[0],entries[1],entries[2],entries[3],entries[4],entries[5],entries[6],entries[7]);
            products.Add(newProduct);

        }
        /*try {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
               using (StreamReader sr = new StreamReader(@"/Users/aeternitas/Projects/StorePDP/StorePDP/data.txt")) {
                    string line;
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null) {
                        line = line.Replace(" ", "");
                        string[] tmp = line.Split(',');
                        string name = tmp[0];
                        string sku = tmp[1];
                        int price = Convert.ToInt32(tmp[2]);
                        string type = tmp[3];
                        string descr = tmp[4];
                        string weight = tmp[5];
                        string country = tmp[6];
                        string length = tmp[7];
                        products.Add(new Product(name, sku, price, type, descr,weight,country,length));                    
                    }
                }
            } catch (Exception e) {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            */ 
            foreach (var product  in products) {
                Console.WriteLine($"{ product.Name}  { product.Sku}  { product.Price}   { product.Type}  {product.Descr} {product.Weight} {product.Country} {product.Length} \n");
            }
            Console.WriteLine("What SKU are you searching for?");
            string Searched = Console.ReadLine();
            searchBySKU(Searched,products);
            theMinSku(products);
        }
        
        public static void theMinSku (List<Product> products) 
        {
            List<Product> sortedList = products.OrderBy(Product=>Product.Sku).ToList();
            Console.WriteLine("The item with the min SKU is : \n");
            Console.WriteLine(sortedList[0].Name +  " " +  sortedList[0].Sku);
        }
        public static void searchBySKU (string sku,List <Product> products) {      
            Product result = products.Find(resultSku => resultSku.Sku.Equals(sku));
            if(result != null)
            {
                Console.WriteLine(" Name : {0}  Price :  {1}  SKU: {2} Type: {3} Descr: {4} Weight : {5} Length : {6} \n", result.Name, result.Price, result.Sku,result.Type,result.Descr,result.Weight,result.Length );
           
                
            }
            else 
            {
                Console.WriteLine("Not found!");
            }
           
        }
    
    }   

      


