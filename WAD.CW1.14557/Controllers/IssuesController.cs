using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WAD.CW1._14557.DAL.Interfaces;
using WAD.CW1._14557.Dtos;
using WAD.CW1._14557.Models;

[Route("api/[controller]")]
[ApiController]
public class IssuesController : ControllerBase
{
	private readonly IIssueRepository _issueRepository;
	private readonly IMapper _mapper;

	public IssuesController(IIssueRepository issueRepository, IMapper mapper)
	{
		_issueRepository = issueRepository;
		_mapper = mapper;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<IssueReadDto>>> GetAllIssues()
	{
		var issues = await _issueRepository.GetAllIssuesAsync();
		return Ok(_mapper.Map<IEnumerable<IssueReadDto>>(issues));
	}

	[HttpGet("{id}", Name = "GetIssueById")]
	public async Task<ActionResult<IssueReadDto>> GetIssueById(int id)
	{
		var issue = await _issueRepository.GetIssueByIdAsync(id);
		if (issue == null) return NotFound();
		return Ok(_mapper.Map<IssueReadDto>(issue));
	}

	[HttpPost]
	public async Task<ActionResult<IssueReadDto>> CreateIssue(IssueCreateDto issueCreateDto)
	{
		var issue = _mapper.Map<Issue>(issueCreateDto);
		issue = await _issueRepository.CreateIssueAsync(issue);
		var issueReadDto = _mapper.Map<IssueReadDto>(issue);
		return CreatedAtRoute(nameof(GetIssueById), new { id = issueReadDto.Id }, issueReadDto);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> UpdateIssue(int id, IssueUpdateDto issueUpdateDto)
	{
		var issueFromRepo = await _issueRepository.GetIssueByIdAsync(id);
		if (issueFromRepo == null) return NotFound();

		_mapper.Map(issueUpdateDto, issueFromRepo);
		await _issueRepository.UpdateIssueAsync(issueFromRepo); // Save changes

		return NoContent(); // 204 No Content
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteIssue(int id)
	{
		await _issueRepository.DeleteIssueAsync(id);
		return NoContent();
	}
}

