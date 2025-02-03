using System.ComponentModel.DataAnnotations;

namespace FlopyBirbServer
{
    public class CharacterCustomization
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string CustomizationName { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Price { get; set; }
    }
}
