using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using LocalHandsMiddleware;

namespace LocalHandsAuth.Models
{
    public class User
    {
        public static readonly string DocumentName = nameof(User);

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public string? Salt { get; set; }
        public bool IsAdmin { get; init; }

        public void SetPassword(string password, IEncryptor encryptor)
        {
            Salt = encryptor.GetSalt();
            PasswordHash = encryptor.GetHash(password, Salt);
        }

        public bool ValidatePassword(string password, IEncryptor encryptor) =>
            PasswordHash == encryptor.GetHash(password, Salt);

    }

}
