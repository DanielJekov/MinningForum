namespace MF.Services.Users
{
    using MF.Data;

    public class UsersService : IUsersService
    {
        private readonly MFDbContext data;

        public UsersService(MFDbContext data)
        {
            this.data = data;
        }
    }
}
