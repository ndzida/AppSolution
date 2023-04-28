using System;

namespace Models.Core
{
	public class Region
	{
		public int RegionId { get; set; }
		public string RegionTitle { get; set; }
		public int CountryId { get; set; }
		public string UserCreated { get; set; }
		public DateTime DateCreated { get; set; }
		public string UserModified { get; set; }
		public DateTime? DateModified { get; set; }
	}
}