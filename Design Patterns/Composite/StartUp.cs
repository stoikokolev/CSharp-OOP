using System;

namespace CompositePattern
{
    public class StartUp
    {
        static void Main()
        {
            var phone = new SingleGift("Phone", 256);
            phone.CalculateTotalPrice();
            
            var rootBox = new CompositeGift("RootBox", 0);
            var truckToy = new SingleGift("Truck", 289);
            var planeToy = new SingleGift("Plane", 587);
            
            rootBox.Add(truckToy);
            rootBox.Add(planeToy);
            
            var childBox = new CompositeGift("ChildBox",0);
            var soldierToy = new SingleGift("Soldier", 200);
            childBox.Add(soldierToy);

            rootBox.Add(childBox);
            
            Console.WriteLine($"Total price of gifts is {rootBox.CalculateTotalPrice()}$");
            
        }
    }
}
