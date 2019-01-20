using System;
using Definitions;
using Interactions;
using UnityEngine;

namespace Actions
{
	public class CreateUnitAction : ActionBehavior
	{

		public GameObject Prefab;
		public float Cost;

		private PlayerSetupDefinition _player;

		private void Start()
		{
			_player = GetComponent<Player>().Info;
		}

		public override Action GetClickAction()
		{
			return delegate
			{
				if (_player.Credits < Cost)
				{
					Debug.Log("Cannot create is costs : " + Cost);
					return;
				}
				
				var go = Instantiate(
					Prefab,
					transform.position,
					Quaternion.identity
				);
				if (go == null) throw new ArgumentNullException(string.Format("go{0}", "ARG0"));
				go.AddComponent<Player>().Info = _player;
				_player.Credits -= Cost;
				if (_player.IsAi) return;	//for safety reasons
				go.AddComponent<RightClickNavigation>();
				go.AddComponent<ActionSelect>();
				
			};
		}
	}
}
