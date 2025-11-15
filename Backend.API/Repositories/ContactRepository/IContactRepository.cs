using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.API.Models.Entities;

namespace Backend.API.Repositories.ContactRepository
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAllAsync();
        Task<Contact?> GetByIdAsync(int id);
        Task<bool> CreateAsync(Contact Contact);
        Task<bool> UpdateAsync(Contact Contact);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Contact>> GetDropdownAsync();
    }
}