using System.ComponentModel.DataAnnotations;

namespace ProjectTracker.ModelDTO
{
    /// <summary>
    /// Represents the data model for a project request.
    /// </summary>
    public class ProjectRequest
    {
        /// <summary>
        /// Gets or sets the name of the project.
        /// </summary>
        [Required(ErrorMessage = "Name is required")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters long")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the customer company name.
        /// </summary>
        [StringLength(100, ErrorMessage = "Customer company name cannot exceed 100 characters")]
        public string CustomerCompanyName { get; set; }

        /// <summary>
        /// Gets or sets the performer company name.
        /// </summary>
        [StringLength(100, ErrorMessage = "Performer company name cannot exceed 100 characters")]
        public string PerformerCompanyName { get; set; }

        /// <summary>
        /// Gets or sets the project start date.
        /// </summary>
        [Required(ErrorMessage = "Project start date is required")]
        [DataType(DataType.Date)]
        public DateTime ProjectStartDate { get; set; }

        /// <summary>
        /// Gets or sets the project finish date.
        /// </summary>
        [Required(ErrorMessage = "Project finish date is required")]
        [DataType(DataType.Date)]
        [DateGreaterThan("ProjectStartDate", ErrorMessage = "Project finish date must be greater than start date")]
        public DateTime ProjectFinishDate { get; set; }

        /// <summary>
        /// Gets or sets the project priority.
        /// </summary>
        [Required(ErrorMessage = "Project priority is required")]
        [Range(1, 10, ErrorMessage = "Project priority must be between 1 and 10")]
        public int ProjectPriority { get; set; }
    }
}
