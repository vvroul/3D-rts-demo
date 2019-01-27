using System;
using System.Collections.Generic;
using UnityEngine;
using Definitions;
using Interactions;

namespace Actions
{
	public class RallyPointAction : ActionBehavior {
		
		private PlayerSetupDefinition _player;
		private List<GameObject> _unbornUnits = new List<GameObject>();

		private void Start()
		{
			_player = GetComponent<Player>().Info;
		}
	
		public override Action GetClickAction()
		{
			return delegate
			{
				foreach (var u in _unbornUnits)
				{
					//u.GetComponent<RightClickNavigation>().SendToTarget(_player.MineralPatchLocation.position);
				}
			};
		}
	}
}
