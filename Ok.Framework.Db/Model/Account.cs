using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ok.Framework.Db.Model
{
    public class Account
    {
        [Key]
        public Guid AccountId { get; set; }
        public string Name { get; set; }
        public string Address {  get; set; }
        public DateTime ModifiedOn { get; set; }

        public virtual List<Contact> Contacts { get; set; }
    }
}
