using System;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common.Database.DataAccess.Implementation.Context;
using Common.Database.Dto;

namespace Common.Database.DataAccess.Implementation
{
    public class UserDataAccess : IUserDataAccess, IDisposable
    {
        private readonly YourHelthContext _context;

        public UserDataAccess()
        {
            _context = new YourHelthContext();
        }

        public Task<User> GetUserByGuidAsync(Guid userId, CancellationToken cancellationToken)
        {
            return _context.Users.Where(user => user.Guid == userId).FirstOrDefaultAsync(cancellationToken);
        }

        public Task AddAsync(User user, CancellationToken cancellationToken)
        {
            _context.Users.Add(user);
            return _context.SaveChangesAsync(cancellationToken);
        }

        void IDisposable.Dispose()
        {
            _context.Dispose();
        }
    }
}