namespace Task6_Shop
{
    internal class Program
    {
        static public void Main()
        {
            string input;
            int playerMoney = 10000;
            PlayerInventory inventory = new PlayerInventory();
            var sh = new ShopCart(inventory);
            var iin = new PlayerInventory();
            sh.AddProduct("Чай", 134, 14, 134);
            sh.AddProduct("Молоко", 98, 12, 542);
            sh.AddProduct("Восстанавливающее пирожное", 400, 1, 567);
            sh.AddProduct("Зелье-невидимка", 4534, 4, 789);
            sh.AddProduct("Сыр", 147, 7, 345);
            sh.AddProduct("Курятина", 160, 5, 890);
            sh.AddProduct("Харам", 212, 12, 009);
            sh.AddProduct("Бутылка воды", 23, 20, 123);
            sh.AddProduct("Ложка (старая...)", 0, 1, 777);
            Console.WriteLine("Чтобы войти в магазин, нажмите ENTER");
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                Console.WriteLine("Вы зашли в магазин, чтобы посмотреть ассортимент, нажмите ENTER");
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    while (Console.ReadKey(true).Key != ConsoleKey.E)
                    {
                        sh.PrintInventory();
                        Console.WriteLine($"Ваш баланс: {playerMoney} динариев");
                        Console.Write("\nХотите что-то купить(S), или посмотреть инвентарь(I), или на выход(E)? ");
                        if (Console.ReadKey(true).Key == ConsoleKey.S)
                        {
                            Console.Write("\nВведите название товара: ");
                            string productName = Console.ReadLine();

                            // Поиск товара по названию (без учета регистра)
                            var product = sh.ShoppingCart.FirstOrDefault(p =>
                                p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));

                            if (product != null)
                            {
                                Console.Write($"Введите количество (доступно {product.Quantity}): ");
                                if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0)
                                {
                                    int totalCost = product.Price * quantity;

                                    if (product.Quantity >= quantity)
                                    {
                                        if (playerMoney >= totalCost)
                                        {
                                            // Совершаем покупку
                                            playerMoney -= totalCost;
                                            product.Quantity -= quantity;

                                            // Добавляем в инвентарь
                                            var existingItem = inventory.Inventory.FirstOrDefault(p =>
                                                p.ProductID == product.ProductID);

                                            if (existingItem != null)
                                            {
                                                existingItem.Quantity += quantity;
                                            }
                                            else
                                            {
                                                inventory.Inventory.Add(new Product(
                                                    product.Name,
                                                    product.Price,
                                                    quantity,
                                                    product.ProductID));
                                            }

                                            Console.WriteLine(
                                                $"Куплено {quantity} {product.Name} за {totalCost} динариев");
                                        }
                                        else
                                        {
                                            Console.WriteLine(
                                                $"Недостаточно денег! Нужно {totalCost}, у вас {playerMoney}");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Недостаточно товара! Доступно только {product.Quantity}");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Некорректное количество!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Товар не найден! Проверьте название.");
                            }

                            Console.WriteLine("E - выход, I - посмотреть инвентарь, Любая клавиша - продолжить");
                        }
                        else if (Console.ReadKey(true).Key == ConsoleKey.I)
                        {
                            Console.WriteLine("ZooPorno");
                            inventory.PrintCounter();
                            Console.WriteLine("E - выход, Любая клавиша - продолжить");
                        }
                    }
                }
            }
        }
    }
}
