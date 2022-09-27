using System.ComponentModel.DataAnnotations;
using LAB2;


int userPick = 0;
int signInMenu;
bool valid = false;

var custOne = new Customer();
custOne.Cart.Add(new Product { productName = "Samsung Galaxy S22" });
custOne.Cart.Add(new Product { productName = "Xiaomi 12T Pro" });
custOne.Cart.Add(new Product { productName = "Iphone 14 Pro Max" });
custOne.Cart.Add(new Product { productName = "ITHS Phone ZUGZUG" });
custOne.Cart.Add(new Product { productName = "Zlatan Phone BIGBOI XXXL" });


Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Do you want to sign in, or register a new account?\n\n");
Console.WriteLine("1) Sign In \n2) Create A New Account ");

while (true) {




    signInMenu = int.Parse(Console.ReadLine());

    if (signInMenu == 2) {
        Console.WriteLine("\n\nEnter Account Email You Want To Register");
        custOne.CustomerId = Console.ReadLine();
        Console.WriteLine($"\n{custOne.CustomerId} registered");

    } else if (signInMenu == 1) {


    } else {
        Console.WriteLine("Invalid Choice");
    }




}




