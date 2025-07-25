using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ok.Framework.Db.Model
{
    public class Order : DbModel
    {
        [Key]
        public Guid OrderId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        [ForeignKey("Account")]
        public Guid AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
}
