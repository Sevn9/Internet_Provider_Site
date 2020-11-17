using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table(Name = "tariffplan")]
    public class TariffPlan
    {
        [Column("id", IsPrimaryKey = true)]
        public Guid Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("speed")]
        public int Speed { get; set; }
        [Column("isavailablerouter")]
        public bool IsAvailableRouter { get; set; }
        [Column("price")]
        public decimal Price { get; set; }
        [Column("mobileinternet")]
        public int? MobileInternet { get; set; }
        [Column("option")]
        public string Options { get; set; }
        public IEnumerable<Review> Reviews { get; set; }


    }
}
