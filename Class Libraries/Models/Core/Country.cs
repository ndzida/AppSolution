using System;

namespace Models.Core
{
	public class Country
	{
		public int CountryId { get; set; }
		public char? CountryCode { get; set; }
		public string CountryTitle { get; set; }
		public string UserCreated { get; set; }
		public DateTime DateCreated { get; set; }
		public string UserModified { get; set; }
		public DateTime? DateModified { get; set; }
	}
}