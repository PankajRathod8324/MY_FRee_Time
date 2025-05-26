using System.ComponentModel.DataAnnotations;

namespace Entities.ViewModel
{
    public class ChangePasswordVM : IValidatableObject
    {
        [Required(ErrorMessage = "Current Password is required")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Current password must be between 6 and 50 characters")]
        public string CurrentPassword { get; set; } = null!;

        [Required(ErrorMessage = "New Password is required")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "New password must be between 6 and 50 characters")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,50}$", 
            ErrorMessage = "Password must have at least 1 uppercase, 1 lowercase, 1 number, and 1 special character.")]
        public string NewPassword { get; set; } = null!;

        [Required(ErrorMessage = "Confirm New Password is required")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmNewPassword { get; set; }  = null!;

        // Custom validation to ensure NewPassword != CurrentPassword
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrWhiteSpace(CurrentPassword) && !string.IsNullOrWhiteSpace(NewPassword))
            {
                if (CurrentPassword == NewPassword)
                {
                    yield return new ValidationResult(
                        "New password cannot be the same as the current password.",
                        new[] { nameof(NewPassword) });
                }
            }
        }
    }
}
