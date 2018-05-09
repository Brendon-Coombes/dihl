using System.Threading.Tasks;
using DIHL.Client.Core.Enums;

namespace DIHL.Client.Core.Services.Contracts
{
	public interface IDialogService
	{
		Task<UserAction> Display(string title, string subText, string acceptButtonText, string dismissButtonText=null);
	}
}
