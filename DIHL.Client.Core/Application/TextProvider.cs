using System;
using System.Globalization;
using System.Linq;
using System.Resources;
using MvvmCross.Localization;

namespace DIHL.Client.Core.Application
{
    public class TextProvider : IMvxTextProvider
    {
	    private readonly ResourceManager _resourceManager;

		public CultureInfo Culture { get; set; }

		public TextProvider(ResourceManager resourceManager)
		{
			_resourceManager = resourceManager;
			Culture = CultureInfo.CurrentCulture;
		}

		public string GetText(string namespaceKey, string typeKey, string name)
		{
			var parts = new[] {namespaceKey, typeKey, name};
			var resolvedKey = string.Join("_", parts.Where(s => !string.IsNullOrEmpty(s)));
			return _resourceManager.GetString(resolvedKey, Culture);
		}

		public string GetText(string namespaceKey, string typeKey, string name, params object[] formatArgs)
		{
			var baseText = GetText(namespaceKey, typeKey, name);
			return string.Format(baseText, formatArgs);
		}

		public bool TryGetText(out string textValue, string namespaceKey, string typeKey, string name)
		{
			try
			{
				textValue = GetText(namespaceKey, typeKey, name);
				return true;
			}
			catch (Exception)
			{
				textValue = null;
				return false;
			}
		}

		public bool TryGetText(out string textValue, string namespaceKey, string typeKey, string name, params object[] formatArgs)
		{
			try
			{
				textValue = GetText(namespaceKey, typeKey, name, formatArgs);
				return true;
			}
			catch (Exception)
			{
				textValue = null;
				return false;
			}
		}
	}
}
