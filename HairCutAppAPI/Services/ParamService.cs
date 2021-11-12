using System.Threading.Tasks;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services
{
    public class ParamService : IParamService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public ParamService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> GetParams()
        {
            var parameters = await _repositoryWrapper.Param.FindAllAsync();
            return new CustomHttpCodeResponse(200,"", parameters);
        }

        // public async Task<ActionResult<CustomHttpCodeResponse>> ChangeParam()
        // {
        //     var parameter = await _repositoryWrapper.Param.FindByConditionAsync(param => param.Id == id);
        //     
        // }
    }
}