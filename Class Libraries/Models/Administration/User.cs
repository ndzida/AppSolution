using System;

namespace Models.Administration
{
	public class User
	{
		public int UserId { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public string PasswordHash { get; set; }
		public bool IsActive { get; set; }
		public bool IsRegistered { get; set; }
		public string UserCreated { get; set; }
		public DateTime DateCreated { get; set; }
		public string UserModified { get; set; }
		public DateTime? DateModified { get; set; }
	}
}