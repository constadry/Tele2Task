using Tele2Task.Models;

namespace Tele2Task.Communication;

public class UserResponse : BaseResponse
{
    private UserResponse(bool success, string message, User? user)
        : base(success, message)
    {
        User = user;
    }

    public UserResponse(User? user) :
        this(true, string.Empty, user)
    {
    }

    public UserResponse(string message) :
        this(false, message, null)
    {
    }

    public User? User { get; }
}