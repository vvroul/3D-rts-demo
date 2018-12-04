using Actions;
using UnityEngine;

namespace Interactions
{
	public class ActionSelect : Interaction 
	{
		public override void Select()
		{
			ActionManager.Current.ClearButtons();
			foreach (var ab in GetComponents<ActionBehavior>())
			{
				ActionManager.Current.AddButton(ab.ButtonPic, ab.GetClickAction());
			}
		}

		public override void Deselect()
		{
			ActionManager.Current.ClearButtons();
		}
	}
}
