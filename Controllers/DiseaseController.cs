using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Medicine.Dto;
using Medicine.Dto.Disease;
using Medicine.Paging;
using Medicine.Services;

namespace Medicine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiseaseController : ControllerBase
    {
        private readonly IDiseaseService _diseaseService;

        public DiseaseController(IDiseaseService diseaseService)
        {
            _diseaseService = diseaseService;
        }

        [HttpGet]
        public Task<PageResponse<DiseaseDto>> ListDiseases([FromQuery] FilterDiseaseDto filter, [FromQuery] PageRequest pageRequest)
            => _diseaseService.ListDiseasesAsync(filter, pageRequest);

        [HttpGet("symptoms")]
        public Task<List<SymptomDto>> ListSymptoms([FromQuery] FilterSymptomNameDto filter)
            => _diseaseService.ListSymptomsAsync(filter);

        [HttpGet("{id}")]
        public Task<DiseaseDetailsDto> GetDisease(int id)
            => _diseaseService.GetDiseaseAsync(id);

        [HttpGet("from-symptoms")]
        public Task<List<DiseaseSearchResultDto>> SearchDiseasesForSymptoms([FromQuery] FilterSymptomDto filter)
            => _diseaseService.SearchDiseasesForSymptomsAsync(filter);
    }
}
