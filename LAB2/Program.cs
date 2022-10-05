using LAB2;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

// Fixa current customer använder programmet.

var customers = new List<Customer>();
customers.Add(new Customer("Knatte", "123"));
customers.Add(new Customer("Fnatte", "321"));
customers.Add(new Customer("Tjatte", "213"));

var menu = new List<Product>();
menu.Add(new Product { ProductId = 1, ProductName = "Oregano", Price = 13.95D });
menu.Add(new Product { ProductId = 2, ProductName = "Thyme", Price = 11.95D });
menu.Add(new Product { ProductId = 3, ProductName = "Bay Leaf", Price = 23.95D });
menu.Add(new Product { ProductId = 4, ProductName = "Parsley", Price = 17.95D });
menu.Add(new Product { ProductId = 5, ProductName = "Rosemary", Price = 14.95D });
menu.Add(new Product { ProductId = 6, ProductName = "Chive", Price = 19.95D });

void AskCustomer() {

    int input = 10;
    while (input != 0) {

        Console.WriteLine("What products do you want to add to your cart?");

        for (int i = 0; i < menu.Count; i++) {
            menu[i].MenuPresent();

        }
        input = int.Parse(Console.ReadLine());                                                              // Try catch
        if (input == 1) {
            customers[customers.Count - 1].addToCart(menu[0]);
        }

        customers[customers.Count - 1].CartPresent();
        Thread.Sleep(1500);
        Console.Clear();
    }
}


void MainMenu() {

    // Console.Clear();
    while (true) {
        int userPick;
        try {
            Console.WriteLine("1. Log in");
            Console.WriteLine("2. Create new user");
            userPick = int.Parse(Console.ReadLine());
            if (userPick == 1) {
                Customer.LogIn();
            } else if (userPick == 2) {
                customers.Add(Customer.NewCustomer());
            }
            break;

        } catch (Exception wrong) {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Invalid Choice, Choose 1 Or 2\n");
            Console.ResetColor();
        }


    }
}

while (true) {

    MainMenu();
    Customer.LogIn();
    AskCustomer();

    for (int i = 0; i < customers.Count; i++) {
        Console.WriteLine(customers[i].CustomerId);

    }


    customers[customers.Count - 1].CartPresent();

    customers[customers.Count - 1].addToCart(menu[0]);
    customers[customers.Count - 1].addToCart(menu[2]);
    customers[customers.Count - 1].addToCart(menu[3]);

    customers[customers.Count - 1].CartPresent();

    customers[customers.Count - 1].ConvertCurrencyUSD(customers[customers.Count - 1].TotalPrice);
    customers[customers.Count - 1].CartPresent();

    Console.WriteLine(customers[^1]);

    Console.ReadLine();

    for (int i = 0; i < menu.Count; i++) {

        menu[i].MenuPresent();

    }



    Console.ReadLine();




}