using System.ComponentModel.DataAnnotations;
using System.Net;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Utilities;
using HairCutAppAPI.Utilities.Errors;
using Microsoft.AspNetCore.Http;

namespace HairCutAppAPI.DTOs.CustomerDTO
{
    public class UpdateCustomerDTO
    {
        [MinLength(3)]
        [MaxLength(50)]
        public string FullName { get; set; }
        
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(GlobalVariables.PhoneNumberRegex, ErrorMessage = GlobalVariables.PhoneNumberRegexMessage)]
        public string PhoneNumber { get; set; }

        public Customer CompareAndUpdateCustomer(Customer customer)
        {
            var hasChanged = false;
            if (!string.IsNullOrWhiteSpace(FullName) && FullName.ToLower() != customer.FullName)
            {
                customer.FullName = FullName;
                customer.User.FullName = FullName;
                hasChanged = true;
            }

            if (!string.IsNullOrWhiteSpace(PhoneNumber) && PhoneNumber != customer.User.PhoneNumber)
            {
                customer.User.PhoneNumber = PhoneNumber;
                hasChanged = true;
            }

            if (!hasChanged)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"Nothing can be changed with the provided information");
            }

            return customer;
        }
    }
}