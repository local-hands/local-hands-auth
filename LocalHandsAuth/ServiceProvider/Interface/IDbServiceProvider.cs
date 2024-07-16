using LocalHandsAuth.Models;

namespace LocalHandsAuth.ServiceProvider.Interface
{
    public interface IDbServiceProvider
    {
        User? GetUser(string email);
        void InsertUser(User user);
    }
}


