namespace WAD.CW1._14557.Dtos
{
	public class CommentReadDto
	{
		public int Id { get; set; }
		public string Text { get; set; }
		public int IssueId { get; set; }
	}

	public class CommentCreateDto
	{
		public string Text { get; set; }
		public int IssueId { get; set; }
	}

	public class CommentUpdateDto
	{
		public string Text { get; set; }
	}
}
