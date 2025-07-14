using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [ForeignKey("Account")]
        public Guid AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
}
