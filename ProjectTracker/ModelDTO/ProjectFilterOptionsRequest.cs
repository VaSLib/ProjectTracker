using System.ComponentModel.DataAnnotations;

namespace ProjectTracker.ModelDTO
{
    /// <summary>
    /// Represents the data model for filtering project options.
    /// </summary>
    public class ProjectFilterOptionsRequest
    {
        /// <summary>
        /// Gets or sets the start date for filtering projects.
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime DateFrom { get; set; }

        /// <summary>
        /// Gets or sets the end date for filtering projects.
        /// </summary>
        [DataType(DataType.Date)]
        [DateGreaterThan("DateFrom", ErrorMessage = "Project finish date must be greater than start date")]
        public DateTime DateTo { get; set; }

        /// <summary>
        /// Gets or sets the minimum priority for filtering projects.
        /// </summary>
        [Range(0, 10, ErrorMessage = "MinPriority must be between 0 and 10")]
        public int MinPriority { get; set; }

        /// <summary>
        /// Gets or sets the maximum priority for filtering projects.
        /// </summary>
        [Range(0, 10, ErrorMessage = "MaxPriority must be between 0 and 10")]
        public int MaxPriority { get; set; }

        /// <summary>
        /// Gets or sets the field to sort projects by.
        /// </summary>
        [StringLength(100, ErrorMessage = "SortBy cannot exceed 100 characters")]
        public string SortBy { get; set; }

        /// <summary>
        /// Gets or sets the type of sorting (ascending or descending).
        /// </summary>
        public bool Type { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectFilterOptionsRequest"/> class with default values.
        /// </summary>
        public ProjectFilterOptionsRequest()
        {
            DateFrom = DateTime.MinValue;
            DateTo = DateTime.Now;
            MinPriority = 0;
            MaxPriority = 10;
            SortBy = string.Empty;
            Type = true;
        }
    }
}
