namespace WAD.CW1._14557.Models
{
	public class Tracker
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime UpdateDate { get; set; }
		public ICollection<Issue> Issues { get; set; }
	}
}
