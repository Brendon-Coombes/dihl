using System.ComponentModel.DataAnnotations;

namespace DIHL.Repository.Sql.Models
{
	public class SettingDataModel : IDataModel
	{
		[Required]
		public string Key { get; set; }
		public string Conditional { get; set; }

		[Required]
		public string Value { get; set; }
	}
}
