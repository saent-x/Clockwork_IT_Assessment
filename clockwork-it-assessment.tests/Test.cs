using Xunit;
using clockwork_it_assessment.lib;

namespace clockwork_it_assessment.tests;

public class Tests
{
    [Fact]
    public void UtilityGetInventoryFunctionTest()
    {
        var inventory = Utility.GetInventory();

        Assert.NotEmpty(inventory);
        Assert.NotNull(inventory);
    }

    [Fact]
    public void UtilityGetItemFunctionTest(){
        var item = Utility.GetItem("bread") ?? new PriceBasketItem("",0);

        Assert.Equal("bread",item.Name);
        Assert.NotEqual<decimal>(0,item.Price);
    }

    [Fact]
    public void PriceBasketCreationTest(){
        var priceBasket = new PriceBasket("apples", "soup", "bread");

        Assert.Equal<int>(3, priceBasket.items.Count);
    }

    [Fact]
    public void AccountForSpecialOffersTest(){
        var priceBasket = new PriceBasket("apples", "soup", "bread","soup");
        priceBasket.AccountForSpecialOffers();

        Assert.Contains<string>("Apples 10% off: -10p", priceBasket.special_offers);
        Assert.Contains<string>("Free Loaf of bread 50% off: -40p", priceBasket.special_offers);

    }

    [Fact]
    public void CalculatePriceBasketTotalTest(){
        var priceBasket = new PriceBasket("apples", "soup", "bread","soup");
        priceBasket.AccountForSpecialOffers();
        
        Assert.Equal<decimal>(3.4m, priceBasket.final_total);
    }
}