using System;
using LinqToDB;
using LinqToDB.Mapping;

namespace Models
{
    [Table(Name = "account")]
    public class Account
    {
        [Column("id", IsPrimaryKey = true)]
        public Guid Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("lastname")]
        public string LastName { get; set; }
        [Column("patronymic")]
        public string Patronymic { get; set; }
        [Column("city")]
        public string City { get; set; }
        [Column("phonenumber")]
        public string PhoneNumber { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("role")]
        public string Role { get; set; }
        [Column(Name = "tariffplanid")]
        public Guid TariffPlanId { get; set; }
        [Column(Name = "serviceid")]
        public Guid ServiceId { get; set; }
    }
}
