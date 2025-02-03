using System.ComponentModel.DataAnnotations;

namespace FlopyBirbServer
{
    public class Player
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public required string Username { get; set; }

        [Required]
        public required string PasswordHash { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int HighScore { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Coins { get; set; }

        [Required]
        public required CharacterCustomization[] AvailableCharacterCustomization;
    }
}