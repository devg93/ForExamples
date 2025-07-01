
using Microsoft.EntityFrameworkCore;
using User.Domain;
using User.Domain.Abstractions.PersistenceContracts;

namespace User.Infrastruqture.Persistence
{
    public class UserDb(DataAcsess dataAcsess) : IUserRepository
    {
        public async Task<string> CreateAsync(EUser user)
        {
            await dataAcsess.Users.AddAsync(user);
            await dataAcsess.SaveChangesAsync();

            return user.Id.ToString();

        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            await dataAcsess.Users
                .Where(u => u.Id == id)
                .ExecuteDeleteAsync();
            await dataAcsess.SaveChangesAsync();
            return true;

        }

        public async Task<IEnumerable<EUser>> GetAllAsync()
        {
            await dataAcsess.Users
                .ToListAsync();
            return dataAcsess.Users.AsEnumerable();

        }

        public async Task<EUser?> GetByEmailAsync(string email)
        {
            return await dataAcsess.Users
                   .Where(u => u.Email.Value == email)
                   .FirstOrDefaultAsync();

        }

        public Task<EUser?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<EUser?> GetByLastNameAsync(string lastName)
        {
            throw new NotImplementedException();
        }

        public Task<EUser?> GetByNameAsync(string firstName, string lastName)
        {
            throw new NotImplementedException();
        }

        public Task<EUser?> GetByPhoneNumberAsync(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(EUser user)
        {
            throw new NotImplementedException();
        }
    }
}