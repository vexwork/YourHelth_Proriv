using System;
using System.Threading;
using System.Threading.Tasks;
using Common.Database.Dto;

namespace Common.Database.DataAccess.Implementation
{
    internal class UserDataAccess : IUserDataAccess
    {
        public Task<User> GetUserByGuidAsync(Guid userId, CancellationToken cancellationToken)
        {
            return Task.FromResult(new
                User
                {
                    Guid = Guid.NewGuid(),
                    Name = "Vasya",
                }
            );
        }
    }
}