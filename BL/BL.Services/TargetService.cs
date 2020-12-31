using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abstractions;
using AutoMapper;
using BL.Models;
using BL.Models.Mapping;
using DAL.Abstractions;
using DAL.Models;

namespace BL.Services
{
    public class TargetService : BaseService, ITargetService
    {
        private readonly ITargetRepository _targetRepository;
        public TargetService(IMapper mapper, ITargetRepository targetRepository) : base(mapper)
        {
            _targetRepository = targetRepository;
        }
        
        public async Task<bool> CreateAsync(TargetDto targetDto)
        {
            var target = Mapper.Map<Target>(targetDto);
            if (await _targetRepository.ContainsAsync(t => t.Id == target.Id)) return false;
            target.Id = Guid.NewGuid();
            await _targetRepository.AddAsync(target);
            await _targetRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(TargetDto targetDto)
        {
            var target = await _targetRepository.GetAsync(t => t.Id == targetDto.Id);
            if (target == null) return false;
            Mapper.Map(targetDto, target);
            await _targetRepository.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<TargetDto>> GetAllAsync()
        {
            return Mapper.Map<IEnumerable<TargetDto>>(await _targetRepository.GetAllAsync());
        }

        public async Task<TargetDto> GetAsync(Guid uuid)
        {
            return Mapper.Map<TargetDto>(await _targetRepository.GetAsync(t => (t.Id == uuid)));
        }

        public async Task DeleteAsync(Guid uuid)
        {
            await _targetRepository.RemoveAsync(t => t.Id == uuid);
        }
    }
}