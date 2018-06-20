public interface IWareHouse
{
    void EquipArmy(IArmy army);

    void AddAmmunition(string ammunition, int quantity);

    bool TryEquipSoldier(ISoldier soldier);
}

