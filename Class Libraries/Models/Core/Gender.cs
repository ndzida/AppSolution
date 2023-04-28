using System;

namespace Models.Core
{
	public class Gender
	{
		public int GenderId { get; set; }
		public string GenderShort { get; set; }
		public string GenderTitle { get; set; }
		public string UserCreated { get; set; }
		public DateTime DateCreated { get; set; }
		public string UserModified { get; set; }
		public DateTime? DateModified { get; set; }
	}
}