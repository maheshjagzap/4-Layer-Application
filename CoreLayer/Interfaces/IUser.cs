using CoreLayer.Entities;

namespace CoreLayer.Interfaces
{
    public interface IUser
    {
        Users ValidateUser(string userName, string userPassword);
    }
}
