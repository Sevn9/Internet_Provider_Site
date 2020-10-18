using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TariffPlan
    {
        [Column("id", IsPrimaryKey = true)]
        public Guid Id { get; }
        [Column("name")]
        public string Name { get; }
        [Column("description")]
        public string Description { get; }
        [Column("speed")]
        public int Speed { get; }
        [Column("isavailablerouter")]
        public bool IsAvailableRouter { get; }
        [Column("price")]
        public decimal Price { get; }
        [Column("mobileinternet")]
        public int? MobileInternet { get; }
        [Column("options")]
        public string Options { get; }


    }
}
