namespace FullTimeForceTest.Api.Models
{
    public class CalculateSalaryResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Antiquity { get; set; }
        public double PriceHour { get; set; }
        public double TotalHoursWork { get; set; }
        public double TotalGrossCharge { get; set; }
        public double TotalDiscounts { get; set; }
        public double NetoPayment { get; set; }
    }
}
