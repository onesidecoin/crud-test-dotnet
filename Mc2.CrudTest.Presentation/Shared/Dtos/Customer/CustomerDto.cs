using System.ComponentModel.DataAnnotations.Schema;

namespace Mc2.CrudTest.Presentation.Shared.Dtos.Customer
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int BankAccountNumber { get; set; }

        public string FullName { get { return Firstname + " " + Lastname; } set { } }
    }
}
