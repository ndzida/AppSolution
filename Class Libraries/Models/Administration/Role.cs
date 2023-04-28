using System;

namespace Models.Administration
{
	public class Role
	{
		public int RoleId { get; set; }
		public string RoleTitle { get; set; }
		public string UserCreated { get; set; }
		public DateTime DateCreated { get; set; }
		public string UserModified { get; set; }
		public DateTime? DateModified { get; set; }
	}
}