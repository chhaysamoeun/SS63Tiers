using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SS63Tiers.Api.Models
{
	public class Employee
	{
		[Key]
		public Guid EmployeeId { get; set; }
		[Required]
		[MaxLength(50)]
		public string EmployeeName { get; set; }
		[Required]
		[MaxLength(10)]
		public string Gender { get; set; }
		[DataType(DataType.Date)]
		public DateTime DateOfBirth { get; set; }
		[Phone]
        [MaxLength(50)]
        public string PhoneNumber { get; set; }
		[EmailAddress]
		[MaxLength(50)]
		public string Email { get; set; }
		[MaxLength(100)]
		public string Address { get; set; }
		[ForeignKey("Position")]
		public Guid PositionId { get; set; }
        [ForeignKey("Department")]
        public Guid DepartmentId { get; set; }

		public Position Position { get; set; }
		public Department Department { get; set; }
	}
}

