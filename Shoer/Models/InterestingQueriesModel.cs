namespace Shoer.Models
{
    public class InterestingQueriesModel
    {
        public MostLeastSoldCategory3MonthModel MostSoldCategory3MonthModel { get; set; }
        public MostLeastSoldCategory3MonthModel LeastSoldCategory3MonthModel { get; set; }
        public MostLeastSoldShoe3Month MostSoldShoe3Month { get; set; }
        public MostLeastSoldShoe3Month LeastSoldShoe3Month { get; set; }
        public BiggestIncomeShoeModel BiggestIncomeShoe { get; set; }
        public MostLeastSoldBrandThisMonth MostSoldBrandThisMonth { get; set; }
        public MostLeastSoldBrandThisMonth LeastSoldBrandThisMonth { get; set; }
        public MostSpentMoneyCustomerModel MostSpentMoneyCustomer { get; set; }
        public NumberOfOrders3MonthModel NumberOfOrders3Month { get; set; }
        public NumberOfOrdersThisYearModel NumberOfOrdersThisYear { get; set; }
        public NumberOfReturnsThisMonthModel NumberOfReturnsThisMonth { get; set; }
    }
}
