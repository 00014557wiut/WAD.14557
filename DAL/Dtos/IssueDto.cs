namespace WAD.CW1._14557.Dtos
{
	public class IssueReadDto
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public bool IsResolved { get; set; }
	}

	public class IssueCreateDto
	{
		public string Title { get; set; }
		public string Description { get; set; }
	}

	public class IssueUpdateDto
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public bool IsResolved { get; set; }
	}
}
