using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Medicine.Dto;
using Medicine.Dto.Disease;
using Medicine.Paging;

namespace Medicine.Services
{
    public interface IDiseaseService
    {
        Task<PageResponse<DiseaseDto>> ListDiseasesAsync(FilterDiseaseDto filter, PageRequest pageRequest);
        Task<DiseaseDetailsDto> GetDiseaseAsync(int id);
        Task<List<DiseaseSearchResultDto>> SearchDiseasesForSymptomsAsync(FilterSymptomDto filter);
        Task<List<SymptomDto>> ListSymptomsAsync(FilterSymptomNameDto filter);
    }
}
