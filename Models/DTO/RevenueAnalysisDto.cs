namespace APIPractice.Models.DTO
{
    public class RevenueAnalysisDto
    {
        public decimal TotalSales { get; set; }
        public decimal AvgOrderValue { get; set; }
        public int ActiveCustomers { get; set; }
        public int TotalOrders { get; set; }
        public int PendingOrders { get; set; }
        public int CompletedOrders { get; set; }
        public required object MostSoldProduct { get; set; }
        public List<YearlyReveneDto> YearlyRevenue { get; set; } = new List<YearlyReveneDto>();
    }
}
