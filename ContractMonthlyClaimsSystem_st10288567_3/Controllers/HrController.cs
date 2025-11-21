using ContractMonthlyClaimsSystem_st10288567_3.Models;
using ContractMonthlyClaimsSystem_st10288567_3.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContractMonthlyClaimsSystem_st10288567_3.Controllers
{
    public class HrController : Controller
    {
        private readonly ClaimService _claimService;

        // Dependency Injection is recommended for separating concerns and improving maintainability (Microsoft, 2024a).
        public HrController(ClaimService claimService)
        {
            _claimService = claimService;
        }

        // This action generates a report of approved claims, following MVC best practices for separating UI and logic (Microsoft, 2024b).
        public IActionResult ApprovedClaimsReport()
        {
            // Retrieve only claims where the status equals "Approved".
            // Filtering data using LINQ is an efficient way to process collections (Microsoft, 2024c).
            var approvedClaims = _claimService.GetAll()
                .Where(c => c.Status == "Approved")
                .ToList();

            // Group approved claims by lecturer name and calculate totals.
            // LINQ's GroupBy and projection features make aggregation straightforward (Albahari & Albahari, 2022).
            var reportRows = approvedClaims
                .GroupBy(c => c.LecturerName)
                .Select(g => new HrReportRow
                {
                    LecturerName = g.Key,

                    // Sum total hours submitted by each lecturer.
                    TotalHours = g.Sum(c => c.HoursWorked),

                    // Sum total claim amounts per lecturer.
                    TotalAmount = g.Sum(c => c.TotalAmount),

                    // Count how many individual claims the lecturer has submitted.
                    NumberOfClaims = g.Count()
                })

                // Order results alphabetically for usability (Nielsen, 2020).
                .OrderBy(r => r.LecturerName)
                .ToList();

            // Return the completed report to the view.
            return View(reportRows);
        }
    }
}
