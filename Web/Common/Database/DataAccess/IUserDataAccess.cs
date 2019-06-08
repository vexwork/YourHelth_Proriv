using System;
using System.Threading;
using System.Threading.Tasks;
using Common.Database.Dto;

namespace Common.Database.DataAccess
{
    public interface IUserDataAccess
    {
        Task<User> GetUserByGuidAsync(Guid userId, CancellationToken cancellationToken);
    }
}