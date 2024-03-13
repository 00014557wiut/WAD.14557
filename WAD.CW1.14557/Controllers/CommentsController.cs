using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WAD.CW1._14557.DAL.Interfaces;
using WAD.CW1._14557.Dtos;
using WAD.CW1._14557.Models;

[Route("api/issues/{issueId}/comments")]
[ApiController]
public class CommentsController : ControllerBase
{
	private readonly ICommentRepository _commentRepository;
	private readonly IMapper _mapper;

	public CommentsController(ICommentRepository commentRepository, IMapper mapper)
	{
		_commentRepository = commentRepository;
		_mapper = mapper;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<CommentReadDto>>> GetCommentsForIssue(int issueId)
	{
		var comments = await _commentRepository.GetCommentsByIssueIdAsync(issueId);
		return Ok(_mapper.Map<IEnumerable<CommentReadDto>>(comments));
	}

	[HttpGet("{id}", Name = "GetCommentForIssue")]
	public async Task<ActionResult<CommentReadDto>> GetCommentForIssue(int issueId, int id)
	{
		var comment = await _commentRepository.GetCommentByIdAsync(id);
		if (comment == null) return NotFound();
		return Ok(_mapper.Map<CommentReadDto>(comment));
	}

	[HttpPost]
	public async Task<ActionResult<CommentReadDto>> CreateCommentForIssue(int issueId, CommentCreateDto commentCreateDto)
	{
		var comment = _mapper.Map<Comment>(commentCreateDto);
		comment.IssueId = issueId; // Ensure correct issue ID association
		await _commentRepository.CreateCommentAsync(comment);

		var commentReadDto = _mapper.Map<CommentReadDto>(comment);
		return CreatedAtRoute("GetCommentForIssue", new { issueId, id = commentReadDto.Id }, commentReadDto);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> UpdateCommentForIssue(int issueId, int id, CommentUpdateDto commentUpdateDto)
	{
		var commentFromRepo = await _commentRepository.GetCommentByIdAsync(id);
		if (commentFromRepo == null || commentFromRepo.IssueId != issueId) return NotFound();

		_mapper.Map(commentUpdateDto, commentFromRepo);
		await _commentRepository.UpdateCommentAsync(commentFromRepo); // Save changes

		return NoContent(); // 204 No Content
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteCommentForIssue(int issueId, int id)
	{
		var commentFromRepo = await _commentRepository.GetCommentByIdAsync(id);
		if (commentFromRepo == null || commentFromRepo.IssueId != issueId) return NotFound();

		await _commentRepository.DeleteCommentAsync(id);
		return NoContent();
	}
}

