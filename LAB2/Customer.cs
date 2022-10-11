

namespace LAB2 {

    public class Customer {

        private double _usd = 0.090D;
        private double _eur = 0.092D;
        private double _sek = 1.00D;
        private double _totalPrice;
        private string _customerId;
        private string _password;
        

        private List<Product> _cart; 

        public List<Product> Cart 
        {
            get
            {
                return _cart; 

            }
            
        }

        public double TotalPrice {
            get
            {
                _totalPrice = 0.0D;

                for (int i = 0; i < _cart.Count; i++) 
                {                                             
                    _totalPrice += _cart[i].Price;
                }

                return Math.Round(_totalPrice, 2);
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
            set { _password = value; }
        }


        public void CartPresent() {

            if (TotalPrice < 11.85D) {                                                           
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Your Cart Is Currently Empty.");
                // Thread.Sleep(1500);
                Console.ResetColor();

            } else if (_cart != null) {                                                          
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nYour Cart Contains:");
                Console.ResetColor();

                var distinctCart = _cart.Distinct();
                
                foreach (var disctinctProd in distinctCart)                              
                {

                    var ammount = 0;
                    ammount = _cart.Count(x => x == disctinctProd);
                    Console.WriteLine($"{ammount}x {disctinctProd.ProductName} - {disctinctProd.Price} SEK each ");
                }
            }
        }

        public void addToCart(Product product) {                                                
            _cart.Add(product);
            Console.WriteLine("\n1x " + product.ProductName + " added to cart.\n");
        }
        public void ConvertCurrencyUSD(double sek) {                          
           
            _usd = (sek * 0.090D);
            Console.WriteLine($"Price is USD: {Math.Round(_usd, 2)}");
            Console.WriteLine("(Exchange Rate: 0.090)");
        }
        public void ConvertCurrencyEUR(double sek) {                                            
           
            _eur = (sek * 0.092D);
            Console.WriteLine($"Price is EUR: {Math.Round(_eur, 2)}");
            Console.WriteLine("(Exchange Rate 0.092)");
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


        public override string ToString() {                                                       


            var temp = "";

            /*foreach (var item in _cart) 
            {            //_cart
                temp += item.ProductName + "\n";
            }*/

            var distinctCart = _cart.Distinct();

            foreach (var disctinctProd in distinctCart) {

                var ammount = 0;
                ammount = _cart.Count(x => x == disctinctProd);
                temp += $"{ammount}x {disctinctProd.ProductName} - {disctinctProd.Price} SEK each \n";
            }

            return $"\nUsername: {_customerId}\nPassword: {_password}\n\nYour Cart Contains:\n\n{temp}\nTotal Price For Your Cart: {TotalPrice}";
                    



        }


    }


}