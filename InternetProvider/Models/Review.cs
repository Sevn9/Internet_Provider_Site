using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    [Table(Name = "comments")]
    public class Review
    {
        [Column("id", IsPrimaryKey = true)]
        public Guid Id { get; set; }
        [Column(Name = "account")]
        public string PersonalDataId { get; set; }         
        public string ItemType { get; set; }
        [Column(Name = "tariffid")]
        public Guid ItemTypeId { get; set; }
        [Column(Name = "content")]
        public string Content { get; set; }
        [Column(Name = "date_of_publication")]
        [System.ComponentModel.DataAnnotations.DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
    }
}
