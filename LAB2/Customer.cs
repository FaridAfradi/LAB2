namespace LAB2;

public class Customer {


    private string _customerId;
    private string _password;
    private List<Product> _cart;

    public List<Product> Cart {
        get {
            return _cart;
        }

    }


    public string CustomerId {
        get {
            return _customerId;
        }
        set {
            _customerId = value;
        }
    }



    public string Password {
        get {
            return Password;
        }
        set {
            Password = value;
        }
    }

    public Customer() {

    }
    public void CartPresent() {
        Console.WriteLine($"Your cart currently contains {Product}");

    }



}