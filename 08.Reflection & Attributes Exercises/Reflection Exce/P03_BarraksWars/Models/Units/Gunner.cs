
namespace _03BarracksFactory.Models.Units
{
    public class Gunner : Unit
    {
        const int DefaultHealth = 20;
        const int DefaultAttack = 20;

        public Gunner()
            :base(DefaultHealth, DefaultAttack)
        {}
    }
}