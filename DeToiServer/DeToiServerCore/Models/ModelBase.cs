using System.ComponentModel.DataAnnotations.Schema;

namespace DeToiServerCore.Models
{
    public abstract class ModelBase
    {
        public int Id { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
