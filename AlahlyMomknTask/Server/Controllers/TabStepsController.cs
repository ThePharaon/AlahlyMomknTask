using AlahlyMomknTask.Models.Business;
using AlahlyMomknTask.Models.Request;
using AlahlyMomknTask.Server.Repositories;
using AlahlyMomknTask.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlahlyMomknTask.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TabStepsController : ControllerBase
    {
        private readonly ITabStepRepository _repository;
        public TabStepsController(ITabStepRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> DoGetAll()
        {
            return Ok(new APIReturnObj<List<TabStep>>
            {
                ReturnValue = await _repository.GetAllAsync(),
                Status = Enums.Requests.APIReturnStatus.Success,
                Message= "Success"
            });
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> DoCreate(TabStep tabStep)
        {
            if(tabStep == null)
                return Ok(new APIReturnObj<object>
                {
                    ReturnValue = null,
                    Status = Enums.Requests.APIReturnStatus.BadRequest,
                    Message = "Sent Data not valid."
                });
            if (tabStep.ID == Guid.Empty) tabStep.ID = Guid.NewGuid();

            await _repository.InsertAsync(tabStep);
            await _repository.SaveChangesAsync();
            return Ok(new APIReturnObj<object>
            {
                ReturnValue = null,
                Status = Enums.Requests.APIReturnStatus.Success,
                Message = "Success"
            });
        }
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> DoUpdate(TabStep tabStep)
        {
            if (tabStep == null)
                return Ok(new APIReturnObj<object>
                {
                    ReturnValue = null,
                    Status = Enums.Requests.APIReturnStatus.BadRequest,
                    Message = "Sent Data not valid."
                });
            // check entity existance

            var entity = await _repository.FirstOrDefaultAsync(ts => ts.ID == tabStep.ID);

            if(entity == null)
                return Ok(new APIReturnObj<object>
                {
                    ReturnValue = null,
                    Status = Enums.Requests.APIReturnStatus.NotFound,
                    Message = "Entity Not Found."
                });

            _repository.Update(entity,tabStep);
            await _repository.SaveChangesAsync();
            return Ok(new APIReturnObj<object>
            {
                ReturnValue = null,
                Status = Enums.Requests.APIReturnStatus.Success,
                Message = "Success"
            });
        }
        [HttpDelete]
        [Route("Delete/{ID}")]
        public async Task<IActionResult> DoDelete(Guid ID)
        {
            if (ID == Guid.Empty)
                return Ok(new APIReturnObj<object>
                {
                    ReturnValue = null,
                    Status = Enums.Requests.APIReturnStatus.BadRequest,
                    Message = "ID not valid."
                });
            // check entity existance
            var entity = await _repository.FirstOrDefaultAsync(ts => ts.ID == ID);

            if (entity == null)
                return Ok(new APIReturnObj<object>
                {
                    ReturnValue = null,
                    Status = Enums.Requests.APIReturnStatus.NotFound,
                    Message = "Entity Not Found."
                });

            _repository.Delete(entity);
            await _repository.SaveChangesAsync();
            return Ok(new APIReturnObj<object>
            {
                ReturnValue = null,
                Status = Enums.Requests.APIReturnStatus.Success,
                Message = "Success"
            });
        }
    }
}
