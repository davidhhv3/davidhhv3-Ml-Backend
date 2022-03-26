namespace Backend.Models
{
    public interface IUserCollection
    {
        Task InsertUser(User user);
        Task UpdateUser(string id, User user);
        Task DeleteUser(string id);
        Task<List<User>> GetUsers();
        Task<User> GetUser(string id);
        
    }
}
