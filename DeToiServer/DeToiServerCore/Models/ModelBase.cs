using System.ComponentModel.DataAnnotations;

namespace DeToiServerCore.Models
{
    public abstract class ModelBase
    {
        [Key]
        public int Id { get; set; } 
    }
}
