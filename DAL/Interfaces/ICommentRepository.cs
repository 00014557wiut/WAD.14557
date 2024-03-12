using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAD.CW1._14557.Models;

namespace WAD.CW1._14557.DAL.Interfaces
{
    public interface ICommentRepository
    {
		Task<IEnumerable<Comment>> GetCommentsByIssueIdAsync(int issueId);
		Task<Comment> GetCommentByIdAsync(int id);
		Task<Comment> CreateCommentAsync(Comment comment);
		Task UpdateCommentAsync(Comment comment);
		Task DeleteCommentAsync(int id);
	}
}
