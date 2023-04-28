using System;

namespace Models.Core
{
	public class District
	{
		public int DistrictId { get; set; }
		public int RegionId { get; set; }
		public string DistrictTitle { get; set; }
		public string DistrictType { get; set; }
		public string UserCreated { get; set; }
		public DateTime DateCreated { get; set; }
		public string UserModified { get; set; }
		public DateTime? DateModified { get; set; }
	}
}