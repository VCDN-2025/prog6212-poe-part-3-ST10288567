using System.Collections.Generic;
using System.Linq;
// LINQ namespace required for Any(), Max(), FirstOrDefault() 
// (Microsoft, 2023)

using ContractMonthlyClaimsSystem_st10288567_3.Models;

namespace ContractMonthlyClaimsSystem_st10288567_3.Services
{
    public class ClaimService
    {
        // List used as in-memory data storage for Claim objects 
        // (Liberty & Hurwitz, 2022)
        private readonly List<Claim> _claims;

        // Constructor initializes an empty claim list when the service is instantiated 
        // (Skeet, 2019)
        public ClaimService()
        {
            _claims = new List<Claim>();
        }

        // Returns all stored claims (providing read-only enumeration)
        // Good practice for encapsulation and data safety 
        // (Freeman & Robson, 2020)
        public IEnumerable<Claim> GetAll() => _claims;

        // Adds a new claim and automatically assigns an incremental unique ID 
        // Uses LINQ Max() to determine highest existing ID 
        // (Microsoft, 2023)
        public void AddClaim(Claim claim)
        {
            // Auto-increment ID logic: if no claims yet, start at 1 
            // (Troelsen & Japikse, 2021)
            claim.Id = _claims.Any() ? _claims.Max(c => c.Id) + 1 : 1;

            _claims.Add(claim);
            // Adds claim to the in-memory list 
            // (Liberty & Hurwitz, 2022)
        }

        // Updates the status of an existing claim based on its ID
        // FirstOrDefault() retrieves the matching claim or null if not found 
        // (Microsoft, 2023)
        public void UpdateClaimStatus(int id, string status)
        {
            var claim = _claims.FirstOrDefault(c => c.Id == id);

            // Null check ensures safe modification of object properties 
            // (Skeet, 2019)
            if (claim != null)
            {
                claim.Status = status;
            }
        }
    }
}
