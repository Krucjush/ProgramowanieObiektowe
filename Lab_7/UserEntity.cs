using System;
using System.Data.Linq.Mapping;

namespace Lab_7
{
    [Table(Name = "Users")]
    public class UserEntity
    {
        [Column(IsPrimaryKey = true, Name = "Id")]
        public long Id { get; set; }
        [Column(Name = "Name")]
        public string Name { get; set; }
        [Column(Name = "Role")]
        public string Role { get; set; }
        [Column(Name = "CreatedAt")]
        public DateTime? createdAd { get; set; }
        [Column(Name ="RemovedAt")]
        public DateTime? RemovedAt { get; set; }
    }
}
