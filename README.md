Features:

 Lecturer

Submit monthly work claim

Upload supporting documentation (file upload to wwwroot/uploads)

Auto-calculation of final payment (Hours × Rate)

Track status of submitted claims

 Coordinator:

Review claims with status Submitted

Approve (Verify) or Reject claims

Bulk Auto-Verify function

 Manager:

Review verified claims:

Approve or Reject claims

Bulk Auto-Approve function

 HR:

View approved claims summary

Grouped by Lecturer

Includes totals for:

Hours worked

Total payment value

Number of claims submitted

 System Architecture:

ASP.NET Core MVC

In-Memory Data Storage via ClaimService

Dependency Injection for service sharing across controllers

Validation via Data Annotations

Bootstrap-based UI




ContractMonthlyClaimSystem_st10288567
│── Controllers
│   ├── HomeController.cs
│   ├── LecturerController.cs
│   ├── CoordinatorController.cs
│   ├── ManagerController.cs
│   └── HrController.cs
│
│── Models
│   ├── Claim.cs
│   ├── HrReportRow.cs
│   └── ErrorViewModel.cs
│
│── Services
│   └── ClaimService.cs
│
│── Views
│   ├── Home
│   ├── Lecturer
│   ├── Coordinator
│   ├── Manager
│   ├── Hr
│   └── Shared
│
└── wwwroot
    ├── css/site.css
    └── uploads (auto-created for file storage)


Reference List

Microsoft. 2024. ASP.NET Core MVC documentation. Available at: https://learn.microsoft.com/aspnet/core/mvc/
 (Accessed 19 November 2025).

Microsoft. 2024. File Uploads in ASP.NET Core. Available at: https://learn.microsoft.com/aspnet/core/mvc/models/file-uploads
 (Accessed 19 November 2025).

Microsoft. 2024. Logging in ASP.NET Core. Available at: https://learn.microsoft.com/aspnet/core/fundamentals/logging/
 (Accessed 19 November 2025).

Microsoft. 2024. LINQ in C#. Available at: https://learn.microsoft.com/dotnet/csharp/programming-guide/concepts/linq/
 (Accessed 19 November 2025).
