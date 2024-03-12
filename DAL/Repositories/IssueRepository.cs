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
	public class IssueRepository : IIssueRepository
	{
		private readonly ApplicationDbContext _context;

		public IssueRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Issue>> GetAllIssuesAsync()
		{
			return await _context.Issues.Include(i => i.Comments).ToListAsync();
		}

		public async Task<Issue> GetIssueByIdAsync(int id)
		{
			return await _context.Issues.Include(i => i.Comments).FirstOrDefaultAsync(i => i.Id == id);
		}

		public async Task<Issue> CreateIssueAsync(Issue issue)
		{
			_context.Issues.Add(issue);
			await _context.SaveChangesAsync();
			return issue;
		}

		public async Task UpdateIssueAsync(Issue issue)
		{
			_context.Entry(issue).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		public async Task DeleteIssueAsync(int id)
		{
			var issue = await _context.Issues.FindAsync(id);
			if (issue != null)
			{
				_context.Issues.Remove(issue);
				await _context.SaveChangesAsync();
			}
		}
	}
}
