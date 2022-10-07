

namespace LAB2 {

    public class Customer {

        private double _usd = 0.090D;
        private double _eur = 0.092D;
        private double _sek = 1.00D;
        private double _totalPrice;
        private string _customerId;
        private string _password;

        private List<Product> _cart; 

        public List<Product> Cart {
            get { return _cart; }
            set { }
        }

        public double TotalPrice {
            get {
                _totalPrice = 0.0D;

                for (int i = 0; i < _cart.Count; i++) {                                             // calculate total cost
                    _totalPrice += _cart[i].Price;
                }

                return _totalPrice;
            }
            private set {
                _totalPrice = TotalPrice; 
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

        public static Customer NewCustomer() {

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[Create A New User]\n");
            Console.ResetColor();
            Console.WriteLine("Choose Your Username, Minimum 5 Characters");                            
            string user = Console.ReadLine();
            while (user == (string.Empty) || user.Length < 5) {

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
            while (password == (string.Empty) || password.Length < 5) {
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
                    Console.WriteLine($"Your Username: {user}\n ");
                    Console.ResetColor();
                    Console.WriteLine("\nRe-directing to Login Screen ");
                    Thread.Sleep(2000);
                    return cust;
                }
            }
            return null;
        }
        public void CartPresent() {

            if (TotalPrice < 11.85D) {                                                           // my lowest price item sets condition of empty cart (null prints wrong info)
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Your Cart Is Empty");
                Console.ResetColor();

            } else if (_cart != null) {                                                          // (IF) totalprice do not meed condition
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Your cart does currently contains:");
                Console.ResetColor();

                var distinctCart = _cart.Distinct();
                
                foreach (var disctinctProd in distinctCart)                              // Add a distinct cart for adding multiple items
                {
                    var ammount = 0;
                    ammount = _cart.Count(x => x == disctinctProd);
                    Console.WriteLine($"{ammount}x {disctinctProd.ProductName}");
                }
            }
        }

        public void addToCart(Product product) {                                                // print info
            _cart.Add(product);
            Console.WriteLine("\n1 x " + product.ProductName + " added to cart.\n");
        }
        public void ConvertCurrencyUSD(double sek) {                                            // print info
            _usd = (sek * 0.090D);
            Console.WriteLine($"Price In USD: {_usd}");
        }
        public void ConvertCurrencyEUR(double sek) {                                            // print info
            _eur = (sek * 0.092D);
            Console.WriteLine($"Price In EUR: {_eur}");
        }
        public Customer() 
        {
        }
        public Customer(string customerId, string customerPassword) {

            _customerId = customerId;
            _password = customerPassword;
            _cart = new List<Product>();

            /*Console.WriteLine("Lets roll about your tier!");
            Random rnd = new Random();
            rnd.Next(1, 101);
            Console.WriteLine(rnd);*/
        }


        public override string ToString() {                                                        // print info

            var temp = "";

            foreach (var item in _cart) {
                temp += item.ProductName + "\n";

            }
            return $"\nUsername: {_customerId}\nPassword: {_password}\n\nCart:\n{temp}";

            _cart.Select(x => x.ProductName + " ").ToString();

        }


        

    }


}