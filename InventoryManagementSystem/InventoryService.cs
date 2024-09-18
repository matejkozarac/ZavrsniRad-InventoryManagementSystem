using InventoryManagementSystem.Shared;

namespace InventoryManagementSystem
{
    public class InventoryService
    {
        private List<Item> Items;

        public InventoryService()
        {
            Items = new List<Item>
            {
                new Item { Id = 1, Name = "Computer Mouse", QuantityInStock = 50, Price = 12.99, Supplier = "Mouse Supplier Inc." },
                new Item { Id = 2, Name = "Mechanical Keyboard", QuantityInStock = 30, Price = 79.99, Supplier = "Keyboard World" },
                new Item { Id = 3, Name = "Central Processing Unit (CPU)", QuantityInStock = 20, Price = 199.99, Supplier = "Tech CPU Corp." },
                new Item { Id = 4, Name = "Laptop", QuantityInStock = 15, Price = 799.99, Supplier = "Laptop Central" },
                new Item { Id = 5, Name = "External Hard Drive (1TB)", QuantityInStock = 40, Price = 59.99, Supplier = "Storage Solutions Ltd." },
                new Item { Id = 6, Name = "Graphics Card", QuantityInStock = 25, Price = 299.99, Supplier = "Graphics Producers Inc." },
                new Item { Id = 7, Name = "Wireless Router", QuantityInStock = 35, Price = 49.99, Supplier = "NetConnect Technologies" },
                new Item { Id = 8, Name = "Monitor (24-inch)", QuantityInStock = 20, Price = 129.99, Supplier = "Display Systems Co." },
                new Item { Id = 9, Name = "Gaming Headset", QuantityInStock = 30, Price = 59.99, Supplier = "GameGear Audio" },
                new Item { Id = 10, Name = "Inkjet Printer", QuantityInStock = 18, Price = 89.99, Supplier = "PrintMaster Inc." },
            };
        }

        [CachingAttribute("GetInventoryItems", 10)]
        public List<Item> getItems()
        { 
            return Items; 
        }
    }
}
