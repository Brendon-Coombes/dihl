using System;

namespace DIHL.DTOs
{
    /// <summary>
    /// Represents an API Error data set
    /// </summary>
    public class ApiErrorDTO
    {
        /// <summary>
        /// The error message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The error correlation Id
        /// </summary>
        public Guid? CorrelationId { get; set; }
        public string StackTrace { get; set; }
    }
}
