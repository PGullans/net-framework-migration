using System;
using System.ComponentModel.DataAnnotations;

namespace Ok.Framework.Db.Model
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual Account Account { get; set; }
    }
}
