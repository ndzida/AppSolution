using System;

namespace Models.Core
{
	public class Place
	{
		public int PlaceId { get; set; }
		public string PlaceNationalCode { get; set; }
		public string PlaceTitle { get; set; }
		public int DistrictId { get; set; }
		public int RegionId { get; set; }
		public string UserCreated { get; set; }
		public DateTime DateCreated { get; set; }
		public string UserModified { get; set; }
		public DateTime? DateModified { get; set; }
	}
}