using System.Data;
using LAB2;


var menu = new List<Product>();
menu.Add(new Product { ProductId = 1, ProductName = "Oregano", Price = 13.95D });                               // Add items to Menu (list)
menu.Add(new Product { ProductId = 2, ProductName = "Thyme", Price = 11.95D });
menu.Add(new Product { ProductId = 3, ProductName = "Bay Leaf", Price = 23.95D });
menu.Add(new Product { ProductId = 4, ProductName = "Parsley", Price = 17.95D });
menu.Add(new Product { ProductId = 5, ProductName = "Rosemary", Price = 14.95D });
menu.Add(new Product { ProductId = 6, ProductName = "Chive", Price = 19.95D });

var customers = new List<Customer>();
customers.Add(new Customer("Knatte", "123"));
customers.Add(new Customer("Fnatte", "321"));
customers.Add(new Customer("Tjatte", "213"));
Customer? currentCustomer = null;


void MenuAdd() {                                                                                            // Method for adding products to menu

    int input = 10;
    while (input != 0) {

        Console.WriteLine("## Add Products To Your Cart ##");
        Console.ForegroundColor= ConsoleColor.Red;
        Console.WriteLine("To Exit Menu, press 0");

        for (int i = 0; i < menu.Count; i++)                                                                        // Show menu for adding products in method                                                           
        {
            menu[i].MenuPresent();
        }

        try
        {

            input = int.Parse(Console.ReadLine());
            if (input == 1) { customers[^1].addToCart(menu[0]);}                                         // add items until user exits
            else if (input == 2){ customers[^1].addToCart(menu[1]);} 
            else if (input == 3) { customers[^1].addToCart(menu[2]);} 
            else if (input == 4) { customers[^1].addToCart(menu[3]);} 
            else if (input == 5) { customers[^1].addToCart(menu[4]);} 
            else if (input == 6) { customers[^1].addToCart(menu[5]);}
            else if (input == 0) {Console.Clear(); break;}
            else
            {
                Console.WriteLine("Enter a valid number");
            }
            
        }
        catch (Exception e)
        {
            Console.WriteLine("\nDon't f*k around!");
        }

        customers[^1].CartPresent();
        Thread.Sleep(1000);
        Console.Clear();
    }
}

void MainMenu() {

    while (currentCustomer == null)
    {
        Console.Clear();
        try {
            Console.WriteLine("1. Log in");
            Console.WriteLine("2. Create new user");
            int userPick = int.Parse(Console.ReadLine());
            if (userPick == 1)
            {
                LogIn();

            } else if (userPick == 2) {
                
                customers.Add(Customer.NewCustomer());
            }

            if (currentCustomer != null)
            {
                break;
            }

        } catch (Exception wrong) {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Invalid Choice, Choose 1 Or 2\n");
            Thread.Sleep(1200);
            Console.Clear();
            Console.ResetColor();
        }
    }
}

void SubMenu() {

    int input = 0;
    Console.WriteLine("1. Show Cart");
    Console.WriteLine("2. Show Total Price");
    Console.WriteLine("3. Show Total Price In USD");
    Console.WriteLine("3. Show Total Price In EUR");
    Console.WriteLine("4. Print My Info");
    

}

void LogIn() {

    Console.Clear();
    Console.WriteLine("Enter Your Username:");
    string user = Console.ReadLine();
    Console.WriteLine("Enter Your Password:");
    string password = Console.ReadLine();
    
    foreach (var customer in customers)
    {
        if (customer.CustomerId == user)
        {
            if (customer.Password.Equals(password))                              // (customer.Password.Equals(password))
            {
                Console.Clear();
                Console.WriteLine($"Login Sucessful @ {DateTime.Now}");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\nWelcome {user}!\n");
                currentCustomer = customer;
                Console.ResetColor();
                break;

            }

            else if (customer.Password != password)
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong Password, try again");
                    Console.ResetColor();
                    Console.WriteLine("Enter Your Password");
                    Console.ReadLine();

                }

                Console.WriteLine("Login Failed, Returning To Login Screen.");
                Thread.Sleep(1200);
                break;
            }

        } 
        else 
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nUser Does Not Exist");
            Console.ResetColor();
            Thread.Sleep(1000);
            break;
        }

    }

}




MainMenu();
while (true) 
{
    for (int i = 0; i < customers.Count; i++) 
    {
        Console.WriteLine(customers[i].CustomerId);
    }
    MenuAdd();
    Console.WriteLine(currentCustomer.ToString());                                             // Fixa tostring
    Console.ReadLine();

}