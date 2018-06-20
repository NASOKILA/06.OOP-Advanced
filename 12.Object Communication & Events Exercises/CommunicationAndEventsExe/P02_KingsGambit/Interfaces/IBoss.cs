namespace P02_KingsGambit.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IBoss
    {
        IReadOnlyCollection<ISubordinate> Subordinates { get; }

        //metod za dobavqne na podchineni TOVA SAMO KRALQ SHTE GO IMA ZASHTOTO SAMO TOI IMPlementirA IBoss<>
        void AddSubortinate(ISubordinate subordinate);

        void RemoveSubortinate(ISubordinate subordinate);

        void OnSubordinateDeath(object sender);
    }
}
