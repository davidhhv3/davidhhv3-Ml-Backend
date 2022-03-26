using Backend.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Backend.Models
{
    public class UserCollection : IUserCollection
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<User> Collection;

        public UserCollection()
        {        
            Collection = _repository.db.GetCollection<User>("user");
        }
        public async Task DeleteUser(string id)
        {           
           await Collection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<User> GetUser(string id)
        {
            return await Collection.FindAsync(
                   new BsonDocument { { "_id", new ObjectId(id) } }).Result.
                   FirstAsync();
        }

        public async Task<List<User>> GetUsers()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task InsertUser(User user)
        {
            await Collection.InsertOneAsync(user);
        }

        public async Task UpdateUser(string id,User user)
        {        
            await Collection.ReplaceOneAsync(x => x.Id == id, user);

        }
    }
}
