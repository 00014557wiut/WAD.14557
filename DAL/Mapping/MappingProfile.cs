using WAD.CW1._14557.Models;
using WAD.CW1._14557.Dtos;
using AutoMapper;

namespace WAD.CW1._14557.Mapping
{
	public class MapperProfile : Profile
	{
		public MapperProfile()
		{
			// Issue mappings
			CreateMap<Issue, IssueReadDto>();
			CreateMap<IssueCreateDto, Issue>();
			CreateMap<IssueUpdateDto, Issue>().ForMember(i => i.Id, opt => opt.Ignore()); // Ignore Id when mapping to an existing entity

			// Comment mappings
			CreateMap<Comment, CommentReadDto>();
			CreateMap<CommentCreateDto, Comment>();
			CreateMap<CommentUpdateDto, Comment>().ForMember(c => c.Id, opt => opt.Ignore()); // Ignore Id for updates
		}
	}
}
