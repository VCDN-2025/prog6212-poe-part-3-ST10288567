using ContractMonthlyClaimsSystem_st10288567_3.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContractMonthlyClaimsSystem_st10288567_3.Controllers
{
    public class CoordinatorController : Controller
    {
        private readonly ClaimService _claimService;

        // Dependency injection allows controllers to share service instances and supports
        // loose coupling in ASP.NET Core applications (Microsoft, 2024a).
        public CoordinatorController(ClaimService claimService)
        {
            _claimService = claimService;
        }

        // Displays all claims that are still in the 'Submitted' state.
        // LINQ filtering supports efficient querying of in-memory collections 
        // following .NET best practices (Microsoft, 2023; Troelsen & Japikse, 2021).
        public IActionResult VerifyClaims()
        {
            var submittedClaims = _claimService.GetAll()
                .Where(c => c.Status == "Submitted")       // Filters claims by workflow state (Microsoft, 2023)
                .OrderBy(c => c.LecturerName);             // Sorting improves clarity for users (Freeman & Robson, 2020)

            return View(submittedClaims);
        }

        // Approves an individual claim by updating its status to 'Verified'.
        // Redirecting back to the list view aligns with the Post-Redirect-Get (PRG) pattern
        // to prevent resubmission on page refresh (Microsoft, 2024b).
        public IActionResult Approve(int id)
        {
            _claimService.UpdateClaimStatus(id, "Verified");
            return RedirectToAction(nameof(VerifyClaims));
        }

        // Rejects an individual claim by updating its status.
        // Having separate actions for workflow decisions improves readability
        // and follows the principle of separation of concerns (Liberty & Hurwitz, 2022).
        public IActionResult Reject(int id)
        {
            _claimService.UpdateClaimStatus(id, "Rejected");
            return RedirectToAction(nameof(VerifyClaims));
        }

        // Performs a batch verification of all submitted claims.
        // Bulk processing is recommended for administrative tasks to improve efficiency
        // in high-volume workflows (Microsoft, 2024c).
        [HttpPost]
        public IActionResult AutoVerifyAll()
        {
            var submittedClaims = _claimService.GetAll()
                .Where(c => c.Status == "Submitted")    // LINQ bulk filter (Microsoft, 2023)
                .ToList();

            // Loop updates each claim—an example of a batch operation that reduces repetitive actions
            // and improves system usability for coordinators (Troelsen & Japikse, 2021).
            foreach (var claim in submittedClaims)
            {
                _claimService.UpdateClaimStatus(claim.Id, "Verified");
            }

            return RedirectToAction(nameof(VerifyClaims));
        }
    }
}
