using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StorageWebApi.Data.Models
{
    public class Storage
    {
        [Key]
        public Guid Sid { get; set; } = Guid.NewGuid();
        public string Sname { get; set; }
        public string Sdescription { get; set; }
        public int Sarea { get; set; }
        public User? Owner { get; set; } = null;

    }
}
