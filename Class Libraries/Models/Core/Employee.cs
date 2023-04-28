using System;

namespace Models.Core
{
	public class Employee
	{
		public int EmployeeId { get; set; }
		public string Username { get; set; }
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public string NationalIdNumber { get; set; }
		public int NationalIdType { get; set; }
		public int GenderId { get; set; }
		public DateTime? Birthdate { get; set; }
		public string Address { get; set; }
		public int PlaceId { get; set; }
		public int CountryId { get; set; }
		public string UserCreated { get; set; }
		public DateTime DateCreated { get; set; }
		public string UserModified { get; set; }
		public DateTime? DateModified { get; set; }
	}
}