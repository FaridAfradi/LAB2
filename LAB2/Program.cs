using System.Data;
using LAB2;


var menu = new List<Product>();
menu.Add(new Product { ProductId = 1, ProductName = "Oregano", Price = 13.95D });
menu.Add(new Product { ProductId = 2, ProductName = "Thyme", Price = 11.95D });
menu.Add(new Product { ProductId = 3, ProductName = "Bay Leaf", Price = 23.95D });
menu.Add(new Product { ProductId = 4, ProductName = "Parsley", Price = 17.95D });
menu.Add(new Product { ProductId = 5, ProductName = "Rosemary", Price = 14.95D });
menu.Add(new Product { ProductId = 6, ProductName = "Chive", Price = 19.95D });

void MenuAdd() {

    int input = 10;
    while (input != 0) {

        Console.WriteLine("## Add Products To Your Cart ##");
        Console.ForegroundColor= ConsoleColor.Red;
        Console.WriteLine("To Exit Menu, press 0");

        for (int i = 0; i < menu.Count; i++) 
        {
            menu[i].MenuPresent();
        }



        try
        {

            input = int.Parse(Console.ReadLine());
            if (input == 1) { Customer._customerList[^1].addToCart(menu[0]);}
            else if (input == 2){ Customer._customerList[^1].addToCart(menu[1]);} 
            else if (input == 3) { Customer._customerList[^1].addToCart(menu[2]);} 
            else if (input == 4) { Customer._customerList[^1].addToCart(menu[3]);} 
            else if (input == 5) { Customer._customerList[^1].addToCart(menu[4]);} 
            else if (input == 6) { Customer._customerList[^1].addToCart(menu[5]);}
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

        Customer._customerList[^1].CartPresent();
        Thread.Sleep(1000);
        Console.Clear();
    }
}

void MainMenu() {

    // Console.Clear();
    while (true)
    {
        bool loginSucess = false;
        int userPick;
        Console.Clear();
        try {
            Console.WriteLine("1. Log in");
            Console.WriteLine("2. Create new user");
            userPick = int.Parse(Console.ReadLine());
            if (userPick == 1) {
                loginSucess = Customer.LogIn();
            } else if (userPick == 2) {
                //customers.Add(Customer.NewCustomer());
                Customer._customerList.Add(Customer.NewCustomer());
            }

            if (loginSucess)
            {
                break;
            }

        } catch (Exception wrong) {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Invalid Choice, Choose 1 Or 2\n");
            Thread.Sleep(1500);
            Console.Clear();
            Console.ResetColor();
        }
    }
}

void SubMenu()
{
    Console.WriteLine("1. Show Cart");
    Console.WriteLine("2. Show Total Price");
    Console.WriteLine("3. Show Total Price In USD");
    Console.WriteLine("3. Show Total Price In EUR");
    
}




MainMenu();
while (true) 
{
    
    MenuAdd();
    //Console.WriteLine(Customer[^1].ToString());                                             // Fixa tostring
    Console.ReadLine();


}