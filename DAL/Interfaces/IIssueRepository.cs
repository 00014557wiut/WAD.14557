using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAD.CW1._14557.Models;

namespace WAD.CW1._14557.DAL.Interfaces
{
    public interface IIssueRepository
    {
		Task<IEnumerable<Issue>> GetAllIssuesAsync();
		Task<Issue> GetIssueByIdAsync(int id);
		Task<Issue> CreateIssueAsync(Issue issue);
		Task UpdateIssueAsync(Issue issue);
		Task DeleteIssueAsync(int id);
	}
}
