using Domain.Model;

namespace Domain.Repository
{
    public interface IRepository
    {
        List<User> GetUsers();
    }
}