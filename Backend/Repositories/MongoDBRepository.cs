using MongoDB.Driver;

namespace Backend.Repositories
{
    public class MongoDBRepository
    {
        public MongoClient client;

        public IMongoDatabase db;

        public MongoDBRepository()
        {
            client = new MongoClient("mongodb+srv://David:pDavid@clusterdb.uzs0q.mongodb.net/mlDb?retryWrites=true&w=majority");
            db = client.GetDatabase("mlDb");
        }
    }
}
