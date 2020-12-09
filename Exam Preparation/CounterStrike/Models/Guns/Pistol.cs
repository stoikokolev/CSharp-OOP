namespace CounterStrike.Models.Guns
{
    public class Pistol : Gun
    {
        private const int FireRate = 1;

        public Pistol(string name, int bullets)
            : base(name, bullets)
        {

        }

        public override int Fire()
        {
            if (this.BulletsCount - FireRate < 0) return 0;
            this.BulletsCount-=FireRate;
            return FireRate;
        }
    }
}