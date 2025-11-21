using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
// DataAnnotations enable validation attributes such as Required and Range 
// (Microsoft, 2023)

namespace ContractMonthlyClaimsSystem_st10288567_3.Models
{
    public class Claim
    {
        public int Id { get; set; }  // Unique claim identifier (Freeman & Robson, 2020)

        // Lecturer name with validation attributes to ensure quality input data 
        // Required attribute prevents empty submissions (Microsoft, 2023)
        // StringLength ensures reasonable maximum length (Skeet, 2019)
        [Required(ErrorMessage = "Lecturer name is required.")]
        [StringLength(100, ErrorMessage = "Lecturer name cannot be longer than 100 characters.")]
        public string LecturerName { get; set; } = string.Empty;

        // Hours worked must be entered and fall between defined ranges
        // Range attribute enforces numeric boundaries (Troelsen & Japikse, 2021)
        [Required(ErrorMessage = "Hours worked are required.")]
        [Range(0.5, 200, ErrorMessage = "Hours worked must be between 0.5 and 200.")]
        public double HoursWorked { get; set; }

        // Hourly rate uses decimal type due to accuracy in financial calculations 
        // (Liberty & Hurwitz, 2022)
        // Range enforces a valid positive value (Microsoft, 2023)
        [Required(ErrorMessage = "Hourly rate is required.")]
        [Range(typeof(decimal), "0.01", "1000000",
            ErrorMessage = "Hourly rate must be greater than zero.")]
        public decimal HourlyRate { get; set; }

        // Optional notes field to allow additional information from lecturers 
        // StringLength ensures input does not exceed reasonable limits 
        // (Freeman & Robson, 2020)
        [StringLength(500, ErrorMessage = "Notes cannot be longer than 500 characters.")]
        public string Notes { get; set; } = string.Empty;

        // Stores the uploaded file name for referencing evidence documents 
        // (Microsoft, 2023)
        public string FileName { get; set; } = string.Empty;

        // Automatically calculated total claim amount 
        // Display attribute formats the label presented in the UI (Microsoft, 2023)
        // Currency data type makes UI representation clearer (Liberty & Hurwitz, 2022)
        [Display(Name = "Total Amount")]
        [DataType(DataType.Currency)]
        public decimal TotalAmount { get; set; }

        // Workflow status of the claim, defaulting to "Submitted"
        // This supports claim lifecycle management (Troelsen & Japikse, 2021)
        public string Status { get; set; } = "Submitted";

        // Description field allows more detailed information if necessary
        // (Freeman & Robson, 2020)
        public string Description { get; set; } = string.Empty;
    }
}
