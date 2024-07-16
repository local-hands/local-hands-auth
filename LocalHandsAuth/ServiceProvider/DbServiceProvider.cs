using LocalHandsAuth.Models;
using MongoDB.Driver;


namespace LocalHandsAuth.ServiceProvider
{
    public class DbServiceProvider(IMongoDatabase db) : Interface.IDbServiceProvider
    {

        private readonly IMongoCollection<User> _col = db.GetCollection<User>(User.DocumentName);
        public User? GetUser(string email) =>
                _col.Find(u => u.Email == email).FirstOrDefault();

        public void InsertUser(User user) =>
            _col.InsertOne(user);
    }
}
