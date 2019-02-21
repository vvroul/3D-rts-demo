using System;
using System.Collections;
using Definitions;
using Interactions;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;
using Random = System.Random;

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
				TheAction();
			};
		}

		void TheAction()
		{
			if (_player.Credits < Cost)
			{
				Debug.Log("Cannot create is costs : " + Cost);
				return;
			}
			var go = Instantiate(
				Prefab,
				_player.SpawnToPosition.position + Vector3.right * UnityEngine.Random.Range(5,10),
				Quaternion.identity
			);
			if (go == null) throw new ArgumentNullException(string.Format("go{0}", "ARG0"));
			go.AddComponent<Player>().Info = _player;
			_player.Credits -= Cost;
			if (_player.IsAi) return;	//for safety reasons
			go.AddComponent<RightClickNavigation>();
			go.AddComponent<ActionSelect>();
		}
	}
}
