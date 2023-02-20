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
    public class StepItemsController : ControllerBase
    {
        private readonly IStepItemRepository _repository;
        public StepItemsController(IStepItemRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        [Route("GetAll/{StepID}")]
        public async Task<IActionResult> DoGetAll(Guid StepID)
        {
            return Ok(new APIReturnObj<List<StepItem>>
            {
                ReturnValue = await _repository.GetAllAsync(si=>si.TabStepID ==  StepID),
                Status = Enums.Requests.APIReturnStatus.Success,
                Message= "Success"
            });
        }

        [HttpGet]
        [Route("GetByID/{ID}")]
        public async Task<IActionResult> DoGetByID(Guid ID)
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

            return Ok(new APIReturnObj<StepItem>
            {
                ReturnValue = entity,
                Status = Enums.Requests.APIReturnStatus.Success,
                Message = "Success"
            });
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> DoCreate(StepItem stepItem)
        {
            if(stepItem == null)
                return Ok(new APIReturnObj<object>
                {
                    ReturnValue = null,
                    Status = Enums.Requests.APIReturnStatus.BadRequest,
                    Message = "Sent Data not valid."
                });
            if (stepItem.ID == Guid.Empty) stepItem.ID = Guid.NewGuid();

            await _repository.InsertAsync(stepItem);
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
        public async Task<IActionResult> DoUpdate(StepItem stepItem)
        {
            if (stepItem == null)
                return Ok(new APIReturnObj<object>
                {
                    ReturnValue = null,
                    Status = Enums.Requests.APIReturnStatus.BadRequest,
                    Message = "Sent Data not valid."
                });
            // check entity existance

            var entity = await _repository.FirstOrDefaultAsync(ts => ts.ID == stepItem.ID);

            if(entity == null)
                return Ok(new APIReturnObj<object>
                {
                    ReturnValue = null,
                    Status = Enums.Requests.APIReturnStatus.NotFound,
                    Message = "Entity Not Found."
                });

            _repository.Update(entity,stepItem);
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
