using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAD.CW1._14557.AppData;
using WAD.CW1._14557.DAL.Interfaces;
using WAD.CW1._14557.Models;

namespace WAD.CW1._14557.DAL.Repositories
{
	public class CommentRepository : ICommentRepository
	{
		private readonly ApplicationDbContext _context;

		public CommentRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Comment>> GetCommentsByIssueIdAsync(int issueId)
		{
			return await _context.Comments.Where(c => c.IssueId == issueId).ToListAsync();
		}

		public async Task<Comment> GetCommentByIdAsync(int id)
		{
			return await _context.Comments.FindAsync(id);
		}

		public async Task<Comment> CreateCommentAsync(Comment comment)
		{
			_context.Comments.Add(comment);
			await _context.SaveChangesAsync();
			return comment;
		}

		public async Task UpdateCommentAsync(Comment comment)
		{
			_context.Entry(comment).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		public async Task DeleteCommentAsync(int id)
		{
			var comment = await _context.Comments.FindAsync(id);
			if (comment != null)
			{
				_context.Comments.Remove(comment);
				await _context.SaveChangesAsync();
			}
		}
	}
}
