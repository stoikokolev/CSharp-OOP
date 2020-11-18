using System;

namespace CompositePattern
{
    public class SingleGift : GiftBase
    {
        public SingleGift(string name, int price) : base(name, price)
        {
        }

        public override int CalculateTotalPrice()
        {
            Console.WriteLine($"{this.name} costs {this.price}$.");
            return this.price;
        }
    }
}
