using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.API.Models.Entities;
using Backend.API.Models.Requests;
using Backend.API.Models.Responses;
using Backend.API.Repositories.ContactRepository;
using Mapster;

namespace Backend.API.Services.ContactService
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<bool> CreateAsync(ContactInDto request) =>
            await _contactRepository.CreateAsync(request.Adapt<Contact>());

        public async Task<bool> DeleteAsync(int id) =>
            await _contactRepository.DeleteAsync(id);

        public async Task<IEnumerable<ContactOutDto>> GetAllAsync() {
            var list = await _contactRepository.GetAllAsync();
            return list.Adapt<IEnumerable<ContactOutDto>>();
        }

        public async Task<ContactOutDto?> GetByIdAsync(int id)
        {
            var Contact =  await _contactRepository.GetByIdAsync(id);
            return Contact?.Adapt<ContactOutDto>();
        }

        public async Task<IEnumerable<DropdownOutDto>> GetDropdownAsync()
        {
            var list = await _contactRepository.GetDropdownAsync();
            return list.Adapt<IEnumerable<DropdownOutDto>>();
        }

        public async Task<bool> UpdateAsync(int id, ContactInDto request)
        {
            var checkExists = await _contactRepository.GetByIdAsync(id);
            if (checkExists == null) return false;  

            checkExists.PostId = request.PostId;
            checkExists.Type = request.Type;
            checkExists.Value = request.Value;
            return await _contactRepository.UpdateAsync(checkExists);            
        }
    }
}