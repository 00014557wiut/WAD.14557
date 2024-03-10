namespace WAD.CW1._14557.Models
{
	public class Comment
	{
		public int Id { get; set; }
		public string Text { get; set; }
		public int IssueId { get; set; }
		public Issue Issue { get; set; }
	}
}
