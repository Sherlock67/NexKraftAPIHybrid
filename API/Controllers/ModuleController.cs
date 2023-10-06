using API.BusinessLogic.Interface.Module;
using API.Filters;
using API.ViewModel.ViewModels.Module;
using API.ViewModel.ViewModels.Modules;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace API.Controllers
{

    [Route("api/[controller]"), Produces("application/json"), EnableCors("CORSPolicy")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly IModuleServices moduleServices;
        private readonly IMemoryCache memoryCache;
        public ModuleController(IModuleServices moduleServices,IMemoryCache memoryCache)
        {
            this.moduleServices = moduleServices;
            this.memoryCache = memoryCache;
            
        }
        [HttpPost("[action]")]
        public async Task<object?> CreateModule([FromBody] vmModule data)
        {
            object? resdata = null;
            try
            {
                resdata = await moduleServices.CreateModule(data);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return resdata;

        }
        [HttpGet("[action]")]       
        public async Task<object?> GetModuleList([FromQuery] ModuleData param)
        {
            object? data = null;
            try
            {
                //DateTime currentTime;
                bool isExist = memoryCache.TryGetValue("CacheTime", out data);
                if (!isExist)
                {
                    //currentTime = DateTime.Now;
                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromMilliseconds(30));

                    data = await moduleServices.GetModuleList(param);

                    memoryCache.Set("CacheTime", data, cacheEntryOptions);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return new
            {
                data
            };
        }
        [HttpDelete("DeleteModule/{id:int}")]
        public async Task<object?> DeleteModule(int id)
        {
            object? resdata = null;
            try
            {
                resdata = await moduleServices.DeleteModule(id);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return resdata;
        }
        [HttpPut("UpdateModule"),Authorizations]
        public async Task<object?> UpdateModule(vmModule module)
        {
            object? resdata = null;
            try
            {
                resdata = await moduleServices.UpdateModule(module);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return resdata;
        }
    }
}
