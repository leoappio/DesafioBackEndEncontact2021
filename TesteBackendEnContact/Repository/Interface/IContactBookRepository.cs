using System.Collections.Generic;
using System.Threading.Tasks;
using TesteBackendEnContact.Core.Interface.ContactBook;

namespace TesteBackendEnContact.Repository.Interface
{
    public interface IContactBookRepository
    {
        Task<IContactBook> SaveAsync(IContactBook contactBook);
        Task DeleteAsync(int id);
        Task<IContactBook> Put(IContactBook contactBook);
        Task<IEnumerable<IContactBook>> GetAllAsync();
        Task<IContactBook> GetAsync(int id);
    }
}
