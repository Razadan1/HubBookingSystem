using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HubBookingSystem.Data
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        [DisplayName("Booking Title")]
        [MaxLength(200)]
        public string Title { get; set; } = default!;
        [DisplayName("Seat Number")]
        [Range(1, 150, ErrorMessage = "Seat Number must be between 1 and 150.")]
        public int SeatNumber { get; set;} = default!;
       public string Email { get; set; } = default!;
       public string? Description { get; set; }
       public DateTime BookDate { get; set; } 
       public DateTime BookTime { get; set; }
    }
}