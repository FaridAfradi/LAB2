using System.Data;
using System.Reflection.Metadata.Ecma335;
using LAB2;
using Microsoft.VisualBasic.CompilerServices;

/// <summary>
/// //////////////////////////////////////////////////////////// DENNA ÄR RÄTT
/// </summary>

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
    
    
     while (input != 0)
     {
         if (currentCustomer.TotalPrice > 10.00D)
         {
             currentCustomer.CartPresent();
         }
         
        Console.WriteLine("\nAdd Products To Your Cart ");
        Console.ForegroundColor= ConsoleColor.Red;
        Console.WriteLine("To Exit Menu, press 0");

        for (int i = 0; i < menu.Count; i++)                                                                        // Show menu for adding products in method                                                           
        {
            menu[i].MenuPresent();
        }

        try
        {

            input = int.Parse(Console.ReadLine());
            if (input == 1) { currentCustomer.addToCart(menu[0]);}                                         // add items until user exits
            else if (input == 2){ currentCustomer.addToCart(menu[1]);} 
            else if (input == 3) { currentCustomer.addToCart(menu[2]);} 
            else if (input == 4) { currentCustomer.addToCart(menu[3]);} 
            else if (input == 5) { currentCustomer.addToCart(menu[4]);} 
            else if (input == 6) { currentCustomer.addToCart(menu[5]);}
            else if (input == 0) {Console.Clear(); break;}
            else
            {
                Console.WriteLine("Enter a valid number");
            }
            
        }
        catch (Exception errorInput)
        {
            Console.WriteLine("Invalid Input");
        }

        
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


            } else if (userPick == 2)
            {
                customers.Add(currentCustomer);
                NewCustomer();
               
                
                //customers.Add(new Customer());

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

void SubMenu()
{

    int input = 0;
    Console.WriteLine("1. Show Cart");
    Console.WriteLine("2. Show Total Price");
    Console.WriteLine("3. Show Total Price In USD");
    Console.WriteLine("3. Show Total Price In EUR");
    Console.WriteLine("4. Print My Info");
}

    static Customer NewCustomer()                                                                                                                       // static Customer
    {

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("[Create A New User]\n");
        Console.ResetColor();
        Console.WriteLine("Choose Your Username, Minimum 5 Characters");
        string user = Console.ReadLine();
        while (user == (string.Empty) || user.Length < 5)
        {

            Console.WriteLine("Invalid Username, Enter A Valid Username. Minimum 5 Characters)\n");
            user = Console.ReadLine();
        }

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("[Create A New User]\n");
        Console.ResetColor();
        Console.WriteLine($"Username Chosen: {user}");
        Console.WriteLine("\nChoose Your Password, Minimum 5 Characters");
        string password = Console.ReadLine();
        while (password == (string.Empty) || password.Length < 5)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[Create A New User]\n");
            Console.ResetColor();
            Console.WriteLine($"Username Chosen: {user}");
            Console.WriteLine("Invalid password.");
            Console.WriteLine("\nChoose Your Password, Minimum 5 Characters");
            password = Console.ReadLine();

        }

        Console.WriteLine("\nConfirm Your Password:");
        string confirm = Console.ReadLine();
        int count = 1;
        while (true)
        {

            if (!confirm.Equals(password))
            {
                Console.WriteLine("Password Do Not Match, Try Again");
                confirm = Console.ReadLine();
                count++;

            }

            if (count == 3)
            {
                Console.WriteLine("Password Confirmation Failed. Returning To Main Menu\n");
                Thread.Sleep(1500);
                break;

            }
            else if (confirm == password)
            {
                Customer cust = new Customer(user, password);
                Console.Clear();
                Console.WriteLine($"\nAccount Created @ {DateTime.Now}");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Your Username: {user}\n ");
                Console.ResetColor();
                Console.WriteLine("\nRe-directing to Login Screen ");
                Thread.Sleep(2000);
                return cust;
            }
        }

        return null;
    }

    void LogIn()
    {

        Console.Clear();
        Console.WriteLine("Enter Your Username:");
        string user = Console.ReadLine();
        Console.WriteLine("Enter Your Password:");
        string password = Console.ReadLine();

        foreach (var customer in customers)
        {
            if (customer.CustomerId.Equals(user))
            {
                if (customer.Password.Equals(password)) // (customer.Password.Equals(password))
                {
                    Console.Clear();
                    Console.WriteLine($"Login Sucessful @ {DateTime.Now}");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\nWelcome {user}!\n");
                    currentCustomer = customer;
                    Console.ResetColor();
                    break;

                }

                else if (!customer.Password.Equals(password))
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
        Console.WriteLine(currentCustomer.ToString()); // Fixa tostring
        Console.ReadLine();
    }
