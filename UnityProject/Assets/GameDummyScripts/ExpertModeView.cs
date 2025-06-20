using Copper.ViewManager.Code.Interfaces;
using Nvizzio.Game.UI.Views;
using TMPro;
using UnityEngine;

namespace Nvizzio.Game.UI
{
	public class ExpertModeView : BasicView
	{
		[SerializeField]
		private RectTransform root;

		[SerializeField]
		private StyledButton closeButton;

		[SerializeField]
		private TextMeshProUGUI expertScoreLabel;

		public override void Initialize(ViewActionComplete onInitializationComplete)
		{
		}

		public void CloseButtonClick()
		{
		}

		public void CloseView()
		{
		}
	}
}
