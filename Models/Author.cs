using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Example.Models
{
    public class Author
    {
        public Author() {}
        
        public Author(string firstName, string lastName, DateTime birthdate)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthdate;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("First name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        [DisplayName("Last name")]
        public string LastName { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [DisplayName("Birthdate")]
        public DateTime Birthdate { 
            get => _birthdate;
            set => _birthdate = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }

        public ICollection<Review> Reviews { get; set; } = new List<Review>();

        private DateTime _birthdate;
    }
}
