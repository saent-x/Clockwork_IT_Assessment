namespace clockwork_it_assessment.lib;
public class PriceBasketItem
{

    public string Name { get; set; }
    public decimal Price { get; set; }

    public PriceBasketItem(string name, decimal price) => (Name, Price) = (name, price);
}