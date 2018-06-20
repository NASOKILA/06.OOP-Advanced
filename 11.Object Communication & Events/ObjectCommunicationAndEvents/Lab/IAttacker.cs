public interface IAttacker : IObserver
{
    void Attack();

    void SetTarget(ITarget target);
}
