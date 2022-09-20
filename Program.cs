using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using baseProg;

 namespace baseProg {
    public class Program 
    
    {  
   // Console.WriteLine("Select what method of import do you want to select ?\n 1 - Import from email txt file \n 2 - Import from JSON \n 3 - Import 1 Product from file \n");
    
    


    public static void Main(string[] args) 
    {  
        string filePath = @"/Users/aeternitas/Projects/StorePDP/StorePDP/data.txt";
        string jsonFilePath = @"/Users/aeternitas/Projects/StorePDP/StorePDP/JSONData.json";
        string oneLinePath = @"/Users/aeternitas/Projects/StorePDP/StorePDP/onelinepar.txt";
        List<Product> products = new List<Product>();
       // List<string> lines = File.ReadAllLines(filePath).ToList();
        List<string> linesForOneProduct = File.ReadAllLines(oneLinePath).ToList();
        // Asking a user which method of input he prefers 
        Console.WriteLine("Select what method of import do you want to select ?\n 1 - Import from email txt file \n 2 - Import from JSON \n 3 - Import 1 Product from file \n");
        string userInput = Console.ReadLine();
        switch (userInput)
        {
            case "1":
                        
                List<string> lines = File.ReadAllLines(filePath).ToList();

                foreach ( var line in lines)
                    {
                        string [] entries = line.Split(',');
                        Product newProduct =  new Product(entries[0],entries[1],entries[2],entries[3],entries[4],entries[5],entries[6],entries[7]);
                        products.Add(newProduct);
                    }
                                foreach (var product  in products) {
                Console.WriteLine($"{ product.Name}  { product.Sku}  { product.Price}   { product.Type}  {product.Descr} {product.Weight} {product.Country} {product.Length} \n");
            }
            break;
            case "2":
                    string jsonFormatObj1 = System.IO.File.ReadAllText(jsonFilePath);
                    var list1 = JsonSerializer.Deserialize<List<JSONProduct>>(jsonFormatObj1);
                    foreach (var product  in list1) {
                        Console.WriteLine($"{ product.Name}  { product.Sku}  { product.Price}   { product.Type}  {product.Descr} {product.Weight} {product.Country} {product.Length} \n");
                        }
                    break;
            case "3":
                    Product oneLine = new Product(linesForOneProduct[0],linesForOneProduct[1],linesForOneProduct[2],linesForOneProduct[3],linesForOneProduct[4],linesForOneProduct[5],linesForOneProduct[6],linesForOneProduct[7]);
                    Console.WriteLine($"{ oneLine.Name}  { oneLine.Sku}  { oneLine.Price}   { oneLine.Type}  {oneLine.Descr} {oneLine.Weight} {oneLine.Country} {oneLine.Length} \n");
                    //printProductInfo(oneLine);
                    break;


        }

        Console.WriteLine("What do you want to do ? \n To Search by SKU Type 1 and then Specify the SKU Number\n To show minimal SKU Product - Type 2");
        string userAction2 = Console.ReadLine();
        switch(userAction2)
        {
            case "1":
                string searchedSku = Console.ReadLine();
                searchBySKU(searchedSku,products);
                break;
            case "2":
                theMinSku(products);
                break;

        }
    
        //Product oneLine = new Product(linesForOneProduct[0],linesForOneProduct[1],linesForOneProduct[2],linesForOneProduct[3],linesForOneProduct[4],linesForOneProduct[5],linesForOneProduct[6],linesForOneProduct[7]);
/*
        Console.WriteLine($"{ oneLine.Name}  { oneLine.Sku}  { oneLine.Price}   { oneLine.Type}  {oneLine.Descr} {oneLine.Weight} {oneLine.Country} {oneLine.Length} \n");

        foreach ( var line in lines)
        {
            string [] entries = line.Split(',');
            Product newProduct =  new Product(entries[0],entries[1],entries[2],entries[3],entries[4],entries[5],entries[6],entries[7]);
            products.Add(newProduct);

        }
        */
        /*

/*          
            Console.WriteLine("IMPLEMENTATION FOR JSON !!! : \n");
            string jsonFormatObj = System.IO.File.ReadAllText(jsonFilePath);
            var list = JsonSerializer.Deserialize<List<JSONProduct>>(jsonFormatObj);
            // Console.WriteLine($"There are {list.Count} Products.");


            foreach (var product  in list) {
                Console.WriteLine($"{ product.Name}  { product.Sku}  { product.Price}   { product.Type}  {product.Descr} {product.Weight} {product.Country} {product.Length} \n");
            }
*/


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
}


