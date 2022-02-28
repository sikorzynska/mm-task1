namespace MentorMate.Restaurant.Data.Repositories
{
    public abstract class Repository
    {
        protected readonly RestaurantDbContext _dbContext;

        public Repository(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
    }
}
