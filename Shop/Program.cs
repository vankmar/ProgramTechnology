namespace Shop
{
    internal class Program
    { 
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите источник данных: ");
            Console.WriteLine("1 - В памяти (InMemoryRepository)"); 
            Console.WriteLine("2 - Из CSV-файлов (CsvRepository)"); 

            string choice = Console.ReadLine();
            IRepository repository = null; // то хранилище, с которым будем работать
            
            switch (choice)
            {
                case "1":
                    repository = new InMemoryRepository();
                    break;
                case "2":
                    repository = new CsvRepository("data");
                    break;
                default:
                    Console.WriteLine("Неверный выбор. Используется InMemoryRepository.");
                    repository = new InMemoryRepository();
                    break;
            }

            List<Supplier> suppliers = new List<Supplier>();
            List<Category> categories = new List<Category>();
            List<Product> products = new List<Product>();

            try
            {
                suppliers = repository.GetSuppliers();
                categories = repository.GetCategories();
                products = repository.GetProducts();
            }
            catch (Exception e)
            { Console.WriteLine(e.Message);
                return;
            }

            Console.Write("1. FindCategory(\"Ноутбук\"): "); //1
            Category cat1 = Analytics.FindCategory("Ноутбук", products, categories);
            if (cat1 != null)
                Console.WriteLine(cat1.Info);
            else
                Console.WriteLine("null");

            Console.Write("2. FindSupplier(product \"Ноутбук\"): "); //2
            Supplier laptopSup = Analytics.FindSupplier("Ноутбук", products, suppliers);
            if (laptopSup != null)
                Console.WriteLine(laptopSup.GetInfo());
            else
                Console.WriteLine("null");

            double totalPrice = Analytics.GetTotalPrice(products); //3
            Console.WriteLine($"3. GetTotalPrice: {totalPrice} руб.");

            Console.Write("4. GetMostExpensiveProductPerCategory: "); // 4
            Dictionary<string, Product> expensiveDict = Analytics.GetMostExpensiveProductPerCategory(products, categories);

            Console.WriteLine("5. PrintAllProducts:"); // 5
            Analytics.PrintAllProducts(products, categories, suppliers);
            Console.WriteLine();

            Console.Write("Не найдено: FindCategory(\"Неизвестный товар\") -> ");
            Category unknownCat = Analytics.FindCategory("Неизвестный товар", products, categories);
            if (unknownCat == null) 
                Console.WriteLine("null");
        }
    }
}
