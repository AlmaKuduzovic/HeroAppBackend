using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeroWebApi.EFCore
{
    [Table("hero")]
    public class Hero
    {
        [Key, Required] 
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
