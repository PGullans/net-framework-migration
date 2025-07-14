using System;
using System.ComponentModel.DataAnnotations;

namespace Ok.Framework.Db.Model
{
    public class Contact
    {
        [Key]
        public Guid ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
