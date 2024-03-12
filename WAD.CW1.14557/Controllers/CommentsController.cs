using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WAD.CW1._14557.DAL.Interfaces;
using WAD.CW1._14557.Models;

[Route("api/issues/{issueId}/[controller]")]
[ApiController]
public class CommentsController : ControllerBase
{
	private readonly ICommentRepository _commentRepository;

	public CommentsController(ICommentRepository commentRepository)
	{
		_commentRepository = commentRepository;
	}

	// GET: api/issues/{issueId}/comments
	[HttpGet]
	public async Task<ActionResult<IEnumerable<Comment>>> GetComments(int issueId)
	{
		var comments = await _commentRepository.GetCommentsByIssueIdAsync(issueId);
		return Ok(comments);
	}

	// GET: api/issues/{issueId}/comments/{id}
	[HttpGet("{id}")]
	public async Task<ActionResult<Comment>> GetComment(int issueId, int id)
	{
		var comment = await _commentRepository.GetCommentByIdAsync(id);

		if (comment == null || comment.IssueId != issueId)
		{
			return NotFound();
		}

		return Ok(comment);
	}

	// POST: api/issues/{issueId}/comments
	[HttpPost]
	public async Task<ActionResult<Comment>> PostComment(int issueId, Comment comment)
	{
		if (comment.IssueId != issueId)
		{
			return BadRequest();
		}

		await _commentRepository.CreateCommentAsync(comment);
		return CreatedAtAction(nameof(GetComment), new { issueId = issueId, id = comment.Id }, comment);
	}

	// PUT: api/issues/{issueId}/comments/{id}
	[HttpPut("{id}")]
	public async Task<IActionResult> PutComment(int id, int issueId, Comment comment)
	{
		if (id != comment.Id || issueId != comment.IssueId)
		{
			return BadRequest();
		}

		await _commentRepository.UpdateCommentAsync(comment);
		return NoContent();
	}

	// DELETE: api/issues/{issueId}/comments/{id}
	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteComment(int issueId, int id)
	{
		var comment = await _commentRepository.GetCommentByIdAsync(id);
		if (comment == null || comment.IssueId != issueId)
		{
			return NotFound();
		}

		await _commentRepository.DeleteCommentAsync(id);
		return NoContent();
	}
}
