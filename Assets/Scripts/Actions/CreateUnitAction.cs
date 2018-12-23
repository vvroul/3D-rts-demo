using System;
using Definitions;
using Interactions;
using UnityEngine;

namespace Actions
{
	public class CreateUnitAction : ActionBehavior
	{

		public GameObject Prefab;
		public float Cost = 0;

		private PlayerSetupDefinition player;

		private void Start()
		{
			player = GetComponent<Player>().Info;
		}

		public override Action GetClickAction()
		{
			return delegate
			{
				if (player.Credits < Cost)
				{
					Debug.Log("Cannot create is costs : " + Cost);
					return;;
				}
				
				var go = (GameObject) GameObject.Instantiate(
					Prefab,
					transform.position,
					Quaternion.identity
				);
				go.AddComponent<Player>().Info = player;
				go.AddComponent<RightClickNavigation>();
				go.AddComponent<ActionSelect>();
				player.Credits -= Cost;
			};
		}
	}
}
