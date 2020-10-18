using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table(Name = "service")]
    public class Service
    {
        [Column("id", IsPrimaryKey = true)]
        public Guid Id { get; }
        [Column("name")]
        public string Name { get; }
        [Column("description")]
        public string Description { get; }
        [Column("gigabytesNumber")]
        public int GigabytesNumber { get; }
        [Column("connectionPrice")]
        public decimal ConnectionPrice { get; }

    }
}
