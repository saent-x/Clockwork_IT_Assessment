using System;
using System.Collections.Generic;

namespace clockwork_it_assessment.lib;

public static class Utility{
    public static List<PriceBasketItem> GetInventory(){
    
        var soup = new PriceBasketItem("soup", 0.65m);
        var bread = new PriceBasketItem("bread", 0.80m);
        var milk = new PriceBasketItem("milk", 1.30m);
        var apples = new PriceBasketItem("apples", 1.00m);

        // Add items to inventory
        var inventory = new List<PriceBasketItem>{soup, bread, milk, apples};

        return inventory;
    }

    public static PriceBasketItem? GetItem(string itemName){
        var inventory = GetInventory();

        var item = inventory.Find(item => item.Name.ToLowerInvariant() == itemName.ToLowerInvariant());

        if(item == null){
            Console.WriteLine($"# [{itemName}] not available ---skipping");
            return null;
        }

        return item;
    }
}