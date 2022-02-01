using System;
using System.Collections.Generic;

namespace clockwork_it_assessment.lib;

public class PriceBasket{

    public List<PriceBasketItem> items = new List<PriceBasketItem>();
    public decimal final_total = 0;
    public decimal sub_total = 0;
    public List<string> special_offers = new List<string>();


    public PriceBasket(params string[] arr){
        foreach (var _item in arr)
        {
            // Identify item in inventory
            var item = Utility.GetItem(_item);

            // Add if item exists
            if(item != null){
                this.items.Add(item);
            }
        }

        // calculate sub-total
        this.sub_total = CalculateTotal(this.items);
    }

    private decimal CalculateTotal(List<PriceBasketItem> _items){
        decimal total = 0;
        // calculate subtotal
        foreach (var item in _items)
            total += item.Price;

        return total;
    }

    public void AccountForSpecialOffers(){
        // two type of discount checks
        // 1. Apples 10%
        // 2. two tins of soup, get bread for [price]/2

        var soupCounter = 0;
        var newlyAdded = new List<PriceBasketItem>();

        foreach (var item in this.items)
        {
            if(item.Name == "apples"){
                item.Price -= (10m / 100m) * item.Price;
                // add offer
                this.special_offers.Add("Apples 10% off: -10p");
            }else if (item.Name == "soup"){
                ++soupCounter;

                if(soupCounter == 2){
                    // Add loaf of bread for half price
                    var bread = new PriceBasketItem("bread", 0.40m);
                    newlyAdded.Add(bread);

                    // reset counter
                    soupCounter = 0;

                    // add offer
                    this.special_offers.Add("Free Loaf of bread 50% off: -40p");
                }
            }
        }
        // update list
        this.items.AddRange(newlyAdded);

        // calculate final total
        this.final_total = CalculateTotal(this.items);
    }

    public void PrintReceipt()
    {
        // return the result

        Console.WriteLine($"\n** Subtotal: £{this.sub_total}");
        if(this.special_offers.Count == 0){
            Console.WriteLine("** ( no offers available )");
        }
        this.special_offers.ForEach(offer => Console.WriteLine($"** {offer}"));
        Console.WriteLine($"** Total: £{Math.Round(this.final_total,2)}");
    }
}