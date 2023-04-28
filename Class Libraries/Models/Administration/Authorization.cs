using System;

namespace Models.Administration
{
	public class Authorization
	{
		public int AuthorizationId { get; set; }
		public string AuthorizationTitle { get; set; }
		public string UserCreated { get; set; }
		public DateTime DateCreated { get; set; }
		public string UserModified { get; set; }
		public DateTime? DateModified { get; set; }
	}
}