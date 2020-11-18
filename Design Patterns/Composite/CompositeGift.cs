using System.Collections.Generic;
using System.Linq;

namespace CompositePattern
{
    public class CompositeGift : GiftBase, IGiftOperations
    {
        private readonly ICollection<GiftBase> gifts;

        public CompositeGift(string name, int price) : base(name, price)
        {
            this.gifts = new List<GiftBase>();
        }

        public override int CalculateTotalPrice() => this.gifts.Sum(gift => gift.CalculateTotalPrice());

        public void Add(GiftBase gift) => this.gifts.Add(gift);

        public void Remove(GiftBase gift) => this.gifts.Remove(gift);

    }
}
