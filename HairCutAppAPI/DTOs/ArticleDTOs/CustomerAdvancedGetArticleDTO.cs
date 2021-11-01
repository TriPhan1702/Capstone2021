using System.Collections.Generic;
using System.Collections.ObjectModel;
using HairCutAppAPI.Utilities;

namespace HairCutAppAPI.DTOs.ArticleDTOs
{
    public class CustomerAdvancedGetArticleDTO : PaginationParams
    {
        public static ReadOnlyCollection<string> OrderingParams { get; } = new ReadOnlyCollection<string>(
            new string[] { 
                "id_asc", "id_desc", 
                "authoruserid_asc", "authoruserid_desc", 
                "authorname_asc", "authorname_desc",
                "tittle_asc", "tittle_desc", 
                "createddate_asc","createddate_desc",
                "lastupdate_asc","lastupdate_desc",
            }
        );
        
        public IEnumerable<int> FilterIds { get; set; }
        public IEnumerable<int> AuthorUserIds { get; set; }
        public string FilterTittle { get; set; }
        public string MinCreatedDate { get; set; }
        public string MaxCreatedDate { get; set; }
        public string MinLastUpdate { get; set; }
        public string MaxLastUpdate { get; set; }
        public string SortBy { get; set; }

        public AdvancedGetArticleDTO ToAdvancedGetArticleDTO()
        {
            return new AdvancedGetArticleDTO()
            {
                FilterIds = FilterIds,
                FilterStatuses = new List<string>(){GlobalVariables.ActiveArticleStatus},
                FilterTittle = FilterTittle,
                PageNumber = PageNumber,
                PageSize = PageSize,
                SortBy = SortBy,
                AuthorUserIds = AuthorUserIds,
                MaxCreatedDate = MaxCreatedDate,
                MaxLastUpdate = MaxLastUpdate,
                MinCreatedDate = MinCreatedDate,
                MinLastUpdate = MinLastUpdate,
            };
        }
    }
}