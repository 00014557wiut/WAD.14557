namespace WAD.CW1._14557.Models
{
	public class Issue
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public bool IsResolved { get; set; }
		public List<Comment> Comments { get; set; } = new List<Comment>();
	}
}
