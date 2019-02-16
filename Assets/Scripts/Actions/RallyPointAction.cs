using System;
using Definitions;
using UnityEngine;

namespace Actions
{
	public class RallyPointAction : ActionBehavior {

		private PlayerSetupDefinition _player;
		private Vector3? _tempTarget;
		
		private void Update()
		{
			_player = GetComponent<Player>().Info;
			
			if (Input.GetKeyDown(KeyCode.Z) && Input.GetKeyDown(KeyCode.X))
			{
				_tempTarget = RtsManager.Current.ScreenPointToMapPosition(Input.mousePosition);
			}
		}

		
		public override Action GetClickAction()
		{
			return delegate
			{
				if (_tempTarget != null) 
					_player.SpawnToPosition.position = _tempTarget.Value;
			};
		}
	}
}
