using Microsoft.AspNetCore.Mvc;

namespace ContractMonthlyClaimsSystem_st10288567_3.Models
{
    // Simple DTO for HR summary reporting
    public class HrReportRow
    {
        public string LecturerName { get; set; } = string.Empty;
        public double TotalHours { get; set; }
        public decimal TotalAmount { get; set; }
        public int NumberOfClaims { get; set; }
    }
}

