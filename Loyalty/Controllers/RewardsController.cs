using AutoMapper;
using si730ebu20201b980.API.Loyalty.Domain.Models;
using si730ebu20201b980.API.Loyalty.Domain.Services;
using si730ebu20201b980.API.Loyalty.Resources;
using si730ebu20201b980.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace si730ebu20201b980.API.Loyalty.Controllers;

[ApiController]
[Route("api/v1/")]
public class RewardsController : ControllerBase
{
    private readonly IRewardService _rewardService;
    private readonly IMapper _mapper;
    
    public RewardsController(IRewardService rewardService, IMapper mapper)
    {
        _rewardService = rewardService;
        _mapper = mapper;
    }
    
    [HttpGet("scores/{score}/rewards")]
    public async Task<IEnumerable<RewardResource>> GetRewardsByScoreAsync(decimal score)
    {
        var rewards = await _rewardService.ListByScoreAsync(score);
        var resources = _mapper.Map<IEnumerable<Reward>, IEnumerable<RewardResource>>(rewards);
        return resources;
    }
    
    [HttpPost("fleets/{fleetId}/rewards")]
    public async Task<IActionResult> PostAsync(int fleetId, [FromBody] SaveRewardResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var reward = _mapper.Map<SaveRewardResource, Reward>(resource);
        reward.fleetId = fleetId;
        var result = await _rewardService.SaveAsync(reward);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var rewardResource = _mapper.Map<Reward, RewardResource>(result.Resource);
        return Ok(rewardResource);
    }
}