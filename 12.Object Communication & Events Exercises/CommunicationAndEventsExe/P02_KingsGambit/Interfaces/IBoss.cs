namespace P02_KingsGambit.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IBoss
    {
        IReadOnlyCollection<ISubordinate> Subordinates { get; }

        void AddSubortinate(ISubordinate subordinate);

        void RemoveSubortinate(ISubordinate subordinate);

        void OnSubordinateDeath(object sender);
    }
}
