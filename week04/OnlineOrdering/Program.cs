using System;

class Program
{
    static void Main(string[] args)
    {
        Address usaAddress = new Address("123 Maple St", "Boise", "Idaho", "USA");
        Customer usaCustomer = new Customer("Emma Johnson", usaAddress);
        Order usaOrder = new Order(usaCustomer);
        usaOrder.AddProduct(new Product("Wireless Mouse", "P1001", 24.99, 2));
        usaOrder.AddProduct(new Product("Keyboard", "P1002", 49.50, 1));
        usaOrder.AddProduct(new Product("USB-C Cable", "P1003", 9.75, 3));

        Address internationalAddress = new Address("45 King Street", "Toronto", "Ontario", "Canada");
        Customer internationalCustomer = new Customer("Liam Brown", internationalAddress);
        Order internationalOrder = new Order(internationalCustomer);
        internationalOrder.AddProduct(new Product("Laptop Stand", "P2001", 39.99, 1));
        internationalOrder.AddProduct(new Product("Webcam", "P2002", 79.00, 1));

        Console.WriteLine("Order 1");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(usaOrder.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(usaOrder.GetShippingLabel());
        Console.WriteLine($"Total Price: ${usaOrder.CalculateTotalCost():0.00}");

        Console.WriteLine();

        Console.WriteLine("Order 2");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(internationalOrder.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(internationalOrder.GetShippingLabel());
        Console.WriteLine($"Total Price: ${internationalOrder.CalculateTotalCost():0.00}");
    }
}