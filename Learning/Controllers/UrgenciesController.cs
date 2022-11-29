using AutoMapper;
using si730ebu20201b980.API.Learning.Domain.Models;
using si730ebu20201b980.API.Learning.Domain.Services;
using si730ebu20201b980.API.Learning.Resources;
using si730ebu20201b980.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace si730ebu20201b980.API.Learning.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UrgenciesController: ControllerBase
{
    private readonly IUrgencyService _urgencyService;
    private readonly IGuardianService _guardianService;
    private readonly IMapper _mapper;
    
    public UrgenciesController(IUrgencyService urgencyService, IGuardianService guardianService, IMapper mapper)
    {
        _urgencyService = urgencyService;
        _guardianService = guardianService;
        _mapper = mapper;
    }
    
    /*[HttpGet]
    public async Task<IEnumerable<UrgencyResource>> GetAllAsync()
    {
        var urgencies = await _urgencyService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Urgency>, IEnumerable<UrgencyResource>>(urgencies);
        return resources;
    }
    */
    [HttpGet("/api/guardians/{guardianId}/urgencies")]
    public async Task<IEnumerable<UrgencyResource>> GetAllAsync(int guardianId)
    {
        var urgencies = await _urgencyService.ListByGuardianIdAsync(guardianId);
        var resources = _mapper.Map<IEnumerable<Urgency>, IEnumerable<UrgencyResource>>(urgencies);
        return resources;
    }
    
    
    //[Route("api/guardians/[controller]")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var urgency = await _urgencyService.FindByIdAsync(id);
        var urgencyResource = _mapper.Map<Urgency, UrgencyResource>(urgency);
        return Ok(urgencyResource);
    }
    
    [HttpPost("/api/guardians/{guardianId}/urgencies")]
    public async Task<IActionResult> PostAsync(int guardianId, [FromBody] SaveUrgencyResource resource)
    {
        var existingGuardian = await _guardianService.FindByIdAsync(guardianId);
        if (existingGuardian == null)
            return BadRequest("Guardian does not exist");
        
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var urgency = _mapper.Map<SaveUrgencyResource, Urgency>(resource);
        urgency.GuardianId = guardianId;
        var result = await _urgencyService.SaveAsync(urgency);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var urgencyResource = _mapper.Map<Urgency, UrgencyResource>(result.Resource);
        return Ok(urgencyResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int guardianId, int id, [FromBody] SaveUrgencyResource resource)
    {
        var existingGuardian = await _guardianService.FindByIdAsync(guardianId);
        if (existingGuardian == null)
            return BadRequest("Guardian does not exist");
        
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var urgency = _mapper.Map<SaveUrgencyResource, Urgency>(resource);
        var result = await _urgencyService.UpdateAsync(id, urgency);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var urgencyResource = _mapper.Map<Urgency, UrgencyResource>(result.Resource);
        return Ok(urgencyResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _urgencyService.DeleteAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);
        var urgencyResource = _mapper.Map<Urgency, UrgencyResource>(result.Resource);
        return Ok(urgencyResource);
    }
    /*
     
[Route("/api/v1/categories/{categoryId}/tutorials")]
public class CategoryTutorialsController : ControllerBase
{
    private readonly ITutorialService _tutorialService;
    private readonly IMapper _mapper;

    public CategoryTutorialsController(ITutorialService tutorialService, IMapper mapper)
    {
        _tutorialService = tutorialService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<TutorialResource>> GetAllByCategoryIdAsync(int categoryId)
    {
        var tutorials = await _tutorialService.ListByCategoryIdAsync(categoryId);

        var resources = _mapper.Map<IEnumerable<Tutorial>, IEnumerable<TutorialResource>>(tutorials);

        return resources;
    }
}
    */
}