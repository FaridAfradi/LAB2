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

            Console.WriteLine("Enter Your Username:");
            user = Console.ReadLine();
            while (user == (string.Empty)) {
                Console.Clear();
                Console.WriteLine("Enter A Valid Username!");
                user = Console.ReadLine();
            }

            Console.Clear();
            Console.WriteLine("Enter Your Password:");
            password = Console.ReadLine();
            Console.Clear();
            while (password == (string.Empty)) {
                Console.Clear();
                Console.WriteLine("Invalid Password. Try Again!");
                password = Console.ReadLine();

            }

            Console.Clear();
            Console.WriteLine($"Login Sucessful @ {DateTime.Now}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[Welcome {user}]");
            Console.ResetColor();
            return null;

        }

        public static Customer NewCustomer() {

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[Create A New User]\n");
            Console.ResetColor();
            Console.WriteLine("Choose Your Username:");
            string user = Console.ReadLine();
            Console.WriteLine("Choose Your Password:");
            string password = Console.ReadLine();
            Console.WriteLine("Please Confirm Your Password:");
            string confirm = Console.ReadLine();
            Console.Clear();

            for (int i = 0; i <= 2; i++) {
                if (confirm != password) {
                    Console.WriteLine("Password Does Not Match, Please Try Again");
                    confirm = Console.ReadLine();


                } else if (confirm == password) {
                    Customer cust = new Customer(user, password);
                    Console.WriteLine($"Login Sucessful @ {DateTime.Now}");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"[Welcome {user}]");
                    Console.ResetColor();
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
        public Customer ProductAdder() {
            int input = 10;
            while (input != 0) {

            }
            return null;
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
    }


}