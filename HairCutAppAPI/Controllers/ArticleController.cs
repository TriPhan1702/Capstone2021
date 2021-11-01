using System.Threading.Tasks;
using HairCutAppAPI.DTOs.ArticleDTOs;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Controllers
{
    public class ArticleController : BaseApiController
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }
        
        /// <summary>
        /// For Admin and Manager to create new article
        /// </summary>
        [Authorize(Roles = GlobalVariables.AdministratorRole + ", " + GlobalVariables.ManagerRole)]
        [HttpPost("create_article")]
        public async Task<ActionResult<CustomHttpCodeResponse>> CreateArticle([FromBody] CreateArticleDTO dto)
        {
            //Trim All Strings in object
            dto = ObjectTrimmer.TrimObject(dto) as CreateArticleDTO;
            
            //Check input server side
            if (!ModelState.IsValid)
            {
                return new CustomHttpCodeResponse(400,"",ModelState);
            }

            return await _articleService.CreateArticle(dto);
        }
        
        /// <summary>
        /// For admin, manager, staff to get Detail of an article
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = GlobalVariables.AdministratorRole + ", " + GlobalVariables.ManagerRole + ", " + GlobalVariables.StylistRole + ", " + GlobalVariables.BeauticianRole)]
        [HttpGet("get_article/{id}")]
        public async Task<ActionResult<CustomHttpCodeResponse>> GetArticleDetail(int id)
        {
            return await _articleService.GetArticleDetail(id);
        }
        
        /// <summary>
        /// For Admin to update article
        /// </summary>
        /// <param name="dto"> Empty ot null fields will not be changed, negative duration = null. If Services == null => no change, if Services is empty list => combo has no service</param>
        [Authorize(Roles = GlobalVariables.AdministratorRole)]
        [HttpPut("update_article")]
        public async Task<ActionResult<CustomHttpCodeResponse>> UpdateCombo([FromBody] UpdateArticleDTO dto)
        {
            //Trim All Strings in object
            dto = ObjectTrimmer.TrimObject(dto) as UpdateArticleDTO;
            
            //Check input server side
            if (!ModelState.IsValid)
            {
                return new CustomHttpCodeResponse(400,"",ModelState);
            }

            return await _articleService.UpdateArticle(dto);
        }
        
        /// <summary>
        /// For Admin and Manager to deactivate article
        /// </summary>
        /// <param name="dto"> Empty ot null fields will not be changed, negative duration = null. If Services == null => no change, if Services is empty list => combo has no service</param>
        [Authorize(Roles = GlobalVariables.AdministratorRole + ", " + GlobalVariables.ManagerRole)]
        [HttpPut("deactivate_article/{id}")]
        public async Task<ActionResult<CustomHttpCodeResponse>> DeactivateArticle(int id)
        {
            return await _articleService.DeActivateArticle(id);
        }
        
        /// <summary>
        /// For Admin and Manager to activate article
        /// </summary>
        /// <param name="dto"> Empty ot null fields will not be changed, negative duration = null. If Services == null => no change, if Services is empty list => combo has no service</param>
        [Authorize(Roles = GlobalVariables.AdministratorRole + ", " + GlobalVariables.ManagerRole)]
        [HttpPut("activate_article/{id}")]
        public async Task<ActionResult<CustomHttpCodeResponse>> ActivateArticle(int id)
        {
            return await _articleService.ActivateArticle(id);
        }
        
        /// <summary>
        /// For admin, manager and staff
        /// </summary>
        [Authorize(Roles = GlobalVariables.AdministratorRole + ", " + GlobalVariables.ManagerRole + ", " + GlobalVariables.StylistRole + ", " + GlobalVariables.BeauticianRole)]
        [HttpPost("advanced_get_combos")]
        public async Task<ActionResult<CustomHttpCodeResponse>> AdvancedGetCombos(
            AdvancedGetArticleDTO dto)
        {
            //Trim All Strings in object
            dto = ObjectTrimmer.TrimObject(dto) as AdvancedGetArticleDTO;
            var articles = await _articleService.AdvancedGetArticles(dto);
            return articles;
        }
        
        /// <summary>
        /// For customer
        /// </summary>
        [Authorize]
        [HttpPost("customer_advanced_get_combos")]
        public async Task<ActionResult<CustomHttpCodeResponse>> CustomerAdvancedGetCombos(
            CustomerAdvancedGetArticleDTO dto)
        {
            //Trim All Strings in object
            dto = ObjectTrimmer.TrimObject(dto) as CustomerAdvancedGetArticleDTO;
            var articles = await _articleService.CustomerAdvancedGetArticles(dto);
            return articles;
        }
    }
}