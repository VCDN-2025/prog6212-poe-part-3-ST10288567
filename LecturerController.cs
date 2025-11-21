using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ContractMonthlyClaimsSystem_st10288567_3.Models;
using ContractMonthlyClaimsSystem_st10288567_3.Services;

namespace ContractMonthlyClaimsSystem_st10288567_3.Controllers
{
    public class LecturerController : Controller
    {
        private readonly ClaimService _claimService;

        // Dependency injection used for injecting ClaimService into the controller 
        // follows recommended ASP.NET Core practices (Microsoft, 2024a).
        public LecturerController(ClaimService claimService)
        {
            _claimService = claimService;
        }

        // GET action used to return an empty form model 
        // consistent with MVC design guidelines (Microsoft, 2024a).
        [HttpGet]
        public IActionResult LecturerPage()
        {
            var model = new Claim();
            return View("SubmitClaim", model);
        }

        // POST action handles form submission and model validation
        // ASP.NET Core recommends validating ModelState before applying logic (Microsoft, 2024b).
        [HttpPost]
        public IActionResult SubmitClaim(Claim claim, IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                // If validation fails, reload the form and retain entered data 
                // (Microsoft, 2024b).
                return View("SubmitClaim", claim);
            }

            // Auto-calculation of payment follows standard arithmetic logic
            // commonly used in payroll systems (Liberty & Hurwitz, 2022).
            claim.TotalAmount = (decimal)claim.HoursWorked * claim.HourlyRate;

            // File upload handling follows ASP.NET Core's recommended file stream approach 
            // ensuring security and correct server path handling (Microsoft, 2024c).
            if (file != null && file.Length > 0)
            {
                var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

                // Ensure upload directory exists to avoid runtime exceptions (Troelsen & Japikse, 2021).
                if (!Directory.Exists(uploads))
                {
                    Directory.CreateDirectory(uploads);
                }

                var filePath = Path.Combine(uploads, file.FileName);

                // FileStream is used to safely write the uploaded file to storage (Microsoft, 2024c).
                using var stream = new FileStream(filePath, FileMode.Create);
                file.CopyTo(stream);

                claim.FileName = file.FileName;
            }

            // Add claim to service layer for processing/storage 
            // ensuring separation of concerns (Freeman & Robson, 2020).
            _claimService.AddClaim(claim);

            TempData["Message"] = "Claim submitted successfully!";
            return RedirectToAction(nameof(LecturerPage));
        }

        // Displays a read-only list of claims using IEnumerable,
        // a standard approach for displaying model collections (Microsoft, 2024a).
        public IActionResult TrackClaims()
        {
            var myClaims = _claimService.GetAll(); // Prototype shows all claims
            return View(myClaims);
        }

        
    }
}
