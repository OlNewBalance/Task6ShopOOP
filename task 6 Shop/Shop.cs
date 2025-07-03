namespace Task6_Shop
{
    public class Product
    {
        public string Name;
        public int Price;
        public int Quantity;
        public int ProductID;

        public Product(string name, int price, int quantity, int productID)
        {
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
            this.ProductID = productID;
        }
    }

    public class ShopMaster
    {
        public List<Product> Counter = new List<Product>();
        public PlayerInventory CustomerInventory { get; set; }

        public ShopMaster(PlayerInventory customerInventory)
        {
            CustomerInventory = customerInventory;
        }

        public void AddProduct(string productName, int price, int quantity, int productID)
        {
            if (Counter.Find(x => x.ProductID == productID) == null)
            {
                Counter.Add(new Product(productName, price, quantity, productID));
                //Console.WriteLine("Товар успешно добавлен!");
            }
            else
            {
                //Console.WriteLine("К сожалению, таковой товар уже есть!...");
            }
        }

        /// - весь метод buy перелопачен чатом.
        public void Buy(int productID, int quantity)
        {
            var productToBuy = Counter.FirstOrDefault(p => p.ProductID == productID);
            if (productToBuy != null && CustomerInventory != null)
            {
                CustomerInventory.Inventory.Add(new Product(productToBuy.Name, productToBuy.Price, quantity,
                    productToBuy.ProductID));
                Counter.Remove(productToBuy);
                Console.WriteLine("Товар успешно куплен!");
            }
            else if (CustomerInventory == null)
            {
                Console.WriteLine("Не указан инвентарь покупателя!");
            }
            else
            {
                Console.WriteLine("Такого товара нет в магазине!");
            }
        }

        ///
        public void PrintCounter()
        {
            if (Counter.Count > 0)
            {
                foreach (var product in Counter)
                {
                    Console.WriteLine(
                        $"Все товары на полках: {product.Name} - {product.Price} динариев - {product.Quantity} штук.");
                }
            }
            else
            {
                Console.WriteLine("На полках товаров!");
            }
        }
    }

    public class PlayerInventory
    {
        public List<Product> Inventory = new List<Product>();

        public void PrintCounter()
        {
            if (Inventory.Count > 0)
            {
                foreach (var product in Inventory)
                {
                    Console.WriteLine(
                        $"Все товары в инвентаре: {product.Name} - {product.Price} динариев - {product.Quantity} штук.");
                }
            }
            else
            {
                Console.WriteLine("\nВ инвентаре ничего нет!...");
            }
        }
    }
}
