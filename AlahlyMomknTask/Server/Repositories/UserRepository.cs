using AlahlyMomknTask.Enums.Requests;
using AlahlyMomknTask.Models.Business;
using AlahlyMomknTask.Models.Request;
using AlahlyMomknTask.Server.Services;

namespace AlahlyMomknTask.Server.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<APIReturnObj<User>> DoLogin(LoginData loginData);
    }
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(MainDBContext context) : base(context)
        {

        }

        public async Task<APIReturnObj<User>> DoLogin(LoginData loginData)
        {
            if (loginData == null)
                return new()
                {
                    ReturnValue = null,
                    Status = APIReturnStatus.BadRequest,
                    Message = "Sent Data not valid."
                };

            var user = await FirstOrDefaultAsync(u=> u.Username == loginData.Username || u.Email == loginData.Username);
            if(user == null)
                return new()
                {
                    ReturnValue = null,
                    Status = APIReturnStatus.WrongUser,
                    Message = "User Not Exist."
                };

            if (!user.IsActive)
                return new()
                {
                    ReturnValue = null,
                    Status = APIReturnStatus.NotActive,
                    Message = "User Not Active."
                };
            if (!BCrypt.Net.BCrypt.Verify(loginData.Password, user.Password))
                return new()
                {
                    ReturnValue = null,
                    Status = APIReturnStatus.WrongPassword,
                    Message = "Wrong Password."
                };

            user.Password = string.Empty;
            user.Token = TokenHandler.CreateToken(user, loginData.Remember);
            return new()
            {
                ReturnValue = user,
                Status = APIReturnStatus.Success,
                Message = "Logged In"
            };
        }
    }
}
