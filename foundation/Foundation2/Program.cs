using System;

class Program
{
    static void Main(string[] args)
    {
        // Create some addresses
        Address address1 = new Address("123 Main St", "Los Angeles", "CA", "USA");
        Address address2 = new Address("456 Maple Ave", "Toronto", "Ontario", "Canada");
        Address address3 = new Address("456 Uyo Road", "Uyo", "Akwaibom", "Nigeria");


        // Create customers
        Customer customer1 = new Customer("John Smith", address1);
        Customer customer2 = new Customer("Emma Johnson", address2);
        Customer customer3 = new Customer("Samuel Archibong", address3);

        // Create products for the first order
        Product product1 = new Product("Laptop", "A123", 799.99, 1);
        Product product2 = new Product("Mouse", "B456", 19.99, 2);

        // Create first order
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        // Create products for the second order
        Product product3 = new Product("Monitor", "C789", 199.99, 1);
        Product product4 = new Product("Keyboard", "D012", 49.99, 1);
        Product product5 = new Product("USB Cable", "E345", 9.99, 3);

        // Create second order
        Order order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);
        order2.AddProduct(product5);

        //Create third Order
        Order order3 = new Order(customer3);
        order3.AddProduct(product3);
        order3.AddProduct(product4);


        // Display order details for the first order
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.CalculateTotalCost():0.00}\n");

        // Display order details for the second order
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.CalculateTotalCost():0.00}\n");

        // Display order details for the third order
        Console.WriteLine(order3.GetPackingLabel());
        Console.WriteLine(order3.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order3.CalculateTotalCost():0.00}\n");
    }
}