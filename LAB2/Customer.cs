using LAB2;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace LAB2 {

    public class Customer {

        private double _usd = 0.090D;
        private double _eur = 0.092D;
        private double _sek = 1.00D;
        private double _totalPrice;
        private string _customerId;
        private string _password;

        private List<Product> _cart; // Skapa en kundlista

        public List<Product> Cart {
            get { return _cart; }
            set { }
        }

        public double TotalPrice {
            get {
                _totalPrice = 0.0D;

                for (int i = 0; i < _cart.Count; i++) {
                    _totalPrice += _cart[i].Price;
                }

                return _totalPrice;
            }
            private set {
                _totalPrice = TotalPrice; // testa dig fram
            }
        }

        public string CustomerId {

            get { return _customerId; }
            private set { _customerId = value; }
        }

        public string Password {
            get { return _password; }
            private set { _password = value; }
        }

        public static Customer LogIn() {

            Console.Clear();
            string user = string.Empty;
            string password = string.Empty;

            Console.WriteLine("Enter Your Username:");                                                                  // Fixa list och jämför värdena
            user = Console.ReadLine();
            while (user == (string.Empty) || user.Length < 5) {
                Console.Clear();
                Console.WriteLine("Invalid Username, Try Again.");
                user = Console.ReadLine();
            }

            Console.Clear();
            Console.WriteLine("Enter Your Password:");
            password = Console.ReadLine();
            Console.Clear();
            while (password == (string.Empty) || password.Length < 5) {
                Console.Clear();
                Console.WriteLine("Invalid Or Wrong Password, Try Again!");
                password = Console.ReadLine();

            }
            Console.Clear();
            Console.WriteLine($"Login Sucessful @ {DateTime.Now}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nWelcome {user}!");
            Console.ResetColor();
            return null;

        }
        public static Customer NewCustomer() {

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[Create A New User]\n");
            Console.ResetColor();
            Console.WriteLine("Choose Your Username: (Min 5 Characters)");
            string user = Console.ReadLine();
            while (user == (string.Empty) || user.Length < 5) {

                Console.WriteLine("Invalid Username, Enter A Valid Username.  (Min 5 Characters)\n");
                user = Console.ReadLine();
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[Create A New User]\n");
            Console.ResetColor();
            Console.WriteLine($"Username Chosen: {user}");
            Console.WriteLine("\nChoose Your Password:");
            string password = Console.ReadLine();
            while (password == (string.Empty) || password.Length < 5) {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("[Create A New User]\n");
                Console.ResetColor();
                Console.WriteLine($"Username Chosen: {user}");
                Console.WriteLine("Invalid password, Try Again! (Min 5 Characters)");
                password = Console.ReadLine();

            }             // Fixa property och lägg ihop produkterna 

            Console.WriteLine("\nPlease Confirm Your Password:");
            string confirm = Console.ReadLine();
            int count = 1;
            while (true) {

                if (confirm != password) {
                    Console.WriteLine("Password Do Not Match, Try Again");
                    confirm = Console.ReadLine();
                    count++;

                }
                if (count == 3) {
                    Console.WriteLine("Password Confirmation Failed. Returning To Main Menu\n");
                    Thread.Sleep(1500);
                    break;

                } else if (confirm == password) {
                    Customer cust = new Customer(user, password);
                    Console.Clear();
                    Console.WriteLine($"\nAccount Created @ {DateTime.Now}");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\nWelcome, {user}!\n ");
                    Console.ResetColor();
                    Thread.Sleep(1500);
                    return cust;
                }

            }

            return null;
        }

        public void CartPresent() {

            if (TotalPrice < 11.85D) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Your Cart Is Empty");
                Console.ResetColor();

            } else if (_cart != null) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Your cart does currently contains:");
                Console.ResetColor();
                for (int i = 0; i < _cart.Count; i++) {

                    Console.WriteLine(_cart[i].ProductName + ", " + _cart[i].Price + " SEK");
                    Console.ResetColor();

                }
            }
        }
        public void ProductAdder(Product product) {                                 // try catch
            int input = 10;
            Console.WriteLine("To add products, enter product number + enter");
            while (input != 0) {
                input = int.Parse(Console.ReadLine());

                if (input == 1) {
                    _cart.Add(product);
                    Console.WriteLine($"");
                }



            }

        }
        public void addToCart(Product product) {
            _cart.Add(product);
            Console.WriteLine("1 x " + product.ProductName + " added to cart.");
        }

        public void ConvertCurrencyUSD(double sek) {
            _usd = (sek * 0.090D);
            Console.WriteLine($"Price In USD: {_usd}");
        }

        public void ConvertCurrencyEUR(double sek) {
            _eur = (sek * 0.092D);
            Console.WriteLine($"Price In EUR: {_eur}");
        }

        public Customer() {

        }

        public Customer(string customerId, string password) {

            _customerId = customerId;
            _password = password;
            _cart = new List<Product>();

            /*Console.WriteLine("Lets roll about your tier!");
            Random rnd = new Random();
            rnd.Next(1, 101);
            Console.WriteLine(rnd);*/

        }




        public override string ToString() {

            var temp = "";

            foreach (var ble in _cart) {
                temp += ble.ProductName + "\n";

            }

            return $"\nUsername: {_customerId}\nPassword: {_password}\n\nCart:\n{temp}";

            //_cart.Select(x=>x.ProductName + " ").ToString()




        }


    }


}