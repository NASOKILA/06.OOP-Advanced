public interface ITarget : ISubject
{
    void ReceiveDamage(int damage);

    bool IsDead { get; }

}