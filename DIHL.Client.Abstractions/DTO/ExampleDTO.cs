using System;
using System.Diagnostics;

namespace DIHL.Client.Abstractions.DTO
{
    /// <summary>
    /// Represents an example data set
    /// </summary>
    [DebuggerDisplay("{Id} : {Value}")]
    public class ExampleDTO
    {
        /// <summary>
        /// The unique identifier for this example data
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The examples name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The examples state
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Date UTC date when this record was created
        /// </summary>
        public DateTime CreatedOn { get; set; }

    }
}
