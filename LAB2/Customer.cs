

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


        public void CartPresent() {

            if (TotalPrice < 11.85D) {                                                           // my lowest price item sets condition of empty cart (null prints wrong info)
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Your Cart Is Currently Empty.");
                // Thread.Sleep(1500);
                Console.ResetColor();

            } else if (_cart != null) {                                                          // (IF) totalprice do not meed condition
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nYour Cart Currently Contains:");
                Console.ResetColor();

                var distinctCart = _cart.Distinct();
                
                foreach (var disctinctProd in distinctCart)                              
                {
                    var ammount = 0;
                    ammount = _cart.Count(x => x == disctinctProd);
                    Console.WriteLine($"{ammount}x (HG) {disctinctProd.ProductName}");
                }
            }
        }

        public void addToCart(Product product) {                                                // print info
            _cart.Add(product);
            Console.WriteLine("\n1x (HG) " + product.ProductName + " added to cart.\n");
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

            foreach (var item in _cart) 
            {            //_cart
                temp += item.ProductName + "\n";
            }
            //_cart.Select(x => x.ProductName + " ").ToString();
            return $"\nUsername: {_customerId}\nPassword: {_password}\n\nYour Cart Contains:\n\n{temp}";
            

            //_cart.Select(x => x.ProductName + " ").ToString();


        }


    }


}