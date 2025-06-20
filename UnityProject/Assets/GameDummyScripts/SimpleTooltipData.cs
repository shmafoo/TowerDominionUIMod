using Nvizzio.Game.UI.Views;
using UnityEngine;
using UnityEngine.Localization;

namespace Nvizzio.Game.UI.Tooltip
{
	public class SimpleTooltipData : MonoBehaviour
	{
		[SerializeField]
		private UniversalTooltipTrigger tooltipTrigger;

		[SerializeField]
		private LocalizedString titleLocString;

		[SerializeField]
		private LocalizedString descriptionLocString;

		[SerializeField]
		private bool displayInput;

		[SerializeField]
		private string bindingUtils;

		private void OnEnable()
		{
		}

		private TooltipData GetTooltipData()
		{
			return default(TooltipData);
		}
	}
}
