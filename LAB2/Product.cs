
namespace LAB2
{
    public class Product

    {

    private double _price;
    private string _productName;
    public int ProductId;

    public string ProductName
    {
        get { return _productName; }
        set { _productName = value; }
    }

    public double Price
    {
        get { return _price; }
        set { _price = value; }
    }

    public void MenuPresent()
    {

        Console.ForegroundColor = ConsoleColor.White;
        Console.Write($"\n{ProductId}) {ProductName}");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\nPrice / HG:  ");
        Console.Write($"{Price} - SEK\n");

    }


    }
}

