using System.Security.Claims;

namespace MoneyMinder.API.Services;

internal sealed class UserService : IUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    
    
    private ClaimsPrincipal User => _httpContextAccessor.HttpContext.User;
    
    public Guid GetAccountId()
    {
        var result = Guid.Empty;

        var stringResult = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (stringResult is not null)
        {
            result = new Guid(stringResult);
        }
        
        return result;
    }

}