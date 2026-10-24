using System;
using System.ComponentModel.DataAnnotations;

namespace Practical7.Models
{
    public class StudentReview
    {
        [Display(Name = "Enrollment Number")]
        [Required(ErrorMessage = "Enrollment No is required")]
        [RegularExpression(@"^\d{10,12}$", ErrorMessage = "Enrollment No must be 10 to 12 digits")]
        public string EnrollmentNo { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string StudentName { get; set; }

        [Display(Name = "Course")]
        [Required(ErrorMessage = "Subject is required")]
        public string CourseName { get; set; }

        [Display(Name = "Rating")]
        [Required(ErrorMessage = "Rating is required")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; }

        [Display(Name = "Remarks")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Comments are required")]
        [StringLength(500, ErrorMessage = "Comments cannot exceed 500 characters")]
        public string Remarks { get; set; }

        public DateTime SubmittedOn { get; set; }
    }
}
