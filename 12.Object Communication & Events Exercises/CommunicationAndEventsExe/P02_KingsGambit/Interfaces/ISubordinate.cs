namespace P02_KingsGambit.Interfaces
{

    public delegate void SubordinatedEventHandler(object sender);

    public interface ISubordinate : INameble, IMortal
    {
        event SubordinatedEventHandler DeathSubordinate;

        string Action { get; }

        void ReactToAttack();
    }
}