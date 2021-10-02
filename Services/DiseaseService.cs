using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Medicine.Dto;
using Medicine.Dto.Disease;
using Medicine.Extensions;
using Medicine.Paging;
using Microsoft.EntityFrameworkCore;

namespace Medicine.Services
{
    public class DiseaseService : IDiseaseService
    {
        private readonly MedicineDbContext _dbContext;
        private readonly IMapper _mapper;

        public DiseaseService(MedicineDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<PageResponse<DiseaseDto>> ListDiseasesAsync(FilterDiseaseDto filter, PageRequest pageRequest)
        {
            return await _dbContext
                .Diseases
                .Where(!string.IsNullOrEmpty(filter.Name), d => d.Name.ToLower().Contains(filter.Name.ToLower()))
                .Where(!string.IsNullOrEmpty(filter.Description), d => d.Description.ToLower().Contains(filter.Description.ToLower()))
                .ProjectTo<DiseaseDto>(_mapper.ConfigurationProvider)
                .ToPagedListAsync(pageRequest);
        }

        public async Task<DiseaseDetailsDto> GetDiseaseAsync(int id)
        {
            var disease = await _dbContext
                .Diseases
                .Include(d => d.Symptoms)
                .SingleOrDefaultAsync(d => d.Id == id);

            return _mapper.Map<DiseaseDetailsDto>(disease);
        }

        public async Task<List<DiseaseSearchResultDto>> SearchDiseasesForSymptomsAsync(FilterSymptomDto filter)
        {
            var syndromes = await _dbContext
                .Syndromes
                .Include(s => s.Disease)
                .Include(s => s.Symptoms)
                .Where(s => s.Symptoms.Any(sm => filter.SymptomIds.Contains(sm.Id)))
                .ToListAsync();

            return syndromes
                .Where(s => filter.SymptomIds.All(fi => s.Symptoms.Select(s => s.Id).Contains(fi)))
                .GroupBy(s => s.Disease)
                .Select(s => new DiseaseSearchResultDto
                {
                    Name = s.Key.Name,
                    Syndromes = _mapper.Map<List<SyndromeDto>>(s),
                    Description = s.Key.Description,
                    Id = s.Key.Id,
                    SyndromeCount = s.Count()
                })
                .ToList();
        }

        public async Task<List<SymptomDto>> ListSymptomsAsync(FilterSymptomNameDto filter)
        {
            return await _dbContext
                .Symptoms
                .Where(!string.IsNullOrEmpty(filter.Name), d => d.Name.ToLower().Contains(filter.Name.ToLower()))
                .ProjectTo<SymptomDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
