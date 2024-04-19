namespace BusinessLogic.Models
{
    /// <summary>
    /// Represents filter options for querying projects.
    /// </summary>
    public class ProjectFilterOptionsBL
    {
        /// <summary>
        /// Gets or sets the start date for filtering projects.
        /// </summary>
        public DateTime DateFrom { get; set; }

        /// <summary>
        /// Gets or sets the end date for filtering projects.
        /// </summary>
        public DateTime DateTo { get; set; }

        /// <summary>
        /// Gets or sets the minimum priority for filtering projects.
        /// </summary>
        public int MinPriority { get; set; }

        /// <summary>
        /// Gets or sets the maximum priority for filtering projects.
        /// </summary>
        public int MaxPriority { get; set; }

        /// <summary>
        /// Gets or sets the field by which to sort the projects.
        /// </summary>
        public string SortBy { get; set; }

        /// <summary>
        /// Gets or sets the type of sorting (ascending or descending).
        /// </summary>
        public bool Type { get; set; }
    }

}
