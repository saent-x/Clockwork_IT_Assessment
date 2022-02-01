using System;
using clockwork_it_assessment.lib;

namespace clockwork_it_assessment;

class Program
{
    static void Main(string[] args)
    {
        start:
        Console.WriteLine("\nName: Vangerwua John Paul");
        Console.WriteLine("Title: Clockwork IT Assessment");
        Console.WriteLine("------------------------------\n");
        Console.Write("# PriceBasket | ");
        var items_input = Console.ReadLine();
        if(items_input == null){
            Console.Clear();
            goto start;
        }
        var items = items_input.Split(" ");
        // create price backet
        PriceBasket priceBasket = new PriceBasket(items);
        // apply special offers
        priceBasket.AccountForSpecialOffers();
        // print receipt
        priceBasket.PrintReceipt();
        Console.WriteLine("\n# type 'q' to quit or enter to continue: ");
        var ans = Console.ReadLine() ?? "";
        if(ans.ToLowerInvariant() == "q"){
            Environment.Exit(0);
        }else
        {
            Console.Clear();
            goto start;
        }
    }
}


