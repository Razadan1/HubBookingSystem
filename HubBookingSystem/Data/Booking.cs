using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HubBookingSystem.Data
{
    public class Booking
    {
        [Key]
        public Guid BookId { get; set; }
        [DisplayName("Booking Title")]
        [MaxLength(200)]
        public string Title { get; set; } = default!;
        [DisplayName("Seat Number")]
        [Range(1, 150, ErrorMessage = "Seat Number must be between 1 and 150.")]
        public int SeatNumber { get; set;} = default!;
       public string Email { get; set; } = default!;
       public string Description { get; set; } = default!;
       public DateOnly BookDate { get; set; } 
       public TimeOnly BookTime { get; set; }
    }
}