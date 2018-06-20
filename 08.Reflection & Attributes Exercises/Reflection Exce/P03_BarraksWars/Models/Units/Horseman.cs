
namespace _03BarracksFactory.Models.Units
{
    public class Horseman : Unit
    {
        const int DefaultHealth = 50;
        const int DefaultAttack = 10;

        public Horseman()
            :base(DefaultHealth, DefaultAttack)
        { }
    }
}