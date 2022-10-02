using System.Globalization;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.VisualBasic.CompilerServices;

namespace LAB2;

public class Customer {

    private double _usd = 0.090D;
    private double _eur = 0.092D;
    private double _sek = 1.00D;
    private double _totalPrice;
    private string _customerId;
    private string _password;

    private List<Product> _cart;                                // Skapa en kundlista

    public List<Product> Cart {
        get {
            return _cart;
        }
        set {

        }

    }
    public double TotalPrice {
        get {
            _totalPrice = 0.0;

            for (int i = 0; i < _cart.Count; i++) {
                _totalPrice += _cart[i].Price;
            }
            return _totalPrice;

        }
        set {

            _totalPrice += TotalPrice;             // testa dig fram

        }
    }

    public string CustomerId {

        get {
            return _customerId;
        }
        private set {

            _customerId = value;
        }
    }

    public string Password {
        get {
            return _password;
        }
        set {
            _password = value;
        }
    }

    public static Customer NewCustomer() {
        Console.WriteLine("Pick a username");
        string customerId = Console.ReadLine();
        Console.WriteLine("Choose a password");                         // se till att kunna lägga in den i listan
        string password = Console.ReadLine();
        Customer cust = new Customer(customerId, password);
        return cust;

    }

    public void CartPresent() {                                     // Maybe try catch

        if (_cart == null) {
            Console.WriteLine("Your Cart Is Empty");

        } else if (_cart != null) {
            Console.WriteLine($"Your cart does currently contains:");
            for (int i = 0; i < _cart.Count; i++) {

                Console.WriteLine(_cart[i].ProductName + ", " + _cart[i].Price + " SEK");

            }
        }
    }

    public void addToCart(Product product) {
        _cart.Add(product);
        Console.WriteLine(product.ProductName + " added to cart.");
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
    }
}