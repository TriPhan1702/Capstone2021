﻿using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace HairCutAppAPI.Utilities.Extensions
{
    /// <summary>
    /// Add header for pagination
    /// </summary>
    public static class HttpExtensions
    {
        public static void AddPaginationHeader(this HttpResponse response, int currentPage, int itemsPerPage,
            int totalItems, int totalPages)
        {
            var paginationHeader = new PaginationHeader(currentPage, itemsPerPage, totalItems, totalPages);
            //Option to make pagination Header camel case
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            
            response.Headers.Add("Pagination", JsonSerializer.Serialize(paginationHeader, options));
            response.Headers.Add("Access-Control-Expose-Headers","Pagination");
        }
    }
}