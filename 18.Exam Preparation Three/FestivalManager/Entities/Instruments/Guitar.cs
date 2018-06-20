namespace FestivalManager.Entities.Instruments
{
    public class Guitar : Instrument
    {
        private const int repairAmount = 60;

        protected override int RepairAmount => repairAmount;
    }
}
