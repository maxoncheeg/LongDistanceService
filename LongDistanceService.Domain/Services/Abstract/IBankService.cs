using LongDistanceService.Domain.Models.Abstract.Personals;

namespace LongDistanceService.Domain.Services.Abstract;

public interface IBankService
{
    public Task<IList<IBank>> GetBanksAsync();
    public Task<bool> AddOrUpdateBankAsync(IBank bank);
    public Task<bool> DeleteBankAsync(int id);
    
}