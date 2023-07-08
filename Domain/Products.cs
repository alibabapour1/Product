using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Products : IValidatableObject
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(130, ErrorMessage = "The Email Of The Product Manufacure Should Contains 130 Characters At Most")]

        public string? ManufactureEmail { get; set; }

        [Required]
        [RegularExpression(@"^(\+98|0)?9\d{9}$", ErrorMessage = "Please enter a valid Iranian phone number.")]
        public string? ManufacturePhone { get; set; }

        [Required]
        public DateTime ProduceDate { get; set; }

        [Required]
        [MaxLength(130, ErrorMessage = "The name Of The Product Should Contains 130 Characters At Most")]
        public string? Name { get; set; }


        public Users User { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Access the database context
            var dbContext = (YourDbContext)validationContext.GetService(typeof(YourDbContext));

            // Check if the email is already used
            var existingEmail = dbContext.Products.FirstOrDefault(p => p.ManufactureEmail == ManufactureEmail);
            if (existingEmail != null)
            {
                yield return new ValidationResult("ManufactureEmail must be unique.", new[] { nameof(ManufactureEmail) });
            }

            // Check if the phone number is already used
            var existingPhone = dbContext.Products.FirstOrDefault(p => p.ManufacturePhone == ManufacturePhone);
            if (existingPhone != null)
            {
                yield return new ValidationResult("ManufacturePhone must be unique.", new[] { nameof(ManufacturePhone) });
            }
        }
    }
}

