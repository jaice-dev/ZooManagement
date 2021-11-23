namespace ZooManagement.Repositories
{
    public interface IAnimalsRepo
    {
        
    }
    public class AnimalsRepo : IAnimalsRepo
    {
        private readonly ZooManagementDbContext _context;

        public AnimalsRepo(ZooManagementDbContext context)
        {
            _context = context;
        }
        
        
    }
}