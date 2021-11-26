using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Utilities;
using HairCutAppAPI.Utilities.Errors;
using Microsoft.Data.SqlClient;

namespace HairCutAppAPI.DTOs.PromotionalCodeDTOs
{
    public class UpdatePromotionalCodeDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public decimal Percentage { get; set; }
        public string StartDate { get; set; }
        public string ExpirationDate { get; set; }
        public int IsUniversal { get; set; }
        public int UsesPerCustomer { get; set; }
        public string Status { get; set; }
        public IEnumerable<int> SalonIds { get; set; }

        public PromotionalCode CompareUpdatePromotionalCode(PromotionalCode promotionalCode)
        {
            var hasChanged = false;
            if (!string.IsNullOrWhiteSpace(Code) && Code != promotionalCode.Code)
            {
                promotionalCode.Code = Code;
                hasChanged = true;
            }

            if (Percentage >= 0 && Percentage != promotionalCode.Percentage)
            {
                promotionalCode.Percentage = Percentage;
                hasChanged = true;
            }

            //If IsUniversal != 0 => true, IsUniversal == 0 => false
            if (IsUniversal >= 0)
            {
                promotionalCode.IsUniversal = IsUniversal != 0;
                hasChanged = true;
            }

            if (UsesPerCustomer >= 0 && UsesPerCustomer != promotionalCode.UsesPerCustomer)
            {
                promotionalCode.UsesPerCustomer = UsesPerCustomer;
                hasChanged = true;
            }

            if (!string.IsNullOrWhiteSpace(Status) && Code != promotionalCode.Status)
            {
                promotionalCode.Status = Status;
                hasChanged = true;
            }

            if (hasChanged)
            {
                promotionalCode.LastUpdate = DateTime.Now;
            }
            else
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Nothing can be changed from the information provided");
            }

            return promotionalCode;
        }

        public PromotionalCode CompareUpdatePromotionalCode(PromotionalCode promotionalCode, DateTime startDate , DateTime expirationDate)
        {
            CompareUpdatePromotionalCode(promotionalCode);
            promotionalCode.StartDate = startDate;
            promotionalCode.ExpirationDate = expirationDate;
            promotionalCode.LastUpdate = DateTime.Now;

            return promotionalCode;
        }
    }
}