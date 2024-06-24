using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HubBookingSystem.Data;

namespace HubBookingSystem.Models
{
    public class BookingViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

        [DisplayName("Booking Title")]
        [MaxLength(200)]
        public required string Title { get; set; }
        [DisplayName("Seat Number")]
        [Range(1, 150, ErrorMessage = "Seat Number must be between 1 and 150.")]
        public int SeatNumber { get; set; }
        public required string Email { get; set; }
        public string? Description { get; set; }
        public DateOnly BookDate { get; set; }
        public TimeOnly BookTime { get; set; }
    }
}
