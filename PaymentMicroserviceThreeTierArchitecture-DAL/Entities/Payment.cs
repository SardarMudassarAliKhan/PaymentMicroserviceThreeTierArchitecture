namespace PaymentMicroserviceThreeTierArchitecture_DAL.Entities
{
    public class Payment : BaseEntity
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public Decimal Amout { get; set; }
    }
}
