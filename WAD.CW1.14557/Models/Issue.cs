namespace WAD.CW1._14557.Models
{
	public class Issue
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Status { get; set; }
		public DateTime Created { get; set; }
		public int TrakerId { get; set; }
		public Tracker Tracker { get; set; }
	}
}
