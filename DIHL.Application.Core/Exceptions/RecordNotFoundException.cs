using System;

namespace DIHL.Application.Core.Exceptions
{
    public class RecordNotFoundException : Exception, IPassthroughException
    {
	    public string DisplayMessage { get; }

		public RecordNotFoundException(string entityType, Guid entityId)
            : base($"No '{entityType}' record found with Id '{entityId}'.{Environment.NewLine}")
        {
            DisplayMessage = $"No '{entityType}' record found with Id '{entityId}'.";
        }

	    public RecordNotFoundException(string entityType, string uniqueId)
		    : base($"No '{entityType}' record found with identifier '{uniqueId}'.{Environment.NewLine}")
		{
			DisplayMessage = $"No '{entityType}' record found with identifier '{uniqueId}'.";
		}
    }
}
