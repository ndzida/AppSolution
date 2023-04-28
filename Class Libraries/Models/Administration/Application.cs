using System;

namespace Models.Administration
{
	public class Application
	{
		public int ApplicationId { get; set; }
		public string ApplicationTitle { get; set; }
		public string UserCreated { get; set; }
		public DateTime DateCreated { get; set; }
		public string UserModified { get; set; }
		public DateTime? DateModified { get; set; }
	}
}