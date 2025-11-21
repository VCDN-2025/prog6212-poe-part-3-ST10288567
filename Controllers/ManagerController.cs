using ContractMonthlyClaimsSystem_st10288567_3.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContractMonthlyClaimsSystem_st10288567_3.Controllers
{
    public class ManagerController : Controller
    {
        private readonly ClaimService _claimService;

        // Dependency injection enables reuse of ClaimService across multiple controllers,
        // supporting unified approval workflows (Microsoft, 2024a).
        public ManagerController(ClaimService claimService)
        {
            _claimService = claimService;
        }

        // Displays only claims in "Verified" status.
        // Filtering and ordering data before rendering improves usability and follows MVC 
        // best practices (Microsoft, 2024a; Freeman & Robson, 2020).
        public IActionResult ApproveClaims()
        {
            var verifiedClaims = _claimService.GetAll()
                .Where(c => c.Status == "Verified")  // LINQ query for filtering (Microsoft, 2023)
                .OrderBy(c => c.LecturerName);       // Sorting improves manager workflow readability (Troelsen & Japikse, 2021)

            return View(verifiedClaims);
        }

        // Updates a claim to "Approved".
        // Redirecting after modifying data follows the Post-Redirect-Get (PRG) pattern 
        // to avoid duplicate submissions (Microsoft, 2024b).
        public IActionResult Approve(int id)
        {
            _claimService.UpdateClaimStatus(id, "Approved");
            return RedirectToAction(nameof(ApproveClaims));
        }

        // Rejecting a claim handled in a dedicated action to maintain clear separation
        // of responsibilities (Microsoft, 2024a; Liberty & Hurwitz, 2022).
        public IActionResult Reject(int id)
        {
            _claimService.UpdateClaimStatus(id, "Rejected");
            return RedirectToAction(nameof(ApproveClaims));
        }

        // Batch approval action for efficiency, commonly used in administrative systems 
        // for speeding up decision workflows (Microsoft, 2024c).
        [HttpPost]
        public IActionResult AutoApproveAll()
        {
            var verifiedClaims = _claimService.GetAll()
                .Where(c => c.Status == "Verified")  // LINQ bulk filtering (Microsoft, 2023)
                .ToList();

            // Looping through filtered records to apply a bulk update
            // supports managerial efficiency and reduces repetitive actions 
            // (Troelsen & Japikse, 2021).
            foreach (var claim in verifiedClaims)
            {
                _claimService.UpdateClaimStatus(claim.Id, "Approved");
            }

            return RedirectToAction(nameof(ApproveClaims));
        }
    }
}
