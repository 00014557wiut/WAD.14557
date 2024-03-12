using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WAD.CW1._14557.DAL.Interfaces;
using WAD.CW1._14557.Models;

[Route("api/[controller]")]
[ApiController]
public class IssuesController : ControllerBase
{
	private readonly IIssueRepository _issueRepository;

	public IssuesController(IIssueRepository issueRepository)
	{
		_issueRepository = issueRepository;
	}

	// GET: api/issues
	[HttpGet]
	public async Task<ActionResult<IEnumerable<Issue>>> GetIssues()
	{
		var issues = await _issueRepository.GetAllIssuesAsync();
		return Ok(issues);
	}

	// GET: api/issues/{id}
	[HttpGet("{id}")]
	public async Task<ActionResult<Issue>> GetIssue(int id)
	{
		var issue = await _issueRepository.GetIssueByIdAsync(id);

		if (issue == null)
		{
			return NotFound();
		}

		return Ok(issue);
	}

	// POST: api/issues
	[HttpPost]
	public async Task<ActionResult<Issue>> PostIssue(Issue issue)
	{
		await _issueRepository.CreateIssueAsync(issue);
		return CreatedAtAction(nameof(GetIssue), new { id = issue.Id }, issue);
	}

	// PUT: api/issues/{id}
	[HttpPut("{id}")]
	public async Task<IActionResult> PutIssue(int id, Issue issue)
	{
		if (id != issue.Id)
		{
			return BadRequest();
		}

		await _issueRepository.UpdateIssueAsync(issue);
		return NoContent();
	}

	// DELETE: api/issues/{id}
	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteIssue(int id)
	{
		await _issueRepository.DeleteIssueAsync(id);
		return NoContent();
	}
}

