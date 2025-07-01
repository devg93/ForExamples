

namespace User.Domain.Abstractions.PersistenceContracts;

public interface IUserRepository
{
    public Task<string> CreateAsync(EUser user);
    public Task<bool> UpdateAsync(EUser user);
    public Task<bool> DeleteAsync(Guid id);



    public Task<IEnumerable<EUser>> GetAllAsync();
    public Task<EUser?> GetByIdAsync(Guid id);
    public Task<EUser?> GetByEmailAsync(string email);
    public Task<EUser?> GetByPhoneNumberAsync(string phoneNumber);
    public Task<EUser?> GetByNameAsync(string firstName, string lastName);
    public Task<EUser?> GetByLastNameAsync(string lastName);

}
