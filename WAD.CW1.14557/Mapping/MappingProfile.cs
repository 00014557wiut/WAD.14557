using static System.Runtime.InteropServices.JavaScript.JSType;
using WAD.CW1._14557.Models;
using WAD.CW1._14557.Dtos;

namespace WAD.CW1._14557.Mapping
{
	public class MapperProfile : Profile
	{
		public MapperProfile()
		{
			CreateMap<Issue, IssueDto>();
			CreateMap<IssueDto, Issue>();
			CreateMap<Comment, CommentDto>();
			CreateMap<CommentDto, Comment>();
		}
	}
}
