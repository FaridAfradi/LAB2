using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using LAB2;
using System.Linq;
using System.Threading.Channels;
using Microsoft.VisualBasic.CompilerServices;

int userPick = 0;                                                                           // Fixa textfilen och current customer använder programmet (WHILE LOOPS)
int signInMenu = 0;
double oreganoGrams, thymeGrams, bayleafGrams, parsleyGrams, rosemaryGrams, chiveGrams, totalPrice;

var customerOne = new Customer("Knatte", "123");
var customerTwo = new Customer("Fnatte", "321");
var customerThree = new Customer("Tjatte", "213");

var customers = new List<Customer>();

customers.Add(customerOne);
customers.Add(customerTwo);
customers.Add(customerThree);


customers.Add(Customer.NewCustomer());

for (int i = 0; i < customers.Count; i++) {                                                     // måste söka via customerId för att känna igen
    Console.WriteLine(customers[i].CustomerId);

}


customers[customers.Count - 1].CartPresent();


var menu = new List<Product>();

menu.Add(new Product { ProductId = 1, ProductName = "Oregano", Price = 13.95D });
menu.Add(new Product { ProductId = 2, ProductName = "Thyme", Price = 11.95D });
menu.Add(new Product { ProductId = 3, ProductName = "Bay Leaf", Price = 23.95D });
menu.Add(new Product { ProductId = 4, ProductName = "Parsley", Price = 17.95D });
menu.Add(new Product { ProductId = 5, ProductName = "Rosemary", Price = 14.95D });
menu.Add(new Product { ProductId = 6, ProductName = "Chive", Price = 19.95D });

customers[customers.Count - 1].addToCart(menu[0]);
customers[customers.Count - 1].addToCart(menu[2]);
customers[customers.Count - 1].addToCart(menu[3]);
customers[customers.Count - 1].CartPresent();

customers[customers.Count - 1].ConvertCurrencyUSD(customers[customers.Count - 1].TotalPrice);


for (int i = 0; i < menu.Count; i++) {

    menu[i].MenuPresent();

}




